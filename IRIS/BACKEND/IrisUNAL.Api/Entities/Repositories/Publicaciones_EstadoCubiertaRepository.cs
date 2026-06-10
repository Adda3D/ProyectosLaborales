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
    public class Publicaciones_EstadoCubiertaRepository : SuperType<Publicaciones_EstadoCubierta>, IPublicaciones_EstadoCubiertaRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EstadoCubiertaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EstadoCubiertaRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeletePublicaciones_EstadoCubierta(int id_estadocubierta)
        {
            Delete(id_estadocubierta);
            return true;
        }

        public IEnumerable<Publicaciones_EstadoCubierta> GetAllPublicaciones_EstadoCubierta()
        {
            return Get();
        }

        public Publicaciones_EstadoCubierta GetPublicaciones_EstadoCubiertaDetails(int id_estadocubierta)
        {
            return Get(id_estadocubierta);
        }

        public Publicaciones_EstadoCubierta GetPublicaciones_EstadoCubiertaNombre(string cd_nmestadocubierta)
        {
            return Get(c => c.nmestadocubierta == cd_nmestadocubierta).FirstOrDefault();
        }

        public bool InsertPublicaciones_EstadoCubierta(Publicaciones_EstadoCubierta publicaciones_EstadoCubierta)
        {
            Add(publicaciones_EstadoCubierta);
            return true;
        }

        public bool UpdatePublicaciones_EstadoCubierta(Publicaciones_EstadoCubierta publicaciones_EstadoCubierta)
        {
            Update(publicaciones_EstadoCubierta);
            return true;
        }
        DataTableAdapter<Publicaciones_EstadoCubierta> IPublicaciones_EstadoCubiertaRepository.GetDataTablePublicaciones_EstadoCubierta(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_EstadoCubierta, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_EstadoCubierta, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadocubierta.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_EstadoCubierta>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_EstadoCubierta> result = new DataTableAdapter<Publicaciones_EstadoCubierta>();

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