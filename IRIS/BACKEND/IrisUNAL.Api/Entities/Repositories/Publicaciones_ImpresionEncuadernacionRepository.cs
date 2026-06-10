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
    public class Publicaciones_ImpresionEncuadernacionRepository : SuperType<Publicaciones_ImpresionEncuadernacion>, IPublicaciones_ImpresionEncuadernacionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ImpresionEncuadernacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ImpresionEncuadernacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_ImpresionEncuadernacion(int id_encuadernacion)
        {
            Delete(id_encuadernacion);
            return true;
        }

        public IEnumerable<Publicaciones_ImpresionEncuadernacion> GetAllPublicaciones_ImpresionEncuadernacion()
        {
            return Get();
        }

        public Publicaciones_ImpresionEncuadernacion GetPublicaciones_ImpresionEncuadernacionDetails(int id_encuadernacion)
        {
            return Get(id_encuadernacion);
        }

        public Publicaciones_ImpresionEncuadernacion GetPublicaciones_ImpresionEncuadernacionNombre(string cd_nmencuadernacion)
        {
            return Get(c => c.nmencuadernacion == cd_nmencuadernacion).FirstOrDefault();
        }

        public bool InsertPublicaciones_ImpresionEncuadernacion(Publicaciones_ImpresionEncuadernacion publicaciones_ImpresionEncuadernacion)
        {
            Add(publicaciones_ImpresionEncuadernacion);
            return true;
        }

        public bool UpdatePublicaciones_ImpresionEncuadernacion(Publicaciones_ImpresionEncuadernacion publicaciones_ImpresionEncuadernacion)
        {
            Update(publicaciones_ImpresionEncuadernacion);
            return true;
        }
        DataTableAdapter<Publicaciones_ImpresionEncuadernacion> IPublicaciones_ImpresionEncuadernacionRepository.GetDataTablePublicaciones_ImpresionEncuadernacion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_ImpresionEncuadernacion, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_ImpresionEncuadernacion, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmencuadernacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_ImpresionEncuadernacion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_ImpresionEncuadernacion> result = new DataTableAdapter<Publicaciones_ImpresionEncuadernacion>();

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