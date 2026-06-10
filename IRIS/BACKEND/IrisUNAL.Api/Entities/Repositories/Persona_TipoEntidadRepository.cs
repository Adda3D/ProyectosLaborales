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
    public class Persona_TipoEntidadRepository : SuperType<Persona_TipoEntidad>, IPersona_TipoEntidadRepository
    {
        private ApplicationDbContext _context;

        public Persona_TipoEntidadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Persona_TipoEntidadRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePersona_TipoEntidad(int id_tipoentidad)
        {
            Delete(id_tipoentidad);
            return true;
        }

        public IEnumerable<Persona_TipoEntidad> GetAllPersona_TipoEntidad()
        {
            return Get();            
        }

        public Persona_TipoEntidad GetPersona_TipoEntidadDetails(int id_tipoentidad)
        {
            return Get(id_tipoentidad);            
        }

        public Persona_TipoEntidad GetPersona_TipoEntidadNombre(string cd_nmtipoent)
        {
            return Get(c =>c.nmtipoent==cd_nmtipoent).FirstOrDefault();            
        }

        public bool InsertPersona_TipoEntidad(Persona_TipoEntidad persona_TipoEntidad)
        {
            Add(persona_TipoEntidad);
            return true;            
        }

        public bool UpdatePersona_TipoEntidad(Persona_TipoEntidad persona_TipoEntidad)
        {
            Update(persona_TipoEntidad);
            return true;            
        }
        DataTableAdapter<Persona_TipoEntidad> IPersona_TipoEntidadRepository.GetDataTablePersona_TipoEntidad(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Persona_TipoEntidad, bool>> srchByFunc = null;
            Expression<Func<Persona_TipoEntidad, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipoent.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Persona_TipoEntidad>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Persona_TipoEntidad> result = new DataTableAdapter<Persona_TipoEntidad>();

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