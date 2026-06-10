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
    public class Publicaciones_ComplejidadRepository : SuperType<Publicaciones_Complejidad>, IPublicaciones_ComplejidadRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ComplejidadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ComplejidadRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Complejidad(int id_complejidad)
        {
            Delete(id_complejidad);
            return true;
        }

        public IEnumerable<Publicaciones_Complejidad> GetAllPublicaciones_Complejidad()
        {
            return Get();
        }

        public Publicaciones_Complejidad GetPublicaciones_ComplejidadDetails(int id_complejidad)
        {
            return Get(id_complejidad);
        }

        public Publicaciones_Complejidad GetPublicaciones_ComplejidadNombre(string cd_nmcomplejidad)
        {
            return Get(c => c.nmcomplejidad == cd_nmcomplejidad).FirstOrDefault();
        }

        public bool InsertPublicaciones_Complejidad(Publicaciones_Complejidad publicaciones_Complejidad)
        {
            Add(publicaciones_Complejidad);
            return true;
        }

        public bool UpdatePublicaciones_Complejidad(Publicaciones_Complejidad publicaciones_Complejidad)
        {
            Update(publicaciones_Complejidad);
            return true;
        }
        DataTableAdapter<Publicaciones_Complejidad> IPublicaciones_ComplejidadRepository.GetDataTablePublicaciones_Complejidad(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_Complejidad, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_Complejidad, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmcomplejidad.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_Complejidad>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_Complejidad> result = new DataTableAdapter<Publicaciones_Complejidad>();

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