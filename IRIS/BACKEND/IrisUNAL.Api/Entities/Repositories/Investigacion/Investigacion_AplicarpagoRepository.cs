using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Investigacion;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Investigacion
{
    public class Investigacion_AplicarpagoRepository : SuperType<Investigacion_Aplicarpago>
    {
        private ApplicationDbContext _context;

        public Investigacion_AplicarpagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_AplicarpagoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteInvestigacion_Aplicarpago(int id_investigacionpago)
        {
            Delete(id_investigacionpago);
            return true;
        }

        public IEnumerable<Investigacion_Aplicarpago> GetAllInvestigacion_Aplicarpago()
        {
            return Get();
        }

        public Investigacion_Aplicarpago GetInvestigacion_AplicarpagoDetails(int id_investigacionpago)
        {
            return Get(id_investigacionpago);
        }

        public bool InsertInvestigacion_Aplicarpago(Investigacion_Aplicarpago _investigacion_aplicarpago)
        {
            Add(_investigacion_aplicarpago);
            return true;
        }

        public bool UpdateInvestigacion_Aplicarpago(Investigacion_Aplicarpago _investigacion_aplicarpago)
        {
            Update(_investigacion_aplicarpago);
            return true;
        }

        public DataTableAdapter<Investigacion_Aplicarpago> GetDataTablePagosByInvestigacionGasto(int id_investigaciongasto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_Aplicarpago, bool>> srchByFunc = null;
            Expression<Func<Investigacion_Aplicarpago, string>> orderByFunc = null;
            Expression<Func<Investigacion_Aplicarpago, DateTime>> orderByDateFunc = null;

            Expression<Func<Investigacion_Aplicarpago, object>> parameter1 = m => m.ObjSemestre;
            //Expression<Func<Investigacion_Aplicarpago, object>> parameter2 = m => m.objConcepto;
            Expression<Func<Investigacion_Aplicarpago, object>>[] parameterArray = new Expression<Func<Investigacion_Aplicarpago, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechapago")
                orderByDateFunc = CreateExpressionOrderByDate<Investigacion_Aplicarpago>("fechapago");
            else
                orderByFunc = CreateExpressionOrderBy<Investigacion_Aplicarpago>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_investigaciongasto == id_investigaciongasto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_investigaciongasto == id_investigaciongasto && d.orpa.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            var data = (model.SortColumn.ToLower() == "fechapago") ?
                Get(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc).ToList() :
                Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_Aplicarpago> result = new DataTableAdapter<Investigacion_Aplicarpago>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Investigacion_Aplicarpago> GetDataTableInvestigacion_AplicarpagoByProyecto(int id_crearproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_Aplicarpago, bool>> srchByFunc = null;
            Expression<Func<Investigacion_Aplicarpago, string>> orderByFunc = null;
            Expression<Func<Investigacion_Aplicarpago, DateTime>> orderByDateFunc = null;

            Expression<Func<Investigacion_Aplicarpago, object>> parameter1 = m => m.ObjGasto;
            Expression<Func<Investigacion_Aplicarpago, object>> parameter2 = m => m.ObjGasto.ObjPersona;
            Expression<Func<Investigacion_Aplicarpago, object>> parameter3 = m => m.ObjGasto.ObjRubro;
            Expression<Func<Investigacion_Aplicarpago, object>> parameter4 = m => m.ObjGasto.ObjConcepto;
            Expression<Func<Investigacion_Aplicarpago, object>>[] parameterArray = new Expression<Func<Investigacion_Aplicarpago, object>>[] { parameter1, parameter2, parameter3, parameter4 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechapago")
                orderByDateFunc = CreateExpressionOrderByDate<Investigacion_Aplicarpago>("fechapago");
            else
                orderByFunc = CreateExpressionOrderBy<Investigacion_Aplicarpago>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_crearproyecto == id_crearproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearproyecto == id_crearproyecto && d.orpa.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fechapago") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();


            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_Aplicarpago> result = new DataTableAdapter<Investigacion_Aplicarpago>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }
    }
}