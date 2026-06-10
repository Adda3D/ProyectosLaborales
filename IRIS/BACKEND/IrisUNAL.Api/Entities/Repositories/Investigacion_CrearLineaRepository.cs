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
    public class Investigacion_CrearLineaRepository : SuperType<Investigacion_CrearLinea>, IInvestigacion_CrearLineaRepository
    {
        private ApplicationDbContext _context;

        public Investigacion_CrearLineaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_CrearLineaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteInvestigacion_CrearLinea(int id_crearlinea)
        {
            Delete(id_crearlinea);
            return true;
        }

        public IEnumerable<Investigacion_CrearLinea> GetAllInvestigacion_CrearLinea()
        {
            return Get();
        }

        public Investigacion_CrearLinea GetInvestigacion_CrearLineaNombre(string cd_linea)
        {
            return Get(c => c.linea == cd_linea).FirstOrDefault();
        }

        public Investigacion_CrearLinea GetInvestigacion_CrearLineaDetails(int id_crearlinea)
        {
            return Get(id_crearlinea);
        }

        public bool InsertInvestigacion_CrearLinea(Investigacion_CrearLinea investigacion_CrearLinea)
        {
            Add(investigacion_CrearLinea);
            return true;
        }

        public bool UpdateInvestigacion_CrearLinea(Investigacion_CrearLinea investigacion_CrearLinea)
        {
            Update(investigacion_CrearLinea);
            return true;
        }
        DataTableAdapter<Investigacion_CrearLinea> IInvestigacion_CrearLineaRepository.GetDataTableInvestigacion_CrearLinea(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_CrearLinea, bool>> srchByFunc = null;
            Expression<Func<Investigacion_CrearLinea, string>> orderByFunc = null;

            Expression<Func<Investigacion_CrearLinea, object>> parameter1 = d => d.grupoinvestigacion;            
            Expression<Func<Investigacion_CrearLinea, object>>[] parameterArray = new Expression<Func<Investigacion_CrearLinea, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.linea.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Investigacion_CrearLinea>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_CrearLinea> result = new DataTableAdapter<Investigacion_CrearLinea>();

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