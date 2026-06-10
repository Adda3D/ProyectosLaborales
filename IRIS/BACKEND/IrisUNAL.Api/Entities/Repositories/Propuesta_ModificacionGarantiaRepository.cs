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
    public class Propuesta_ModificacionGarantiaRepository : SuperType<Propuesta_ModificacionGarantia>, IPropuesta_ModificacionGarantiaRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_ModificacionGarantiaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_ModificacionGarantiaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_ModificacionGarantia(int id_modificaciongarantia)
        {
            Delete(id_modificaciongarantia);
            return true;
        }

        public IEnumerable<Propuesta_ModificacionGarantia> GetAllPropuesta_ModificacionGarantia()
        {
            return Get();
        }

        public Propuesta_ModificacionGarantia GetPropuesta_ModificacionGarantiaDetails(int id_modificaciongarantia)
        {
            return Get(id_modificaciongarantia);
        }

        public Propuesta_ModificacionGarantia GetPropuesta_ModificacionGarantiaPoliza(int id_suscripciongarantia)
        {
            return Get(c=>c.id_suscripciongarantia == id_suscripciongarantia).FirstOrDefault();
        }

        public bool InsertPropuesta_ModificacionGarantia(Propuesta_ModificacionGarantia propuesta_ModificacionGarantia)
        {
            Add(propuesta_ModificacionGarantia);
            return true;
        }

        public bool UpdatePropuesta_ModificacionGarantia(Propuesta_ModificacionGarantia propuesta_ModificacionGarantia)
        {
            Update(propuesta_ModificacionGarantia);
            return true;
        }

        public DataTableAdapter<Propuesta_ModificacionGarantia> GetDataTablePropuestaModificacionGarantiaByGarantia(int id_suscripciongarantia, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_ModificacionGarantia, bool>> srchByFunc = null;
            Expression<Func<Propuesta_ModificacionGarantia, string>> orderByFunc = null;
            Expression<Func<Propuesta_ModificacionGarantia, DateTime>> orderByDateFunc = null;

            //Expression<Func<Propuesta_ModificacionGarantia, object>> parameter1 = m => m.minuta;
            Expression<Func<Propuesta_ModificacionGarantia, object>> parameter2 = m => m.tipoModificacion;
            Expression<Func<Propuesta_ModificacionGarantia, object>>[] parameterArray = new Expression<Func<Propuesta_ModificacionGarantia, object>>[] { parameter2 };

            bool isOrderDesc = false;

            //FILTRA POR LA PROPUESTA
            srchByFunc = p => p.id_suscripciongarantia == id_suscripciongarantia;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_suscripciongarantia == id_suscripciongarantia && d.descripcion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            if (model.SortColumn.ToLower() == "fecsolicitud")
                orderByDateFunc = CreateExpressionOrderByDate<Propuesta_ModificacionGarantia>("fecsolicitud");
            else
                orderByFunc = CreateExpressionOrderBy<Propuesta_ModificacionGarantia>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fecsolicitud") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_ModificacionGarantia> result = new DataTableAdapter<Propuesta_ModificacionGarantia>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Propuesta_ModificacionGarantia> GetDataTablePropuestaModificacionGarantiaByPropuesta(int id_propuesta, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_ModificacionGarantia, bool>> srchByFunc = null;
            Expression<Func<Propuesta_ModificacionGarantia, string>> orderByFunc = null;
            Expression<Func<Propuesta_ModificacionGarantia, DateTime>> orderByDateFunc = null;

            //Expression<Func<Propuesta_ModificacionGarantia, object>> parameter1 = m => m.minuta;
            Expression<Func<Propuesta_ModificacionGarantia, object>> parameter2 = m => m.tipoModificacion;
            Expression<Func<Propuesta_ModificacionGarantia, object>>[] parameterArray = new Expression<Func<Propuesta_ModificacionGarantia, object>>[] { parameter2 };

            bool isOrderDesc = false;

            //FILTRA POR LA PROPUESTA
            srchByFunc = p => p.id_propuesta == id_propuesta;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_propuesta == id_propuesta && d.descripcion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            if (model.SortColumn.ToLower() == "fecsolicitud")
                orderByDateFunc = CreateExpressionOrderByDate<Propuesta_ModificacionGarantia>("fecsolicitud");
            else
                orderByFunc = CreateExpressionOrderBy<Propuesta_ModificacionGarantia>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fecsolicitud") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_ModificacionGarantia> result = new DataTableAdapter<Propuesta_ModificacionGarantia>();

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