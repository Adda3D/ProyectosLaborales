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
    public class Publicaciones_TipoObraRepository : SuperType<Publicaciones_TipoObra>, IPublicaciones_TipoObraRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_TipoObraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_TipoObraRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_TipoObra(int id_tipoobra)
        {
            Delete(id_tipoobra);
            return true;
        }

        public IEnumerable<Publicaciones_TipoObra> GetAllPublicaciones_TipoObra()
        {
            return Get();
        }

        public Publicaciones_TipoObra GetPublicaciones_TipoObraDetails(int id_tipoobra)
        {
            return Get(id_tipoobra);
        }

        public Publicaciones_TipoObra GetPublicaciones_TipoObraNombre(string cd_nmtipoobra)
        {
            return Get(c => c.nmtipoobra == cd_nmtipoobra).FirstOrDefault();
        }

        public bool InsertPublicaciones_TipoObra(Publicaciones_TipoObra publicaciones_TipoObra)
        {
            Add(publicaciones_TipoObra);
            return true;
        }

        public bool UpdatePublicaciones_TipoObra(Publicaciones_TipoObra publicaciones_TipoObra)
        {
            Update(publicaciones_TipoObra);
            return true;
        }
        DataTableAdapter<Publicaciones_TipoObra> IPublicaciones_TipoObraRepository.GetDataTablePublicaciones_TipoObra(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_TipoObra, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_TipoObra, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipoobra.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_TipoObra>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_TipoObra> result = new DataTableAdapter<Publicaciones_TipoObra>();

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