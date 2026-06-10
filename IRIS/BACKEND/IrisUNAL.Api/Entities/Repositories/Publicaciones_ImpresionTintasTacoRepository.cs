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
    public class Publicaciones_ImpresionTintasTacoRepository : SuperType<Publicaciones_ImpresionTintasTaco>, IPublicaciones_ImpresionTintasTacoRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ImpresionTintasTacoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ImpresionTintasTacoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_ImpresionTintasTaco(int id_tintastaco)
        {
            Delete(id_tintastaco);
            return true;
        }

        public IEnumerable<Publicaciones_ImpresionTintasTaco> GetAllPublicaciones_ImpresionTintasTaco()
        {
            return Get();
        }

        public Publicaciones_ImpresionTintasTaco GetPublicaciones_ImpresionTintasTacoDetails(int id_tintastaco)
        {
            return Get(id_tintastaco);
        }

        public Publicaciones_ImpresionTintasTaco GetPublicaciones_ImpresionTintasTacoNombre(string cd_nmtintastaco)
        {
            return Get(c => c.nmtintastaco == cd_nmtintastaco).FirstOrDefault();
        }

        public bool InsertPublicaciones_ImpresionTintasTaco(Publicaciones_ImpresionTintasTaco publicaciones_ImpresionTintasTaco)
        {
            Add(publicaciones_ImpresionTintasTaco);
            return true;
        }

        public bool UpdatePublicaciones_ImpresionTintasTaco(Publicaciones_ImpresionTintasTaco publicaciones_ImpresionTintasTaco)
        {
            Update(publicaciones_ImpresionTintasTaco);
            return true;
        }
        DataTableAdapter<Publicaciones_ImpresionTintasTaco> IPublicaciones_ImpresionTintasTacoRepository.GetDataTablePublicaciones_ImpresionTintasTaco(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_ImpresionTintasTaco, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_ImpresionTintasTaco, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtintastaco.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_ImpresionTintasTaco>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_ImpresionTintasTaco> result = new DataTableAdapter<Publicaciones_ImpresionTintasTaco>();

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