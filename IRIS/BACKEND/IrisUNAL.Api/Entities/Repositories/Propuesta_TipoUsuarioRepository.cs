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
    public class Propuesta_TipoUsuarioRepository : SuperType<Propuesta_TipoUsuario>, IPropuesta_TipoUsuarioRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_TipoUsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_TipoUsuarioRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_TipoUsuario(int id_propuestatipousuario)
        {
            Delete(id_propuestatipousuario);
            return true;
        }

        public IEnumerable<Propuesta_TipoUsuario> GetAllPropuesta_TipoUsuario()
        {
            return Get();
        }

        public Propuesta_TipoUsuario GetPropuesta_TipoUsuarioDetails(int id_propuestatipousuario)
        {
            return Get(id_propuestatipousuario);
        }

        public IEnumerable<Propuesta_TipoUsuario> GetPropuesta_TipoUsuarioNombre(string cd_nmpropuestatipousuario)
        {
            return Get(c => c.nmpropuestatipousuario == cd_nmpropuestatipousuario);
        }

        public bool InsertPropuesta_TipoUsuario(Propuesta_TipoUsuario propuesta_TipoUsuario)
        {
            Add(propuesta_TipoUsuario);
            return true;
        }

        public bool UpdatePropuesta_TipoUsuario(Propuesta_TipoUsuario propuesta_TipoUsuario)
        {
            Update(propuesta_TipoUsuario);
            return true;
        }

        public DataTableAdapter<Propuesta_TipoUsuario> GetDataTablePropuesta_TipoUsuario(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_TipoUsuario, bool>> srchByFunc = null;
            Expression<Func<Propuesta_TipoUsuario, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmpropuestatipousuario.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_TipoUsuario>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_TipoUsuario> result = new DataTableAdapter<Propuesta_TipoUsuario>();

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