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
    public class Propuesta_CoberturaRepository : SuperType<Propuesta_Cobertura>, IPropuesta_CoberturaRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_CoberturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_CoberturaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_Cobertura(int id_cobertura)
        {
            Delete(id_cobertura);
            return true;
        }

        public IEnumerable<Propuesta_Cobertura> GetAllPropuesta_Cobertura()
        {
            return Get();
        }

        public Propuesta_Cobertura GetPropuesta_CoberturaDetails(int id_cobertura)
        {
            return Get(id_cobertura);
        }

        public Propuesta_Cobertura GetPropuesta_CoberturaDetails(string cd_nmcobertura)
        {
            return Get(c=>c.nmcobertura==cd_nmcobertura).FirstOrDefault();
        }

        public bool InsertPropuesta_Cobertura(Propuesta_Cobertura propuesta_Cobertura)
        {
            Add(propuesta_Cobertura);
            return true;
        }

        public bool UpdatePropuesta_Cobertura(Propuesta_Cobertura propuesta_Cobertura)
        {
            Update(propuesta_Cobertura);
            return true;
        }

        public DataTableAdapter<Propuesta_Cobertura> GetDataTablePropuestaCobertura(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_Cobertura, bool>> srchByFunc = null;
            Expression<Func<Propuesta_Cobertura, string>> orderByFunc = null;

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmcobertura.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_Cobertura>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_Cobertura> result = new DataTableAdapter<Propuesta_Cobertura>();

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