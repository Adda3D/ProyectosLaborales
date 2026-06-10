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
    public class Tipo_PersonaRepository : SuperType<Tipo_Persona>, ITipo_PersonaRepository
    {
        private ApplicationDbContext _context;

        public Tipo_PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tipo_PersonaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteTipo_Persona(int id_tipopersona)
        {
            Delete(id_tipopersona);

            return true;
        }
        public IEnumerable<Tipo_Persona> GetAllTipo_Persona()
        {
            return Get();
        }
        public Tipo_Persona GetTipo_PersonaDetails(int id_tipopersona)
        {
            return Get(id_tipopersona);
        }
        public Tipo_Persona GetTipo_PersonaNombre(string cd_nmtipoper)
        {
            return Get(c => c.nmtipoper == cd_nmtipoper).FirstOrDefault();
        }
        public bool InsertTipo_Persona(Tipo_Persona tipo_Persona)
        {

            Add(tipo_Persona);

            return true;
        }
        public bool UpdateTipo_Persona(Tipo_Persona tipo_Persona)
        {
            Update(tipo_Persona);

            return true;

        }
        DataTableAdapter<Tipo_Persona> ITipo_PersonaRepository.GetDataTableTipo_Persona(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Tipo_Persona, bool>> srchByFunc = null;
            Expression<Func<Tipo_Persona, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipoper.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Tipo_Persona>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Tipo_Persona> result = new DataTableAdapter<Tipo_Persona>();

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