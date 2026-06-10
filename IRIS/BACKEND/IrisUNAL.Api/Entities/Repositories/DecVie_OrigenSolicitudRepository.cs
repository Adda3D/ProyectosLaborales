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
    public class DecVie_OrigenSolicitudRepository : SuperType<DecVie_OrigenSolicitud>, IDecVie_OrigenSolicitudRepository
    {
        private ApplicationDbContext _context;

        public DecVie_OrigenSolicitudRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_OrigenSolicitudRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_OrigenSolicitud(int id_origensolicitud)
        {
            Delete(id_origensolicitud);
            return true;
        }

        public IEnumerable<DecVie_OrigenSolicitud> GetAllDecVie_OrigenSolicitud()
        {
            return Get();
        }

        public DecVie_OrigenSolicitud GetDecVie_OrigenSolicitudDetails(int id_origensolicitud)
        {
            return Get(id_origensolicitud);
        }

        public DecVie_OrigenSolicitud GetDecVie_OrigenSolicitudNombre(string cd_nmorigensolicitud)
        {
            return Get(c => c.nmorigensolicitud == cd_nmorigensolicitud).FirstOrDefault();
        }

        public bool InsertDecVie_OrigenSolicitud(DecVie_OrigenSolicitud decVie_OrigenSolicitud)
        {
            Add(decVie_OrigenSolicitud);
            return true;
        }

        public bool UpdateDecVie_OrigenSolicitud(DecVie_OrigenSolicitud decVie_OrigenSolicitud)
        {
            Update(decVie_OrigenSolicitud);
            return true;
        }
        DataTableAdapter<DecVie_OrigenSolicitud> IDecVie_OrigenSolicitudRepository.GetDataTableDecVie_OrigenSolicitud(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_OrigenSolicitud, bool>> srchByFunc = null;
            Expression<Func<DecVie_OrigenSolicitud, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmorigensolicitud.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_OrigenSolicitud>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_OrigenSolicitud> result = new DataTableAdapter<DecVie_OrigenSolicitud>();

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