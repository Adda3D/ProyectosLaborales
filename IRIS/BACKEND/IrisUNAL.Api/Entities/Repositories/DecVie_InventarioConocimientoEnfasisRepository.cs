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
    public class DecVie_InventarioConocimientoEnfasisRepository : SuperType<DecVie_InventarioConocimientoEnfasis>, IDecVie_InventarioConocimientoEnfasisRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InventarioConocimientoEnfasisRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InventarioConocimientoEnfasisRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_InventarioConocimientoEnfasis(int id_conocimientoenfasis)
        {
            Delete(id_conocimientoenfasis);
            return true;
        }

        public IEnumerable<DecVie_InventarioConocimientoEnfasis> GetAllDecVie_InventarioConocimientoEnfasis()
        {
            return Get();
        }

        public DecVie_InventarioConocimientoEnfasis GetDecVie_InventarioConocimientoEnfasisDetails(int id_conocimientoenfasis)
        {
            return Get(id_conocimientoenfasis);
        }

        public DecVie_InventarioConocimientoEnfasis GetDecVie_InventarioConocimientoEnfasisNombre(string cd_nmenfasis)
        {
            return Get(c => c.nmenfasis == cd_nmenfasis).FirstOrDefault();
        }

        public bool InsertDecVie_InventarioConocimientoEnfasis(DecVie_InventarioConocimientoEnfasis decVie_InventarioConocimientoEnfasis)
        {
            Add(decVie_InventarioConocimientoEnfasis);
            return true;

        }

        public bool UpdateDecVie_InventarioConocimientoEnfasis(DecVie_InventarioConocimientoEnfasis decVie_InventarioConocimientoEnfasis)
        {
            Update(decVie_InventarioConocimientoEnfasis);
            return true;
        }
        DataTableAdapter<DecVie_InventarioConocimientoEnfasis> IDecVie_InventarioConocimientoEnfasisRepository.GetDataTableDecVie_InventarioConocimientoEnfasis(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_InventarioConocimientoEnfasis, bool>> srchByFunc = null;
            Expression<Func<DecVie_InventarioConocimientoEnfasis, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmenfasis.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_InventarioConocimientoEnfasis>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_InventarioConocimientoEnfasis> result = new DataTableAdapter<DecVie_InventarioConocimientoEnfasis>();

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