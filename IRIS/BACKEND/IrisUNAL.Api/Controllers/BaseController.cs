using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using IrisUNAL.Api.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace IrisUNAL.Api.Controllers
{
    public class CustomHeaders
    {
        public string Authorization { get; set; }
        public string Usuario { get; set; }
    }

    public class BaseController<TEntity> : ApiController
    {
        WebAppLogger logger;
        protected CustomHeaders customheaders { get; private set; }

        public BaseController()
        {
            this.Logger.Info.WebServiceName = ControllerName;

        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            GlobalParams.usuariocontroller = "";
            //bool validkey = false;
            //string APIKeyIRIS = "83e909a2-81b2-4595-bbd9-e0ddf6a479e0";

            HttpRequestHeaders headers = controllerContext.Request.Headers;
            IEnumerable<string> headerValues;

            //Almacena el usuario que realiza la petición
            if (headers.Contains("Usuario")) {
                if (headers.TryGetValues("Usuario", out headerValues))
                {
                    GlobalParams.usuariocontroller = headerValues.First();
                }
            }
            /*
            //Se valida el APIKey
            var checkApiKeyExists = headers.TryGetValues("APIKey", out headerValues);

            if (checkApiKeyExists)
            {
                if (headerValues.FirstOrDefault().Contains(APIKeyIRIS))
                {
                    validkey = true;
                }
            }
            */
            base.Initialize(controllerContext);
        }

        public WebAppLogger Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = WebAppLogger.GetWebAppLogger(ControllerName);
                }
                return logger;
            }
            set { logger = value; }
        }

        public string ControllerName
        {
            get
            {
                //return "Controller";
                return (this.ActionContext.ControllerContext == null) ? "BaseController" : this.ActionContext.ControllerContext.ControllerDescriptor.ControllerName + "Controller";
            }
        }

        public virtual IHttpActionResult Return(object data, Exception ex = null)
        {
            ResultObject result = null;

            if ((ex != null) || (data == null))
                result = Catch(ex, data);
            else
            {
                return Ok(data);
            }

            return Ok(result);
        }

        public ResultObject Catch(Exception ex, object obj)
        {
            var internalEx = GetError(ex);
            //System.Data.SqlClient.SqlException
            var message = internalEx.Message;
            var validationUI = (internalEx is BusinessException) ? (internalEx as BusinessException).Message : null;


            if ((internalEx is System.Data.Entity.Validation.DbEntityValidationException) &&
                (internalEx as System.Data.Entity.Validation.DbEntityValidationException).EntityValidationErrors.Count() > 0)
            {
                message = string.Empty;
                foreach (var error in (internalEx as System.Data.Entity.Validation.DbEntityValidationException).EntityValidationErrors)
                {
                    message += $"Validacion Entidad:{error.Entry.Entity.GetType().Name}{Environment.NewLine}";
                    foreach (var _error in error.ValidationErrors)
                        message += $"{_error.PropertyName}:{_error.ErrorMessage}{Environment.NewLine}";
                }
            }
            ResultObject result = new ResultObject()
            {
                Ok = false,
                Message = message,
                TrazaError = $"Error: {internalEx.ToString()}, Traza:{internalEx.StackTrace}",
                Data = null
            };

            InitValues();

            Logger.Log(ex, obj);

            return result;
        }

        public void InitValues(string MethodName = null, string MethodNameUI = null)
        {            
            Logger.Info.MethodName = string.IsNullOrEmpty(MethodName) ? ActionName : MethodName;
            Logger.Info.MethodNameUI = string.IsNullOrEmpty(MethodName) ? ActionName : MethodName;
        }
        public string ActionName
        {
            get { return this.ActionContext.ActionDescriptor.ActionName; }
        }

        public static Exception GetError(Exception ex, bool esInnerException = false)
        {
            Exception error = null;
            if (ex != null)
            {
                if (ex.InnerException != null)
                    error = GetError(ex.InnerException, true);
                else
                {
                    error = ex;
                    return error;
                }
            }
            return error;
        }

        public static DataTableRequest NvcToDataTablesModel(NameValueCollection nvcrequest)
        {
            DataTableRequest dttrequest = new DataTableRequest();
            SearchDataTable srchdtt = new SearchDataTable();
            SearchDataTable srchcolumn = new SearchDataTable();
            OrderDataTable orderdtt = new OrderDataTable();
            List<ColumnDataTable> columns = new List<ColumnDataTable>();

            int draw = 0;
            int start = 0;
            int length = 0;
            string sSearch = "";
            int numcolumn = 0;
            int columnindice = 0;
            bool columnaOK = true;
            string columnorderablestr = "false";
            bool columnorderable = false;
            string columnsearchablestr = "false";
            bool columnsearchable = false;
            string columnorder = "0";
            var sortcolumn = "0";
            var sortColumnDirection = "desc";

            if (!int.TryParse(nvcrequest["draw"].ToString(), out draw))
                draw = 1;

            if (!int.TryParse(nvcrequest["start"].ToString(), out start))
                start = 0;

            if (!int.TryParse(nvcrequest["length"].ToString(), out length))
                length = 15;

            if (nvcrequest["search[value]"] != null)
                sSearch = nvcrequest["search[value]"].ToString();

            if (nvcrequest["order[0][column]"] != null)
            {
                columnorder = nvcrequest["order[0][column]"].FirstOrDefault().ToString();
                if (!int.TryParse(columnorder, out numcolumn))
                    numcolumn = 0;
            }

            if (nvcrequest["columns[" + columnorder + "][data]"] != null)
                columnorder = "columns[" + columnorder + "][data]";

            if (nvcrequest[columnorder] != null)
                sortcolumn = nvcrequest[columnorder].ToString();

            if (nvcrequest["order[0][dir]"] != null)
                sortColumnDirection = nvcrequest["order[0][dir]"].ToString();

            //arma el arreglo de columnas del datatable
            while (columnaOK)
            {
                columnorder = columnindice.ToString();
                if (nvcrequest["columns[" + columnorder + "][data]"] == null)
                    break;

                ColumnDataTable coldtt = new ColumnDataTable();
                coldtt.data = nvcrequest["columns[" + columnorder + "][data]"].ToString();

                if (nvcrequest["columns[" + columnorder + "][name]"] != null)
                    coldtt.name = nvcrequest["columns[" + columnorder + "][name]"].ToString();

                if (nvcrequest["columns[" + columnorder + "][orderable]"] != null)
                {
                    columnorderablestr = nvcrequest["columns[" + columnorder + "][orderable]"].ToString();
                    if (!bool.TryParse(columnorderablestr, out columnorderable))
                        columnorderable = false;
                }

                coldtt.orderable = columnorderable;

                if (nvcrequest["columns[" + columnorder + "][searchable]"] != null)
                {
                    columnsearchablestr = nvcrequest["columns[" + columnorder + "][searchable]"].ToString();
                    if (!bool.TryParse(columnsearchablestr, out columnsearchable))
                        columnsearchable = false;
                }

                coldtt.searchable = columnsearchable;

                if (nvcrequest["columns[" + columnorder + "][searchable][value]"] != null)
                    srchcolumn.value = nvcrequest["columns[" + columnorder + "][searchable][value]"].ToString();

                coldtt.search = srchcolumn;

                columns.Add(coldtt);
                columnindice++;
            }


            srchdtt.value = sSearch;
            orderdtt.column = numcolumn;
            orderdtt.dir = sortColumnDirection;

            dttrequest.draw = draw;
            dttrequest.start = start;
            dttrequest.length = length;
            dttrequest.search = srchdtt;
            dttrequest.order = orderdtt;
            dttrequest.columns = columns;

            return dttrequest;
        }

    }
}