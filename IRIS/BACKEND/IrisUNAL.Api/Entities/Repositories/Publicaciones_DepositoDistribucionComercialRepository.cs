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
    public class Publicaciones_DepositoDistribucionComercialRepository : SuperType<Publicaciones_DepositoDistribucionComercial>, IPublicaciones_DepositoDistribucionComercialRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoDistribucionComercialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoDistribucionComercialRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoDistribucionComercial(int id_distribucioncomercial)
        {
            Delete(id_distribucioncomercial);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoDistribucionComercial> GetAllPublicaciones_DepositoDistribucionComercial()
        {
            return Get();
        }

        public Publicaciones_DepositoDistribucionComercial GetPublicaciones_DepositoDistribucionComercialDetails(int id_distribucioncomercial)
        {
            return Get(id_distribucioncomercial);
        }

        public bool InsertPublicaciones_DepositoDistribucionComercial(Publicaciones_DepositoDistribucionComercial publicaciones_DepositoDistribucionComercial)
        {
            Add(publicaciones_DepositoDistribucionComercial);
            return true;
        }

        public bool UpdatePublicaciones_DepositoDistribucionComercial(Publicaciones_DepositoDistribucionComercial publicaciones_DepositoDistribucionComercial)
        {
            Update(publicaciones_DepositoDistribucionComercial);
            return true;
        }

        public DataTableAdapter<Publicaciones_DepositoDistribucionComercial> GetDataTablePublicaciones_DepositoDistribucionComercialByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DepositoDistribucionComercial, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DepositoDistribucionComercial, string>> orderByFunc = null;
            Expression<Func<Publicaciones_DepositoDistribucionComercial, DateTime>> orderByDateFunc = null;
            Expression<Func<Publicaciones_DepositoDistribucionComercial, int>> orderByIntFunc = null;

            Expression<Func<Publicaciones_DepositoDistribucionComercial, object>> parameter1 = m => m.ObjDistribuidor;
            Expression<Func<Publicaciones_DepositoDistribucionComercial, object>>[] parameterArray = new Expression<Func<Publicaciones_DepositoDistribucionComercial, object>>[] { parameter1 };

            bool isOrderDesc = false;


            if (model.SortColumn.ToLower() == "id_distribucioncomercial")
                orderByIntFunc = CreateExpressionOrderByInt<Publicaciones_DepositoDistribucionComercial>("id_distribucioncomercial");
            else
                if (model.SortColumn.ToLower() == "fechaentrega")
                orderByDateFunc = CreateExpressionOrderByDate<Publicaciones_DepositoDistribucionComercial>("fechaentrega");


            //FILTRA POR LA PUBLICACION
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearpublicacion == id_crearpublicacion;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();

            var data = (model.SortColumn.ToLower() == "fechaentrega") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DepositoDistribucionComercial> result = new DataTableAdapter<Publicaciones_DepositoDistribucionComercial>();

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