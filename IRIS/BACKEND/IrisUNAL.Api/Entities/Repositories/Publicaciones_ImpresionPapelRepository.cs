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
    public class Publicaciones_ImpresionPapelRepository : SuperType<Publicaciones_ImpresionPapel>, IPublicaciones_ImpresionPapelRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ImpresionPapelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ImpresionPapelRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_ImpresionPapel(int id_papel)
        {
            Delete(id_papel);
            return true;
        }

        public IEnumerable<Publicaciones_ImpresionPapel> GetAllPublicaciones_ImpresionPapel()
        {
            return Get();
        }

        public Publicaciones_ImpresionPapel GetPublicaciones_ImpresionPapelDetails(int id_papel)
        {
            return Get(id_papel);
        }

        public Publicaciones_ImpresionPapel GetPublicaciones_ImpresionPapelNombre(string cd_nmpapel)
        {
            return Get(c => c.nmpapel == cd_nmpapel).FirstOrDefault();
        }

        public bool InsertPublicaciones_ImpresionPapel(Publicaciones_ImpresionPapel publicaciones_ImpresionPapel)
        {
            Add(publicaciones_ImpresionPapel);
            return true;
        }

        public bool UpdatePublicaciones_ImpresionPapel(Publicaciones_ImpresionPapel publicaciones_ImpresionPapel)
        {
            Update(publicaciones_ImpresionPapel);
            return true;
        }
        DataTableAdapter<Publicaciones_ImpresionPapel> IPublicaciones_ImpresionPapelRepository.GetDataTablePublicaciones_ImpresionPapel(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_ImpresionPapel, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_ImpresionPapel, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmpapel.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_ImpresionPapel>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_ImpresionPapel> result = new DataTableAdapter<Publicaciones_ImpresionPapel>();

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