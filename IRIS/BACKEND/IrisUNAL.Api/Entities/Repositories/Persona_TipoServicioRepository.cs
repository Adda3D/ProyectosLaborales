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
    public class Persona_TipoServicioRepository : SuperType<Persona_TipoServicio>, IPersona_TipoServicioRepository
    {
        private ApplicationDbContext _context;

        public Persona_TipoServicioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Persona_TipoServicioRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePersona_TipoServicio(int id_tiposervicio)
        {
            Delete(id_tiposervicio);
            return true;            
        }

        public IEnumerable<Persona_TipoServicio> GetAllPersona_TipoServicio()
        {
            return Get();            
        }

        public Persona_TipoServicio GetPersona_TipoServicioDetails(int id_tiposervicio)
        {
            return Get(id_tiposervicio);            
        }

        public Persona_TipoServicio GetPersona_TipoServicioNombre(string cd_nmtiposerv)
        {
            return Get(c=>c.nmtiposerv==cd_nmtiposerv).FirstOrDefault();            
        }

        public bool InsertPersona_TipoServicio(Persona_TipoServicio persona_TipoServicio)
        {
            Add(persona_TipoServicio);
            return true;            
        }

        public bool UpdatePersona_TipoServicio(Persona_TipoServicio persona_TipoServicio)
        {
            Update(persona_TipoServicio);
            return true;            
        }
        DataTableAdapter<Persona_TipoServicio> IPersona_TipoServicioRepository.GetDataTablePersona_TipoServicio(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Persona_TipoServicio, bool>> srchByFunc = null;
            Expression<Func<Persona_TipoServicio, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtiposerv.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Persona_TipoServicio>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Persona_TipoServicio> result = new DataTableAdapter<Persona_TipoServicio>();

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