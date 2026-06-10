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
    public class Publicaciones_TipoDiagramacionRepository : SuperType<Publicaciones_TipoDiagramacion>, IPublicaciones_TipoDiagramacionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_TipoDiagramacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_TipoDiagramacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_TipoDiagramacion(int id_tipodiagramacion)
        {
            Delete(id_tipodiagramacion);
            return true;
        }

        public IEnumerable<Publicaciones_TipoDiagramacion> GetAllPublicaciones_TipoDiagramacion()
        {
            return Get();
        }

        public Publicaciones_TipoDiagramacion GetPublicaciones_TipoDiagramacionDetails(int id_tipodiagramacion)
        {
            return Get(id_tipodiagramacion);
        }

        public Publicaciones_TipoDiagramacion GetPublicaciones_TipoDiagramacionNombre(string cd_nmtipodiagramacion)
        {
            return Get(c => c.nmtipodiagramacion == cd_nmtipodiagramacion).FirstOrDefault();
        }

        public bool InsertPublicaciones_TipoDiagramacion(Publicaciones_TipoDiagramacion publicaciones_TipoDiagramacion)
        {
            Add(publicaciones_TipoDiagramacion);
            return true;
        }

        public bool UpdatePublicaciones_TipoDiagramacion(Publicaciones_TipoDiagramacion publicaciones_TipoDiagramacion)
        {
            Update(publicaciones_TipoDiagramacion);
            return true;
        }
        DataTableAdapter<Publicaciones_TipoDiagramacion> IPublicaciones_TipoDiagramacionRepository.GetDataTablePublicaciones_TipoDiagramacion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_TipoDiagramacion, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_TipoDiagramacion, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipodiagramacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_TipoDiagramacion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_TipoDiagramacion> result = new DataTableAdapter<Publicaciones_TipoDiagramacion>();

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