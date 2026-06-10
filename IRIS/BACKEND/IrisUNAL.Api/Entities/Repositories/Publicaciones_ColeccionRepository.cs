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
    public class Publicaciones_ColeccionRepository : SuperType<Publicaciones_Coleccion>, IPublicaciones_ColeccionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ColeccionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ColeccionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Coleccion(int id_coleccion)
        {
            Delete(id_coleccion);
            return true;
        }

        public IEnumerable<Publicaciones_Coleccion> GetAllPublicaciones_Coleccion()
        {
            return Get();
        }

        public Publicaciones_Coleccion GetPublicaciones_ColeccionDetails(int id_coleccion)
        {
            return Get(id_coleccion);
        }

        public Publicaciones_Coleccion GetPublicaciones_ColeccionNombre(string cd_nmcoleccion)
        {
            return Get(c => c.nmcoleccion == cd_nmcoleccion).FirstOrDefault();
        }

        public bool InsertPublicaciones_Coleccion(Publicaciones_Coleccion publicaciones_Coleccion)
        {
            Add(publicaciones_Coleccion);
            return true;
        }

        public bool UpdatePublicaciones_Coleccion(Publicaciones_Coleccion publicaciones_Coleccion)
        {
            Update(publicaciones_Coleccion);
            return true;
        }
        DataTableAdapter<Publicaciones_Coleccion> IPublicaciones_ColeccionRepository.GetDataTablePublicaciones_Coleccion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_Coleccion, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_Coleccion, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmcoleccion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_Coleccion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_Coleccion> result = new DataTableAdapter<Publicaciones_Coleccion>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public int GetPublicaciones_ColeccionConsecutivo(int id_coleccion)
        {
            int consecutivosgte = 1;
            var coleccion = Get(id_coleccion);
            
            if (coleccion.consecutivo != null)
            {
                consecutivosgte = (int)coleccion.consecutivo + 1;
            }

            return consecutivosgte;            
        }
    }
}