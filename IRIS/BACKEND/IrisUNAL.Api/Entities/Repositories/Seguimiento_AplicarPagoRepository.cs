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

    public class Seguimiento_AplicarPagoRepository : SuperType<Seguimiento_AplicarPago>, ISeguimiento_AplicarPagoRepository
    {
        private ApplicationDbContext _context;

        public Seguimiento_AplicarPagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_AplicarPagoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimiento_AplicarPago(int id_aplicarpago)
        {
            Delete(id_aplicarpago);
            return true;
        }

        public IEnumerable<Seguimiento_AplicarPago> GetAllSeguimiento_AplicarPago()
        {
            return Get();
        }

        public Seguimiento_AplicarPago GetSeguimiento_AplicarPagoDetails(int id_aplicarpago)
        {
            return Get(id_aplicarpago);
        }

        public bool InsertSeguimiento_AplicarPago(Seguimiento_AplicarPago seguimiento_AplicarPago)
        {
            Add(seguimiento_AplicarPago);
            return true;
        }

        public bool UpdateSeguimiento_AplicarPago(Seguimiento_AplicarPago seguimiento_AplicarPago)
        {
            Update (seguimiento_AplicarPago);
            return true;
        }

        public DataTableAdapter<Seguimiento_AplicarPago> GetDataTablePagosByGastoProyecto(int id_creargasto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Seguimiento_AplicarPago, bool>> srchByFunc = null;
            Expression<Func<Seguimiento_AplicarPago, string>> orderByFunc = null;
            Expression<Func<Seguimiento_AplicarPago, DateTime>> orderByDateFunc = null;

            Expression<Func<Seguimiento_AplicarPago, object>> parameter1 = m => m.ObjSemestre;
            //Expression<Func<Seguimiento_AplicarPago, object>> parameter2 = m => m.objConcepto;
            Expression<Func<Seguimiento_AplicarPago, object>>[] parameterArray = new Expression<Func<Seguimiento_AplicarPago, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fecha")
                orderByDateFunc = CreateExpressionOrderByDate<Seguimiento_AplicarPago>("fecha");
            else
                orderByFunc = CreateExpressionOrderBy<Seguimiento_AplicarPago>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_creargasto == id_creargasto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_creargasto == id_creargasto && d.orpa.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            var data = (model.SortColumn.ToLower() == "fecha") ?
                Get(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc).ToList() :
                Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Seguimiento_AplicarPago> result = new DataTableAdapter<Seguimiento_AplicarPago>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Seguimiento_AplicarPago> GetDataTablePagosByProyecto(int id_asignacionproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Seguimiento_AplicarPago, bool>> srchByFunc = null;
            Expression<Func<Seguimiento_AplicarPago, string>> orderByFunc = null;
            Expression<Func<Seguimiento_AplicarPago, DateTime>> orderByDateFunc = null;

            Expression<Func<Seguimiento_AplicarPago, object>> parameter1 = m => m.ObjSemestre;
            Expression<Func<Seguimiento_AplicarPago, object>> parameter2 = m => m.ObjGasto.objPersona;
            Expression<Func<Seguimiento_AplicarPago, object>> parameter3 = m => m.ObjGasto.ObjRubro;
            Expression<Func<Seguimiento_AplicarPago, object>> parameter4 = m => m.ObjGasto.objConcepto;
            Expression<Func<Seguimiento_AplicarPago, object>>[] parameterArray = new Expression<Func<Seguimiento_AplicarPago, object>>[] { parameter1, parameter2, parameter3, parameter4 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fecha")
                orderByDateFunc = CreateExpressionOrderByDate<Seguimiento_AplicarPago>("fecha");
            else
                orderByFunc = CreateExpressionOrderBy<Seguimiento_AplicarPago>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_asignacionproyecto == id_asignacionproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_asignacionproyecto == id_asignacionproyecto && d.orpa.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            var data = (model.SortColumn.ToLower() == "fecha") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Seguimiento_AplicarPago> result = new DataTableAdapter<Seguimiento_AplicarPago>();

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