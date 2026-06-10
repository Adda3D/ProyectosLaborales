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
    public class Persona_TituloAltoRepository : SuperType<Persona_TituloAlto>, IPersona_TituloAltoRepository
    {
        private ApplicationDbContext _context;

        public Persona_TituloAltoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Persona_TituloAltoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePersona_TituloAlto(int id_tituloalto)
        {
            Delete(id_tituloalto);
            return true;            
        }

        public IEnumerable<Persona_TituloAlto> GetAllPersona_TituloAlto()
        {
            return Get();            
        }

        public Persona_TituloAlto GetPersona_TituloAltoDetails(int id_tituloalto)
        {
            return Get(id_tituloalto);            
        }

        public Persona_TituloAlto GetPersona_TituloAltoDetails(string cd_nmtituloalto)
        {
            return Get(c=>c.nmtituloalto==cd_nmtituloalto).FirstOrDefault();            
        }

        public bool InsertPersona_TituloAlto(Persona_TituloAlto persona_TituloAlto)
        {
            Add(persona_TituloAlto);
            return true;            
        }

        public bool UpdatePersona_TituloAlto(Persona_TituloAlto persona_TituloAlto)
        {
            Update(persona_TituloAlto);
            return true;            
        }
        DataTableAdapter<Persona_TituloAlto> IPersona_TituloAltoRepository.GetDataTablePersona_TituloAlto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Persona_TituloAlto, bool>> srchByFunc = null;
            Expression<Func<Persona_TituloAlto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtituloalto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Persona_TituloAlto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Persona_TituloAlto> result = new DataTableAdapter<Persona_TituloAlto>();

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