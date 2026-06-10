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
    public class Publicaciones_EvaluadoresRepository : SuperType<Publicaciones_Evaluadores>, IPublicaciones_EvaluadoresRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EvaluadoresRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EvaluadoresRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Evaluadores(int id_evaluadores)
        {
            Delete(id_evaluadores);
            return true;
        }

        public IEnumerable<Publicaciones_Evaluadores> GetAllPublicaciones_Evaluadores()
        {
            return Get();
        }

        public Publicaciones_Evaluadores GetPublicaciones_EvaluadoresDetails(int id_evaluadores)
        {
            return Get(id_evaluadores);
        }

        public IEnumerable<Publicaciones_Evaluadores> GetPublicaciones_EvaluadoresByPublicacion(int id_crearpublicacion)
        {
            Expression<Func<Publicaciones_Evaluadores, object>> parameter1 = m => m.ObjPersona;
            Expression<Func<Publicaciones_Evaluadores, object>> parameter2 = m => m.ObjEstado;
            Expression<Func<Publicaciones_Evaluadores, object>>[] parameterArray = new Expression<Func<Publicaciones_Evaluadores, object>>[] { parameter1, parameter2 };

            return Get(e => e.id_crearpublicacion == id_crearpublicacion, parameterArray);
        }


        public bool InsertPublicaciones_Evaluadores(Publicaciones_Evaluadores publicaciones_Evaluadores)
        {
            Add(publicaciones_Evaluadores);
            return true;
        }

        public bool UpdatePublicaciones_Evaluadores(Publicaciones_Evaluadores publicaciones_Evaluadores)
        {
            Update(publicaciones_Evaluadores);
            return true;
        }

        public DataTableAdapter<Publicaciones_Evaluadores> GetDataTablePublicaciones_EvaluadoresByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_Evaluadores, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_Evaluadores, string>> orderByFunc = null;
            Expression<Func<Publicaciones_Evaluadores, DateTime>> orderByDateFunc = null;
            Expression<Func<Publicaciones_Evaluadores, int>> orderByIntFunc = null;

            Expression<Func<Publicaciones_Evaluadores, object>> parameter1 = m => m.ObjPersona;
            Expression<Func<Publicaciones_Evaluadores, object>> parameter2 = m => m.ObjEstado;            
            Expression<Func<Publicaciones_Evaluadores, object>>[] parameterArray = new Expression<Func<Publicaciones_Evaluadores, object>>[] { parameter1, parameter2 };

            bool isOrderDesc = false;

            /* NO TRAE ORDENAMIENTO DEL DATATABLES
            if (model.SortColumn.ToLower() == "fecdesigcomite")
                orderByDateFunc = CreateExpressionOrderByDate<Publicaciones_Evaluadores>("fecdesigcomite");
            else
                orderByFunc = CreateExpressionOrderBy<Publicaciones_Evaluadores>(model.SortColumn);
            */

            orderByIntFunc = CreateExpressionOrderByInt<Publicaciones_Evaluadores>("id_evaluadores");

            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearpublicacion == id_crearpublicacion;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();

            //var data = (model.SortColumn.ToLower() == "fecdesigcomite") ?
            //    Get(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc).ToList() :
            //    Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_Evaluadores> result = new DataTableAdapter<Publicaciones_Evaluadores>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public Publicaciones_Evaluadores GetPublicaciones_EvaluadoresExisteEvaluador(int id_crearpublicacion, int id_persona)
        {
            return Get(p => p.id_crearpublicacion == id_crearpublicacion && p.id_persona == id_persona).FirstOrDefault();
        }
    }
}