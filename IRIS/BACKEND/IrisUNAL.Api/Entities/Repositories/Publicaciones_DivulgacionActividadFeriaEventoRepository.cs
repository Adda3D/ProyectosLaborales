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
    public class Publicaciones_DivulgacionActividadFeriaEventoRepository : SuperType<Publicaciones_DivulgacionActividadFeriaEvento>
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionActividadFeriaEventoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionActividadFeriaEventoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Publicaciones_DivulgacionActividadFeriaEvento> GetAllPublicaciones_DivulgacionActividadFeriaEvento()
        {
            return Get();
        }

        public Publicaciones_DivulgacionActividadFeriaEvento GetPublicaciones_DivulgacionActividadFeriaEventoDetails(int idferiaevento)
        {
            return Get(idferiaevento);
        }

        public bool InsertPublicaciones_DivulgacionActividadFeriaEvento(Publicaciones_DivulgacionActividadFeriaEvento _publicaciones_dDivulgacionactividadFeriaEvento)
        {
            Add(_publicaciones_dDivulgacionactividadFeriaEvento);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionActividadFeriaEvento(Publicaciones_DivulgacionActividadFeriaEvento _publicaciones_dDivulgacionactividadFeriaEvento)
        {
            Update(_publicaciones_dDivulgacionactividadFeriaEvento);
            return true;
        }

        public bool DeletePublicaciones_DivulgacionActividadFeriaEvento(int idferiaevento)
        {
            Delete(idferiaevento);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionActividadFeriaEvento> GetPublicaciones_DivulgacionActividadFeriaEventoByPublicacion(int id_crearpublicacion)
        {
            return Get(d => d.id_crearpublicacion == id_crearpublicacion);
        }

        public DataTableAdapter<Publicaciones_DivulgacionActividadFeriaEvento> GetDataTablePublicaciones_DivulgacionActividadFeriaEventoByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DivulgacionActividadFeriaEvento, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DivulgacionActividadFeriaEvento, string>> orderByFunc = null;
            Expression<Func<Publicaciones_DivulgacionActividadFeriaEvento, DateTime>> orderByDateFunc = null;
            //Expression<Func<Publicaciones_DivulgacionActividadFeriaEvento, int>> orderByIntFunc = null;

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fecha")
                orderByDateFunc = CreateExpressionOrderByDate<Publicaciones_DivulgacionActividadFeriaEvento>("fecha");
            else
                orderByFunc = CreateExpressionOrderBy<Publicaciones_DivulgacionActividadFeriaEvento>(model.SortColumn);

            //FILTRA POR LA PUBLICACION
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearpublicacion == id_crearpublicacion;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fecha") ?
                Get(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc).ToList() :
                Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DivulgacionActividadFeriaEvento> result = new DataTableAdapter<Publicaciones_DivulgacionActividadFeriaEvento>();

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