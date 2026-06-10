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
    public class Publicaciones_FormatoDistribucionRepository : SuperType<Publicaciones_FormatoDistribucion>, IPublicaciones_FormatoDistribucionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_FormatoDistribucionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_FormatoDistribucionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_FormatoDistribucion(int id_formatodistribucion)
        {
            Delete(id_formatodistribucion);
            return true;
        }

        public IEnumerable<Publicaciones_FormatoDistribucion> GetAllPublicaciones_FormatoDistribucion()
        {
            return Get();
        }

        public Publicaciones_FormatoDistribucion GetPublicaciones_FormatoDistribucionDetails(int id_formatodistribucion)
        {
            return Get(id_formatodistribucion);
        }

        public Publicaciones_FormatoDistribucion GetPublicaciones_FormatoDistribucionNombre(string cd_nmformatodis)
        {
            return Get(c => c.nmformatodis == cd_nmformatodis).FirstOrDefault();
        }

        public bool InsertPublicaciones_FormatoDistribucion(Publicaciones_FormatoDistribucion publicaciones_FormatoDistribucion)
        {
            Add(publicaciones_FormatoDistribucion);
            return true;
        }

        public bool UpdatePublicaciones_FormatoDistribucion(Publicaciones_FormatoDistribucion publicaciones_FormatoDistribucion)
        {
            Update(publicaciones_FormatoDistribucion);
            return true;
        }
        DataTableAdapter<Publicaciones_FormatoDistribucion> IPublicaciones_FormatoDistribucionRepository.GetDataTablePublicaciones_FormatoDistribucion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_FormatoDistribucion, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_FormatoDistribucion, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmformatodis.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_FormatoDistribucion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_FormatoDistribucion> result = new DataTableAdapter<Publicaciones_FormatoDistribucion>();

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