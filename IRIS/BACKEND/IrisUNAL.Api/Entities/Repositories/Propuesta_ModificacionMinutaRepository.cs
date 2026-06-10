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
    public class Propuesta_ModificacionMinutaRepository : SuperType<Propuesta_ModificacionMinuta>, IPropuesta_ModificacionMinutaRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_ModificacionMinutaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_ModificacionMinutaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_ModificacionMinuta(int id_modificacionminuta)
        {
            Delete(id_modificacionminuta);
            return true;
        }

        public IEnumerable<Propuesta_ModificacionMinuta> GetAllPropuesta_ModificacionMinuta()
        {
            return Get();
        }

        public Propuesta_ModificacionMinuta GetPropuesta_ModificacionMinutaCodigo(string consecutivoremisiondecanatura)
        {
            return Get(c=>c.consecutivoremisiondecanatura == consecutivoremisiondecanatura).FirstOrDefault();
        }

        public Propuesta_ModificacionMinuta GetPropuesta_ModificacionMinutaDetails(int id_modificacionminuta)
        {
            return Get(id_modificacionminuta);
        }

        public bool InsertPropuesta_ModificacionMinuta(Propuesta_ModificacionMinuta propuesta_ModificacionMinuta)
        {
            Add(propuesta_ModificacionMinuta);
            return true;
        }

        public bool UpdatePropuesta_ModificacionMinuta(Propuesta_ModificacionMinuta propuesta_ModificacionMinuta)
        {
            Update(propuesta_ModificacionMinuta);
            return true;
        }

        public DataTableAdapter<Propuesta_ModificacionMinuta> GetDataTablePropuestaModificacionMinutaByPropuesta(int id_propuesta, DataTableRequest model)
        {
            var totalRows = 0; 
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_ModificacionMinuta, bool>> srchByFunc = null;
            Expression<Func<Propuesta_ModificacionMinuta, string>> orderByFunc = null;
            Expression<Func<Propuesta_ModificacionMinuta, DateTime>> orderByDateFunc = null;

            Expression<Func<Propuesta_ModificacionMinuta, object>> parameter1 = m => m.minuta;
            Expression<Func<Propuesta_ModificacionMinuta, object>> parameter2 = m => m.tipoModificacion;
            Expression<Func<Propuesta_ModificacionMinuta, object>>[] parameterArray = new Expression<Func<Propuesta_ModificacionMinuta, object>>[] { parameter1, parameter2 };

            bool isOrderDesc = false;

            //FILTRA POR LA PROPUESTA
            srchByFunc = p => p.id_propuesta == id_propuesta;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_propuesta == id_propuesta && d.descripcionmodificacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            
            if (model.SortColumn.ToLower() == "fecsolmodvol")
                orderByDateFunc = CreateExpressionOrderByDate<Propuesta_ModificacionMinuta>("fecsolmodvol");
            else
                orderByFunc = CreateExpressionOrderBy<Propuesta_ModificacionMinuta>(model.SortColumn);

//            orderByFunc = CreateExpressionOrderBy<Propuesta_ModificacionMinuta>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            var data = (model.SortColumn.ToLower() == "fecsolmodvol") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_ModificacionMinuta> result = new DataTableAdapter<Propuesta_ModificacionMinuta>();

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