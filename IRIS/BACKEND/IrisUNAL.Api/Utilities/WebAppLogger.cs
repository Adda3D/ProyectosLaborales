using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Web;

namespace IrisUNAL.Api.Utilities
{
    public class InfoWebApp
    {
        public InfoWebApp()
        {
            GUID = string.IsNullOrEmpty(GUID) ? System.Guid.NewGuid().ToString() : GUID;
        }
        public string AppName { get; set; }
        public string WebServiceName { get; set; }
        public string MethodName { get; set; }
        public string MethodNameUI { get; set; }
        public string GUID { get; set; }

        public int UserId { get; set; }
        public string User { get; set; }
        public string Token { get; set; }
        public string Imei { get; set; }
    }
    public class WebAppLogger : IDisposable
    {
        string LogFileName = string.Empty;
        string ErrorFileName = string.Empty;
        private ApplicationDbContext _context;
        public InfoWebApp Info { get; set; }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public static WebAppLogger GetWebAppLogger(string webServiceName = "BaseController")
        {
            var s = new InfoWebApp() { AppName = "API_IRIS", WebServiceName = webServiceName };
            var logger = new WebAppLogger(s);
            return logger;
        }

        public WebAppLogger(InfoWebApp infoWebApp = null)
        {
            if (infoWebApp == null)
                infoWebApp = new InfoWebApp() { AppName = "API_IRIS" };

            this.Info = infoWebApp;
            this.CreateFilesName();
        }

        public void Log(string log, bool isError)
        {
            SaveLogDatabase(log, isError);
        }


        public void Log(Exception ex, params object[] entitys)
        {
            try
            {
                SaveLogDatabase(isError: true, ex: ex);
            }
            catch (Exception exx)
            {

            }

        }

        private void SaveLogDatabase(string data = "", bool isError = false, Exception ex = null)
        {
                ApplicationDbContext _context = new ApplicationDbContext();
            LTLogApp newlog = new LTLogApp();

            newlog.type = (isError) ? "Error" : "Log";
            newlog.guid = Guid.NewGuid().ToString();
            newlog.appname = "API_IRIS";
            newlog.webservicename = this.Info.WebServiceName;
            newlog.methodname = this.Info.MethodName;
            newlog.methodnameui = this.Info.MethodName;
            newlog.username = GlobalParams.usuariocontroller;
            //newlog.UserMachineInfo
            newlog.serverip = GetServerIP();
            newlog.data = data;
            newlog.creationdate = DateTime.Now;

            if (ex != null)
            {
                newlog.errormessage = ex.Message;
                newlog.source = ex.Source;
                newlog.method = (ex.TargetSite != null) ? ex.TargetSite.ToString().Replace("`", string.Empty) : string.Empty;
                newlog.errortype = ex.GetType().Name;
                newlog.trace = GetErrorMessage(ex);

                if (ex.GetType().Equals(typeof(DbEntityValidationException)))
                {
                    var dbException = ex as DbEntityValidationException;
                    var errorMessages = dbException.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                    var fullerrorMessage = string.Join("; ", errorMessages);

                    var errordb = string.Concat(ex.ToString(), ". El error de validación es: ", fullerrorMessage);

                    if (errordb.Length > 3999)
                    {
                        newlog.data = errordb.Substring(0, 3999);
                    }
                    else
                    {
                        newlog.data = errordb;
                    }
                }
            }

            _context.ltlogapp.Add(newlog);
            _context.SaveChanges();
        }

        private void LogTXT(Dictionary<string, Object> fieldsValues, bool isError)
        {
            string data = string.Empty;
            data = GetData(fieldsValues);
            SaveLogTXT(data, isError);

        }

        private string GetData(Dictionary<string, Object> fieldsValues)
        {
            string data = Environment.NewLine + "***********************" + DateTime.Now.ToString("ddmmyyyy") + "_" + DateTime.Now.ToString("H:mm:ss") + "*****************************" + Environment.NewLine;
            data += string.Join(Environment.NewLine, fieldsValues.Select(o => string.Format("{0} = {1}", o.Key, (o.Value == null) ? string.Empty : o.Value.ToString()))) + Environment.NewLine;
            data += "*****************************************************************************";
            return data;
        }

        public void CreateFilesName()
        {
            this.LogFileName = string.Empty;
            LogFileName = this.Info.AppName + "_" + LogFileName;

            this.ErrorFileName = string.Empty;
            ErrorFileName = this.Info.AppName + "_" + ErrorFileName;

            LogFileName = "Log_" + LogFileName + DateTime.Now.ToString("dd_MM_yyyy") + "_.txt";
            ErrorFileName = "Error_" + ErrorFileName + DateTime.Now.ToString("dd_MM_yyyy") + "_.txt";
        }

        private void SaveLogTXT(string log, string Pathrchivo)
        {
            using (System.IO.StreamWriter SW = System.IO.File.AppendText(Pathrchivo))
            {
                var today = DateTime.Now.ToString();
                var strlog = today + " " + log;
                SW.WriteLine(strlog);
                SW.Close();
            }
        }

        private void SaveLogTXT(string data, bool isError)
        {
            CreateFilesName();
            var pathArchivo = HttpContext.Current.Server.MapPath("~/Log/" + LogFileName);

            if (isError)
            {
                pathArchivo = HttpContext.Current.Server.MapPath("~/Log/" + ErrorFileName);
            }

            SaveLogTXT(data, pathArchivo);
        }

        private string GetValuesProperties(object objeto)
        {
            string valores = string.Empty;

            if (objeto == null)
            {
                return valores;
            }
            try
            {
                valores = GetValuesInternal(objeto);
                if (!string.IsNullOrEmpty(valores))
                    return valores;

                IEnumerable<PropertyInfo> lstPropiedades = GetFlatProperties(objeto);

                valores += "Tipo Objeto:" + objeto.GetType().Name + " " + Environment.NewLine;


                foreach (PropertyInfo propiedadActual in lstPropiedades)
                {
                    try
                    {
                        object valor = propiedadActual.GetValue(objeto, null);

                        if (valor == null)
                            valor = string.Empty;
                        else
                        {
                            var valortemp = GetValuesInternal(valor);
                            if (!string.IsNullOrEmpty(valortemp))
                                valor = valortemp;
                            else if (valor != null &&
                                (valor.GetType().Name.Equals("QueryListConfig") ||
                                valor.GetType().Name.Equals("DocumentInfo") ||
                                valor.GetType().Name.Equals("TemplateInfo") ||
                                valor.GetType().Name.Equals("EmailInfo")))
                                valor = GetValuesProperties(valor);
                        }
                        valores += propiedadActual.Name + ":" + valor.ToString() + Environment.NewLine;

                    }

                    catch (Exception ex)
                    {


                    }

                }

            }
            catch (Exception ex)
            {


            }
            return valores;
        }

        private string GetValuesInternal(object objeto)
        {
            string valores = string.Empty;
            if (objeto == null)
            {
                return string.Empty;
            }
            if (objeto is Dictionary<string, object>)
                return ConvertDictonaryToString((objeto as Dictionary<string, object>));
            if (objeto is List<Dictionary<string, object>>)
            {

                foreach (var dir in (objeto as List<Dictionary<string, object>>))
                    valores += ConvertDictonaryToString(dir);
                return valores;
            }

            else if (objeto is List<string>)
            {
                valores += string.Join(Environment.NewLine, (objeto as List<string>)) + " [" + objeto.GetType().Name + "]";
                return valores;
            }

            else if (objeto is String || objeto is DateTime || objeto.GetType().IsPrimitive || objeto is Enum)
            {
                if (!string.IsNullOrEmpty(objeto.ToString()))
                    valores += objeto.ToString() + " [" + objeto.GetType().Name + "]";
            }
            return valores;
        }

        private IEnumerable<PropertyInfo> GetFlatProperties(object entidad)
        {
            IEnumerable<PropertyInfo> lstPropiedades = entidad.GetType().GetProperties(System.Reflection.BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => !p.PropertyType.Name.Contains("EntityCollection`1") &&
                      !p.PropertyType.Name.Contains("EntityReference`1") &&
                      !p.PropertyType.Name.Contains("ICollection`1") &&
                      !p.PropertyType.Name.Contains("IEnumerable`1") &&
                      !p.PropertyType.Name.Contains("IList`1") &&
                      !p.PropertyType.Name.Contains("List`1"));

            return lstPropiedades;
        }

        private static string ConvertDictonaryToString(Dictionary<string, object> dir)
        {

            string valores = string.Empty;
            foreach (KeyValuePair<string, object> pairs in dir)
            {

                valores += pairs.Key + ":" + ((pairs.Value == null) ? string.Empty : (pairs.Value is Dictionary<string, object>) ? ConvertDictonaryToString(pairs.Value as Dictionary<string, object>) : pairs.Value.ToString()) + Environment.NewLine;
            }
            return valores;
        }

        private Dictionary<string, Object> GetfieldsValues(Exception ex, string dataObject)
        {


            Dictionary<string, Object> fieldsValues = GetBasicInfo(true);
            fieldsValues.Add("Data", (!string.IsNullOrEmpty(dataObject) ? dataObject.Replace("`", string.Empty) : string.Empty));

            fieldsValues.Add("ErrorMessage", ex.Message);
            fieldsValues.Add("Source", ex.Source);
            fieldsValues.Add("Method", (ex.TargetSite != null) ? ex.TargetSite.ToString().Replace("`", string.Empty) : string.Empty);
            fieldsValues.Add("ErrorType", ex.GetType().Name);
            fieldsValues.Add("Trace", GetErrorMessage(ex));

            return fieldsValues;
        }

        private static string GetErrorMessage(Exception ex, bool esInnerException = false)
        {
            string strMessage = string.Empty;
            if (ex != null)
            {
                //if (!esInnerException)
                //   strMessage += "-------------ERROR: " + DateTime.Now.ToString("ddmmyyyy") + "_" + DateTime.Now.ToString("H:mm:ss") + "----------------" + Environment.NewLine;
                if (ex.InnerException != null)
                {
                    strMessage += GetErrorMessage(ex.InnerException, true);
                }

                if (esInnerException)
                    strMessage += "****************** InnerException ******************************" + Environment.NewLine;
                strMessage += (esInnerException) ? "Message de InnerException: " + Environment.NewLine : "Message de Error: " + Environment.NewLine;
                strMessage += ex.Message + Environment.NewLine;
                strMessage += "Tipo : " + ex.GetType().Name + Environment.NewLine;
                strMessage += "Source : " + ex.Source + Environment.NewLine;
                strMessage += "Method : " + ex.TargetSite + Environment.NewLine;
                strMessage += "Trace : " + ((string.IsNullOrEmpty(ex.StackTrace) ? string.Empty + Environment.NewLine : ex.StackTrace.Replace("`", string.Empty) + Environment.NewLine + ex.ToString().Replace("`", string.Empty) + Environment.NewLine));
                if (!esInnerException)
                    strMessage += Environment.NewLine;// "****************************************************************************************";

            }

            if (strMessage.Length > 3999)
            {
                strMessage = strMessage.Substring(0, 3999);
            }

            return strMessage;
        }

        private Dictionary<string, Object> GetBasicInfo(bool isError)
        {

            Dictionary<string, Object> fieldsValues = new Dictionary<string, object>();

            fieldsValues.Add("Type", (isError) ? "Error" : "Log");
            //fieldsValues.Add("GUID", this.Info.GUID);
            fieldsValues.Add("AppName", "API_Dactiloscopia");
            //fieldsValues.Add("WebServiceName", this.Info.WebServiceName);
            //fieldsValues.Add("MethodName", this.Info.MethodName);
            //fieldsValues.Add("MethodNameUI", this.Info.MethodNameUI);
            //fieldsValues.Add("UserName", this.Info.UserName);
            //fieldsValues.Add("UserMachineInfo", Utility.GetUserMachineInfo());
            fieldsValues.Add("ServerIP", GetServerIP());

            return fieldsValues;

        }

        public static string GetServerIP()
        {
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress address in ipHostInfo.AddressList)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                        return address.ToString();
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }

    }


}