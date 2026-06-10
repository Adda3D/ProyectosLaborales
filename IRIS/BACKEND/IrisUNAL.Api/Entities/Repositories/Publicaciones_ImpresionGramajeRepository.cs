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
    public class Publicaciones_ImpresionGramajeRepository : SuperType<Publicaciones_ImpresionGramaje>, IPublicaciones_ImpresionGramajeRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ImpresionGramajeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ImpresionGramajeRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_ImpresionGramaje(int id_gramaje)
        {
            Delete(id_gramaje);
            return true;
        }

        public IEnumerable<Publicaciones_ImpresionGramaje> GetAllPublicaciones_ImpresionGramaje()
        {
            return Get();
        }

        public Publicaciones_ImpresionGramaje GetPublicaciones_ImpresionGramajeDetails(int id_gramaje)
        {
            return Get(id_gramaje);
        }

        public Publicaciones_ImpresionGramaje GetPublicaciones_ImpresionGramajeNombre(string cd_nmgramaje)
        {
            return Get(c => c.nmgramaje == cd_nmgramaje).FirstOrDefault();
        }

        public bool InsertPublicaciones_ImpresionGramaje(Publicaciones_ImpresionGramaje publicaciones_ImpresionGramaje)
        {
            Add(publicaciones_ImpresionGramaje);
            return true;
        }

        public bool UpdatePublicaciones_ImpresionGramaje(Publicaciones_ImpresionGramaje publicaciones_ImpresionGramaje)
        {
            Update(publicaciones_ImpresionGramaje);
            return true;
        }
        DataTableAdapter<Publicaciones_ImpresionGramaje> IPublicaciones_ImpresionGramajeRepository.GetDataTablePublicaciones_ImpresionGramaje(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_ImpresionGramaje, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_ImpresionGramaje, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmgramaje.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_ImpresionGramaje>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_ImpresionGramaje> result = new DataTableAdapter<Publicaciones_ImpresionGramaje>();

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