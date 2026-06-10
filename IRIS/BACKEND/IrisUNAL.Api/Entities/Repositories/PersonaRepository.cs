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
    public class PersonaRepository : SuperType<Persona>, IPersonaRepository
    {
        private ApplicationDbContext _context;

        public PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PersonaRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeletePersona(int id_persona)
        {
            Delete(id_persona);
            return true;            
        }

        public IEnumerable<Persona> GetAllPersona()
        {
            return Get();            
        }

        public Persona GetPersonaDetails(int id_persona)
        {
            return Get(id_persona);            
        }

        public Persona GetPersonaIdentificacion(string cd_numidentificacion)
        {
            return Get(c=>c.numidentificacion==cd_numidentificacion).FirstOrDefault();
        }

        public bool InsertPersona(Persona persona)
        {
            Add(persona);
            return true;
        }

        public bool UpdatePersona(Persona persona)
        {
            Update(persona);
            return true;            
        }

        public DataTableAdapter<Persona> GetDataTablePersona(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Persona, bool>> srchByFunc = null;
            Expression<Func<Persona, string>> orderByFunc = null;

            //Expression<Func<Persona, object>> parameter1 = d => d.areaacademica;
            //Expression<Func<Persona, object>>[] parameterArray = new Expression<Func<Persona, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nombrecompleto.ToLower().Contains(model.SearchValue.ToLower()) || d.telefono.ToLower().Contains(model.SearchValue.ToLower()) || d.celular.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Persona>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Persona> result = new DataTableAdapter<Persona>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public IEnumerable<Persona> GetAllPersonaEvaluador()
        {
            return Get(p => p.evaluadorpublicacion);
        }
    }
}