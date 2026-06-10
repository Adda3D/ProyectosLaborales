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
    public class Publicaciones_AreaCurricularRepository : SuperType<Publicaciones_AreaCurricular>, IPublicaciones_AreaCurricularRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_AreaCurricularRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_AreaCurricularRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_AreaCurricular(int id_areacurricular)
        {
            Delete(id_areacurricular);
            return true;
        }

        public IEnumerable<Publicaciones_AreaCurricular> GetAllPublicaciones_AreaCurricular()
        {
            return Get();
        }

        public Publicaciones_AreaCurricular GetPublicaciones_AreaCurricularDetails(int id_areacurricular)
        {
            return Get(id_areacurricular);
        }

        public Publicaciones_AreaCurricular GetPublicaciones_AreaCurricularDetails(string cd_nmareacurricular)
        {
            return Get(c => c.nmareacurricular == cd_nmareacurricular).FirstOrDefault();
        }

        public bool InsertPublicaciones_AreaCurricular(Publicaciones_AreaCurricular publicaciones_AreaCurricular)
        {
            Add(publicaciones_AreaCurricular);
            return true;
        }

        public bool UpdatePublicaciones_AreaCurricular(Publicaciones_AreaCurricular publicaciones_AreaCurricular)
        {
            Update(publicaciones_AreaCurricular);
            return true;
        }
        DataTableAdapter<Publicaciones_AreaCurricular> IPublicaciones_AreaCurricularRepository.GetDataTablePublicaciones_AreaCurricular(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_AreaCurricular, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_AreaCurricular, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmareacurricular.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_AreaCurricular>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_AreaCurricular> result = new DataTableAdapter<Publicaciones_AreaCurricular>();

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