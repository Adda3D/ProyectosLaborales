using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class PropuestaRepository : SuperType<Propuesta>, IPropuestaRepository
    {
        private ApplicationDbContext _context;

        public PropuestaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PropuestaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta(int id_propuesta)
        {
            Delete(id_propuesta);
            return true;
        }

        public IEnumerable<Propuesta> GetAllPropuesta()
        {
            return Get();
        }

        public Propuesta GetPropuestaDetails(int id_propuesta)
        {
            return Get(id_propuesta);
        }

        public Propuesta GetPropuestaNumero(string cd_numeropropuesta)
        {
            return Get(c => c.consecutivooferta == cd_numeropropuesta).FirstOrDefault();
        }

        public bool InsertPropuesta(Propuesta propuesta)
        {
            Add(propuesta);
            return true;
        }

        public bool UpdatePropuesta(Propuesta propuesta)
        {
            Update(propuesta);
            return true;
        }

        public DataTableAdapter<Propuesta> GetDataTablePropuesta(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta, bool>> srchByFunc = null;
            Expression<Func<Propuesta, string>> orderByFunc = null;
            Expression<Func<Propuesta, DateTime>> orderByDateFunc = null;
            Expression<Func<Propuesta, int>> orderByIntFunc = null;

            Expression<Func<Propuesta, object>> parameter1 = p => p.funcionario;
            Expression<Func<Propuesta, object>> parameter2 = p => p.contratante;
            Expression<Func<Propuesta, object>> parameter3 = p => p.estado;
            Expression<Func<Propuesta, object>> parameter4 = p => p.ObjTipoPropuesta;
            Expression<Func<Propuesta, object>>[] parameterArray = new Expression<Func<Propuesta, object>>[] { parameter1, parameter2, parameter3, parameter4 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.consecutivooferta.ToLower().Contains(model.SearchValue.ToLower()) || d.nmpropuesta.ToLower().Contains(model.SearchValue.ToLower()); /* || d.nombreestado.ToLower().Contains(model.SearchValue.ToLower()); */
                RowsFiltered = CountFiltered(srchByFunc);
            }

            var columsort = (model.SortColumn.ToLower() == "nmpropuestadt") ? "nmpropuesta" : model.SortColumn.ToLower();

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;
            
            switch (columsort) {
                case "strfecrad":
                    orderByDateFunc = CreateExpressionOrderByDate<Propuesta>("fecrad");
                    break;
                case "nombreestado":
                    orderByIntFunc = CreateExpressionOrderByInt<Propuesta>("id_estadopropuesta");
                    break;
                case "id_propuesta":
                    orderByIntFunc = CreateExpressionOrderByInt<Propuesta>("id_propuesta");
                    break;
                default:
                    orderByFunc = CreateExpressionOrderBy<Propuesta>(model.SortColumn);
                    break;
            }

            var data = (model.SortColumn.ToLower() == "strfecrad")? 
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                (model.SortColumn.ToLower() == "nombreestado") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList() :
                (model.SortColumn.ToLower() == "id_propuesta") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();


            /*var data = (model.SortColumn.ToLower() == "strfecrad") ? 
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                (model.SortColumn.ToLower() == "id_propuesta") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList()  :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();*/

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta> result = new DataTableAdapter<Propuesta>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public Propuesta GetPropuestaConsecutivo(string consecutivo)
        {
            return Get(c => c.consecutivooferta == consecutivo).FirstOrDefault();
        }

    }
}