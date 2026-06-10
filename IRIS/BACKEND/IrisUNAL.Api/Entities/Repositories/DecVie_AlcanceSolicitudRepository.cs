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
    public class DecVie_AlcanceSolicitudRepository : SuperType<DecVie_AlcanceSolicitud>, IDecVie_AlcanceSolicitudRepository
    {
        private ApplicationDbContext _context;

        public DecVie_AlcanceSolicitudRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_AlcanceSolicitudRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_AlcanceSolicitud(int id_alcancesolicitud)
        {
            Delete(id_alcancesolicitud);
            return true;
        }

        public IEnumerable<DecVie_AlcanceSolicitud> GetAllDecVie_AlcanceSolicitud()
        {
            return Get();
        }

        public DecVie_AlcanceSolicitud GetDecVie_AlcanceSolicitudDetails(int id_alcancesolicitud)
        {
            return Get(id_alcancesolicitud);
        }

        public DecVie_AlcanceSolicitud GetDecVie_AlcanceSolicitudNombre(string cd_nmalcancesolicitud)
        {
            return Get(c => c.nmalcancesolicitud == cd_nmalcancesolicitud).FirstOrDefault();
        }

        public bool InsertDecVie_AlcanceSolicitud(DecVie_AlcanceSolicitud decVie_AlcanceSolicitud)
        {
            Add(decVie_AlcanceSolicitud);
            return true;
        }

        public bool UpdateDecVie_AlcanceSolicitud(DecVie_AlcanceSolicitud decVie_AlcanceSolicitud)
        {
            Update(decVie_AlcanceSolicitud);
            return true;
        }
        DataTableAdapter<DecVie_AlcanceSolicitud> IDecVie_AlcanceSolicitudRepository.GetDataTableDecVie_AlcanceSolicitud(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_AlcanceSolicitud, bool>> srchByFunc = null;
            Expression<Func<DecVie_AlcanceSolicitud, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmalcancesolicitud.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_AlcanceSolicitud>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_AlcanceSolicitud> result = new DataTableAdapter<DecVie_AlcanceSolicitud>();

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