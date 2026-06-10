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
    public class Publicaciones_EvaluacionInicialRepository : SuperType<Publicaciones_EvaluacionInicial>, IPublicaciones_EvaluacionInicialRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EvaluacionInicialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EvaluacionInicialRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EvaluacionInicial(int id_evaluacioninicial)
        {
            Delete(id_evaluacioninicial);
            return true;
        }

        public IEnumerable<Publicaciones_EvaluacionInicial> GetAllPublicaciones_EvaluacionInicial()
        {
            return Get();
        }

        public Publicaciones_EvaluacionInicial GetPublicaciones_EvaluacionInicialDetails(int id_evaluacioninicial)
        {
            return Get(id_evaluacioninicial);
        }

        public Publicaciones_EvaluacionInicial GetPublicaciones_EvaluacionInicialNombre(string cd_nmevalinicial)
        {
            return Get(c => c.nmevalinicial == cd_nmevalinicial).FirstOrDefault();
        }

        public bool InsertPublicaciones_EvaluacionInicial(Publicaciones_EvaluacionInicial publicaciones_EvaluacionInicial)
        {
            Add(publicaciones_EvaluacionInicial);
            return true;
        }

        public bool UpdatePublicaciones_EvaluacionInicial(Publicaciones_EvaluacionInicial publicaciones_EvaluacionInicial)
        {
            Update(publicaciones_EvaluacionInicial);
            return true;
        }
        DataTableAdapter<Publicaciones_EvaluacionInicial> IPublicaciones_EvaluacionInicialRepository.GetDataTablePublicaciones_EvaluacionInicial(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_EvaluacionInicial, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_EvaluacionInicial, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmevalinicial.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_EvaluacionInicial>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_EvaluacionInicial> result = new DataTableAdapter<Publicaciones_EvaluacionInicial>();

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