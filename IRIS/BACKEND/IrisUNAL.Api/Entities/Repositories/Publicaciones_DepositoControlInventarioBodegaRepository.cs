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
    public class Publicaciones_DepositoControlInventarioBodegaRepository : SuperType<Publicaciones_DepositoControlInventarioBodega>, IPublicaciones_DepositoControlInventarioBodegaRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoControlInventarioBodegaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoControlInventarioBodegaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoControlInventarioBodega(int id_bodega)
        {
            Delete(id_bodega);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoControlInventarioBodega> GetAllPublicaciones_DepositoControlInventarioBodega()
        {
            return Get();
        }

        public Publicaciones_DepositoControlInventarioBodega GetPublicaciones_DepositoControlInventarioBodegaDetails(int id_bodega)
        {
            return Get(id_bodega);
        }

        public Publicaciones_DepositoControlInventarioBodega GetPublicaciones_DepositoControlInventarioBodegaNombre(string cd_nmbodega)
        {
            return Get(c => c.nmbodega == cd_nmbodega).FirstOrDefault();
        }

        public bool InsertPublicaciones_DepositoControlInventarioBodega(Publicaciones_DepositoControlInventarioBodega publicaciones_DepositoControlInventarioBodega)
        {
            Add(publicaciones_DepositoControlInventarioBodega);
            return true;
        }

        public bool UpdatePublicaciones_DepositoControlInventarioBodega(Publicaciones_DepositoControlInventarioBodega publicaciones_DepositoControlInventarioBodega)
        {
            Update(publicaciones_DepositoControlInventarioBodega);
            return true;
        }
        DataTableAdapter<Publicaciones_DepositoControlInventarioBodega> IPublicaciones_DepositoControlInventarioBodegaRepository.GetDataTablePublicaciones_DepositoControlInventarioBodega(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DepositoControlInventarioBodega, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DepositoControlInventarioBodega, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmbodega.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_DepositoControlInventarioBodega>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DepositoControlInventarioBodega> result = new DataTableAdapter<Publicaciones_DepositoControlInventarioBodega>();

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