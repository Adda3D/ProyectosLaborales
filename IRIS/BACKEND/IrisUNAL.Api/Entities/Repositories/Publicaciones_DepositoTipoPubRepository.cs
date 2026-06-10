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
    public class Publicaciones_DepositoTipoPubRepository : SuperType<Publicaciones_DepositoTipoPub>, IPublicaciones_DepositoTipoPubRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoTipoPubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoTipoPubRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoTipoPub(int id_tipopub)
        {
            Delete(id_tipopub);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoTipoPub> GetAllPublicaciones_DepositoTipoPub()
        {
            return Get();
        }

        public Publicaciones_DepositoTipoPub GetPublicaciones_DepositoTipoPubDetails(int id_tipopub)
        {
            return Get(id_tipopub);
        }

        public Publicaciones_DepositoTipoPub GetPublicaciones_DepositoTipoPubNombre(string cd_nmtipopub)
        {
            return Get(c => c.nmtipopub == cd_nmtipopub).FirstOrDefault();
        }

        public bool InsertPublicaciones_DepositoTipoPub(Publicaciones_DepositoTipoPub publicaciones_DepositoTipoPub)
        {
            Add(publicaciones_DepositoTipoPub);
            return true;
        }

        public bool UpdatePublicaciones_DepositoTipoPub(Publicaciones_DepositoTipoPub publicaciones_DepositoTipoPub)
        {
            Update(publicaciones_DepositoTipoPub);
            return true;
        }
        DataTableAdapter<Publicaciones_DepositoTipoPub> IPublicaciones_DepositoTipoPubRepository.GetDataTablePublicaciones_DepositoTipoPub(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DepositoTipoPub, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DepositoTipoPub, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipopub.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_DepositoTipoPub>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DepositoTipoPub> result = new DataTableAdapter<Publicaciones_DepositoTipoPub>();

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