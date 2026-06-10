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
    public class Publicaciones_ImpresionTipoRepository : SuperType<Publicaciones_ImpresionTipo>, IPublicaciones_ImpresionTipoRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ImpresionTipoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ImpresionTipoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_ImpresionTipo(int id_impresiontipo)
        {
            Delete(id_impresiontipo);
            return true;
        }

        public IEnumerable<Publicaciones_ImpresionTipo> GetAllPublicaciones_ImpresionTipo()
        {
            return Get();
        }

        public Publicaciones_ImpresionTipo GetPublicaciones_ImpresionTipoNombre(string cd_nmimpresiontipo)
        {
            return Get(c=>c.nmimpresiontipo==cd_nmimpresiontipo).FirstOrDefault();
        }

        public Publicaciones_ImpresionTipo GetPublicaciones_ImpresionTipoDetails(int id_impresiontipo)
        {
            return Get(id_impresiontipo);
        }

        public bool InsertPublicaciones_ImpresionTipo(Publicaciones_ImpresionTipo publicaciones_ImpresionTipo)
        {
            Add(publicaciones_ImpresionTipo);
            return true;
        }

        public bool UpdatePublicaciones_ImpresionTipo(Publicaciones_ImpresionTipo publicaciones_ImpresionTipo)
        {
            Update(publicaciones_ImpresionTipo);
            return true;
        }
        DataTableAdapter<Publicaciones_ImpresionTipo> IPublicaciones_ImpresionTipoRepository.GetDataTablePublicaciones_ImpresionTipo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_ImpresionTipo, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_ImpresionTipo, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmimpresiontipo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_ImpresionTipo>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_ImpresionTipo> result = new DataTableAdapter<Publicaciones_ImpresionTipo>();

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