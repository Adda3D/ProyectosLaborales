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
    public class RolRepository : SuperType<Rol>, IRolRepository
    {
        private ApplicationDbContext _context;

        public RolRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RolRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteRol(int id_rol)
        {
            Delete(id_rol);
            return true;
        }

        public IEnumerable<Rol> GetAllRol()
        {
            return Get();
        }

        public Rol GetRolDetails(int id_rol)
        {
            return Get(id_rol);
        }

        public IEnumerable<Rol> GetRolNombre(string cd_nombre)
        {
            return Get(c => c.nombre == cd_nombre);
        }

        public bool InsertRol(Rol rol)
        {
            Add(rol);
            return true;
        }

        public bool UpdateRol(Rol rol)
        {
            Update(rol);
            return true;
        }

        public DataTableAdapter<Rol> GetDataTableRol(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Rol, bool>> srchByFunc = null;
            Expression<Func<Rol, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nombre.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Rol>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Rol> result = new DataTableAdapter<Rol>();

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