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
    public class Investigacion_SeguimientoRepository : SuperType<Investigacion_Seguimiento>, IInvestigacion_SeguimientoRepository
    {
        private ApplicationDbContext _context;

        public Investigacion_SeguimientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_SeguimientoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteInvestigacion_Seguimiento(int id_seguimiento)
        {
            Delete(id_seguimiento);
            return true;
        }

        public IEnumerable<Investigacion_Seguimiento> GetAllInvestigacion_Seguimiento()
        {
            return Get();
        }

        public Investigacion_Seguimiento GetInvestigacion_SeguimientoDescripcion(string cd_seguimiento)
        {
            return Get(c => c.seguimiento == cd_seguimiento).FirstOrDefault();
        }

        public Investigacion_Seguimiento GetInvestigacion_SeguimientoDetails(int id_seguimiento)
        {
            return Get(id_seguimiento);
        }

        public bool InsertInvestigacion_Seguimiento(Investigacion_Seguimiento investigacion_Seguimiento)
        {
            Add(investigacion_Seguimiento);
            return true;
        }

        public bool UpdateInvestigacion_Seguimiento(Investigacion_Seguimiento investigacion_Seguimiento)
        {
            Update(investigacion_Seguimiento);
            return true;
        }
        public DataTableAdapter<Investigacion_Seguimiento> GetDataTableInvestigacion_Seguimiento(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_Seguimiento, bool>> srchByFunc = null;
            Expression<Func<Investigacion_Seguimiento, string>> orderByFunc = null;

            Expression<Func<Investigacion_Seguimiento, object>> parameter1 = d => d.crearProyecto;
            Expression<Func<Investigacion_Seguimiento, object>>[] parameterArray = new Expression<Func<Investigacion_Seguimiento, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.seguimiento.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Investigacion_Seguimiento>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_Seguimiento> result = new DataTableAdapter<Investigacion_Seguimiento>();

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