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
    public class Persona_FormacionRepository : SuperType<Persona_Formacion>, IPersona_FormacionRepository
    {
        private ApplicationDbContext _context;

        public Persona_FormacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Persona_FormacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePersona_Formacion(int id_formacion)
        {
            Delete(id_formacion);

            return true;
        }

        public IEnumerable<Persona_Formacion> GetAllPersona_Formacion()
        {
            return Get();
        }

        public Persona_Formacion GetPersona_FormacionDetails(int id_formacion)
        {
            return Get(id_formacion);
        }

        public Persona_Formacion GetPersona_FormacionDetails(string cd_nmformacion)
        {
            return Get(c => c.nmformacion == cd_nmformacion).FirstOrDefault();
        }

        public bool InsertPersona_Formacion(Persona_Formacion persona_Formacion)
        {

            Add(persona_Formacion);

            return true;
        }

        public bool UpdatePersona_Formacion(Persona_Formacion persona_Formacion)
        {
            Update(persona_Formacion);

            return true;

        }
        DataTableAdapter<Persona_Formacion> IPersona_FormacionRepository.GetDataTablePersona_Formacion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Persona_Formacion, bool>> srchByFunc = null;
            Expression<Func<Persona_Formacion, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmformacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Persona_Formacion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Persona_Formacion> result = new DataTableAdapter<Persona_Formacion>();

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