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
    public class Propuesta_SuscripcionMinutaRepository : SuperType<Propuesta_SuscripcionMinuta>, IPropuesta_SuscripcionMinutaRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_SuscripcionMinutaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_SuscripcionMinutaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_SuscripcionMinuta(int id_suscripcionminuta)
        {
            Delete(id_suscripcionminuta);
            return true;
        }

        public IEnumerable<Propuesta_SuscripcionMinuta> GetAllPropuesta_SuscripcionMinuta()
        {
            return Get();
        }

        public Propuesta_SuscripcionMinuta GetPropuesta_SuscripcionMinutaDetails(int id_suscripcionminuta)
        {
            return Get(id_suscripcionminuta);
        }

        public Propuesta_SuscripcionMinuta GetPropuesta_SuscripcionMinutaMinuta(string numminuta)
        {
            return Get(c => c.numminuta == numminuta).FirstOrDefault();
        }

        public bool InsertPropuesta_SuscripcionMinuta(Propuesta_SuscripcionMinuta propuesta_SuscripcionMinuta)
        {
            Add(propuesta_SuscripcionMinuta);
            return true;
        }

        public bool UpdatePropuesta_SuscripcionMinuta(Propuesta_SuscripcionMinuta propuesta_SuscripcionMinuta)
        {
            Update(propuesta_SuscripcionMinuta);
            return true;
        }

        public DataTableAdapter<Propuesta_SuscripcionMinuta> GetDataTablePropuestaSuscripcionMinuta(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_SuscripcionMinuta, bool>> srchByFunc = null;
            Expression<Func<Propuesta_SuscripcionMinuta, string>> orderByFunc = null;

            Expression<Func<Propuesta_SuscripcionMinuta, object>> parameter1 = s => s.propuesta;
            Expression<Func<Propuesta_SuscripcionMinuta, object>>[] parameterArray = new Expression<Func<Propuesta_SuscripcionMinuta, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.numminuta.ToLower().Contains(model.SearchValue.ToLower()) || d.nombreminutaproyecto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_SuscripcionMinuta>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;
            
            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_SuscripcionMinuta> result = new DataTableAdapter<Propuesta_SuscripcionMinuta>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public Propuesta_SuscripcionMinuta GetPropuesta_SuscripcionMinutaByPropuesta(int id_propuesta)
        {
            return Get(c => c.id_propuesta == id_propuesta).FirstOrDefault();            
        }
    }
}