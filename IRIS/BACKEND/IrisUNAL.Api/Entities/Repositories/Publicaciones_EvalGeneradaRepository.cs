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
    public class Publicaciones_EvalGeneradaRepository : SuperType<Publicaciones_EvalGenerada>, IPublicaciones_EvalGeneradaRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EvalGeneradaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EvalGeneradaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EvalGenerada(int id_evalgenerada)
        {
            Delete(id_evalgenerada);
            return true;
        }

        public IEnumerable<Publicaciones_EvalGenerada> GetAllPublicaciones_EvalGenerada()
        {
            return Get();
        }

        public Publicaciones_EvalGenerada GetPublicaciones_EvalGeneradaNombre(string cd_conevalgenerada)
        {
            return Get(c => c.conevalgenerada == cd_conevalgenerada).FirstOrDefault();
        }

        public Publicaciones_EvalGenerada GetPublicaciones_EvalGeneradaDetails(int id_evalgenerada)
        {
            return Get(id_evalgenerada);
        }

        public bool InsertPublicaciones_EvalGenerada(Publicaciones_EvalGenerada publicaciones_EvalGenerada)
        {
            Add(publicaciones_EvalGenerada);
            return true;
        }

        public bool UpdatePublicaciones_EvalGenerada(Publicaciones_EvalGenerada publicaciones_EvalGenerada)
        {
            Update(publicaciones_EvalGenerada);
            return true;
        }
        DataTableAdapter<Publicaciones_EvalGenerada> IPublicaciones_EvalGeneradaRepository.GetDataTablePublicaciones_EvalGenerada(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_EvalGenerada, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_EvalGenerada, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.conevalgenerada.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_EvalGenerada>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_EvalGenerada> result = new DataTableAdapter<Publicaciones_EvalGenerada>();

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