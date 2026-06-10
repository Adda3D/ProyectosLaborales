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
    public class Publicaciones_EstadoDiagramacionRepository : SuperType<Publicaciones_EstadoDiagramacion>, IPublicaciones_EstadoDiagramacionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EstadoDiagramacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EstadoDiagramacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EstadoDiagramacion(int id_estadodiagramacion)
        {
            Delete(id_estadodiagramacion);
            return true;
        }

        public IEnumerable<Publicaciones_EstadoDiagramacion> GetAllPublicaciones_EstadoDiagramacion()
        {
            return Get();
        }

        public Publicaciones_EstadoDiagramacion GetPublicaciones_EstadoDiagramacionDetails(int id_estadodiagramacion)
        {
            return Get(id_estadodiagramacion);
        }

        public Publicaciones_EstadoDiagramacion GetPublicaciones_EstadoDiagramacionNombre(string cd_nmestadodiagramacion)
        {
            return Get(c => c.nmestadodiagramacion == cd_nmestadodiagramacion).FirstOrDefault();
        }

        public bool InsertPublicaciones_EstadoDiagramacion(Publicaciones_EstadoDiagramacion publicaciones_EstadoDiagramacion)
        {
            Add(publicaciones_EstadoDiagramacion);
            return true;
        }

        public bool UpdatePublicaciones_EstadoDiagramacion(Publicaciones_EstadoDiagramacion publicaciones_EstadoDiagramacion)
        {
            Update(publicaciones_EstadoDiagramacion);
            return true;
        }
        DataTableAdapter<Publicaciones_EstadoDiagramacion> IPublicaciones_EstadoDiagramacionRepository.GetDataTablePublicaciones_EstadoDiagramacion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_EstadoDiagramacion, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_EstadoDiagramacion, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadodiagramacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_EstadoDiagramacion>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_EstadoDiagramacion> result = new DataTableAdapter<Publicaciones_EstadoDiagramacion>();

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