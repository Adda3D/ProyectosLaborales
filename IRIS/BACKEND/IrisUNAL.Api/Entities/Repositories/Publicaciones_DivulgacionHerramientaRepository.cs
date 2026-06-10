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
    public class Publicaciones_DivulgacionHerramientaRepository : SuperType<Publicaciones_DivulgacionHerramienta>, IPublicaciones_DivulgacionHerramientaRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionHerramientaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionHerramientaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionHerramienta(int id_herramienta)
        {
            Delete(id_herramienta);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionHerramienta> GetAllPublicaciones_DivulgacionHerramienta()
        {
            return Get();
        }

        public Publicaciones_DivulgacionHerramienta GetPublicaciones_DivulgacionHerramientaDetails(int id_herramienta)
        {
            return Get(id_herramienta);
        }

        public bool InsertPublicaciones_DivulgacionHerramienta(Publicaciones_DivulgacionHerramienta publicaciones_DivulgacionHerramienta)
        {
            Add(publicaciones_DivulgacionHerramienta);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionHerramienta(Publicaciones_DivulgacionHerramienta publicaciones_DivulgacionHerramienta)
        {
            Update(publicaciones_DivulgacionHerramienta);
            return true;
        }

        public DataTableAdapter<Publicaciones_DivulgacionHerramienta> GetDataTablePublicaciones_DivulgacionHerramientaByPublicacionTipo(int id_crearpublicacion, int id_tipomedio, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DivulgacionHerramienta, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DivulgacionHerramienta, string>> orderByFunc = null;
            Expression<Func<Publicaciones_DivulgacionHerramienta, DateTime>> orderByDateFunc = null;
            //Expression<Func<Publicaciones_DivulgacionHerramienta, int>> orderByIntFunc = null;

            Expression<Func<Publicaciones_DivulgacionHerramienta, object>> parameter1 = m => m.ObjTipo;
            Expression<Func<Publicaciones_DivulgacionHerramienta, object>>[] parameterArray = new Expression<Func<Publicaciones_DivulgacionHerramienta, object>>[] { parameter1 };

            bool isOrderDesc = false;


            if (model.SortColumn.ToLower() == "fecha")
                orderByDateFunc = CreateExpressionOrderByDate<Publicaciones_DivulgacionHerramienta>("fecha");
            else
                orderByFunc = CreateExpressionOrderBy<Publicaciones_DivulgacionHerramienta>(model.SortColumn);


            //FILTRA POR LA PUBLICACION
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion && p.id_tipomedio == id_tipomedio;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion && p.id_tipomedio == id_tipomedio;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fecha") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DivulgacionHerramienta> result = new DataTableAdapter<Publicaciones_DivulgacionHerramienta>();

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