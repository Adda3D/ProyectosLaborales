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
    public class Publicaciones_EstadoEvaluadorRepository : SuperType<Publicaciones_EstadoEvaluador>, IPublicaciones_EstadoEvaluadorRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EstadoEvaluadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EstadoEvaluadorRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EstadoEvaluador(int id_estadoevaluador)
        {
            Delete(id_estadoevaluador);
            return true;
        }

        public IEnumerable<Publicaciones_EstadoEvaluador> GetAllPublicaciones_EstadoEvaluador()
        {
            return Get();
        }

        public Publicaciones_EstadoEvaluador GetPublicaciones_EstadoEvaluadorDetails(int id_estadoevaluador)
        {
            return Get(id_estadoevaluador);
        }

        public Publicaciones_EstadoEvaluador GetPublicaciones_EstadoEvaluadorNombre(string cd_nmestadoevaluador)
        {
            return Get(c => c.nmestadoevaluador == cd_nmestadoevaluador).FirstOrDefault();
        }

        public bool InsertPublicaciones_EstadoEvaluador(Publicaciones_EstadoEvaluador publicaciones_EstadoEvaluador)
        {
            Add(publicaciones_EstadoEvaluador);
            return true;
        }

        public bool UpdatePublicaciones_EstadoEvaluador(Publicaciones_EstadoEvaluador publicaciones_EstadoEvaluador)
        {
            Update(publicaciones_EstadoEvaluador);
            return true;
        }
        DataTableAdapter<Publicaciones_EstadoEvaluador> IPublicaciones_EstadoEvaluadorRepository.GetDataTablePublicaciones_EstadoEvaluador(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_EstadoEvaluador, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_EstadoEvaluador, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadoevaluador.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_EstadoEvaluador>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_EstadoEvaluador> result = new DataTableAdapter<Publicaciones_EstadoEvaluador>();

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