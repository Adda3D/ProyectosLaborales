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
    public class Publicaciones_DepositoTipoMovRepository : SuperType<Publicaciones_DepositoTipoMov>, IPublicaciones_DepositoTipoMovRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoTipoMovRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoTipoMovRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoTipoMov(int id_tipomov)
        {
            Delete(id_tipomov);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoTipoMov> GetAllPublicaciones_DepositoTipoMov()
        {
            return Get();
        }

        public Publicaciones_DepositoTipoMov GetPublicaciones_DepositoTipoMovDetails(int id_tipomov)
        {
            return Get(id_tipomov);
        }

        public Publicaciones_DepositoTipoMov GetPublicaciones_DepositoTipoMovNombre(string cd_nmtipomov)
        {
            return Get(c => c.nmtipomov == cd_nmtipomov).FirstOrDefault();
        }

        public bool InsertPublicaciones_DepositoTipoMov(Publicaciones_DepositoTipoMov publicaciones_DepositoTipoMov)
        {
            Add(publicaciones_DepositoTipoMov);
            return true;
        }

        public bool UpdatePublicaciones_DepositoTipoMov(Publicaciones_DepositoTipoMov publicaciones_DepositoTipoMov)
        {
            Update(publicaciones_DepositoTipoMov);
            return true;
        }
        DataTableAdapter<Publicaciones_DepositoTipoMov> IPublicaciones_DepositoTipoMovRepository.GetDataTablePublicaciones_DepositoTipoMov(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DepositoTipoMov, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DepositoTipoMov, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipomov.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_DepositoTipoMov>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DepositoTipoMov> result = new DataTableAdapter<Publicaciones_DepositoTipoMov>();

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