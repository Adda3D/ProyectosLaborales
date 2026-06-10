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
    public class DecVie_InventarioConocimientoImpactoRepository : SuperType<DecVie_InventarioConocimientoImpacto>, IDecVie_InventarioConocimientoImpactoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InventarioConocimientoImpactoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InventarioConocimientoImpactoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_InventarioConocimientoImpacto(int id_conocimientoimpacto)
        {
            Delete(id_conocimientoimpacto);
            return true;
        }

        public IEnumerable<DecVie_InventarioConocimientoImpacto> GetAllDecVie_InventarioConocimientoImpacto()
        {
            return Get();
        }

        public DecVie_InventarioConocimientoImpacto GetDecVie_InventarioConocimientoImpactoDetails(int id_conocimientoimpacto)
        {
            return Get(id_conocimientoimpacto);
        }

        public DecVie_InventarioConocimientoImpacto GetDecVie_InventarioConocimientoImpactoNombre(string cd_nmimpacto)
        {
            return Get(c => c.nmimpacto == cd_nmimpacto).FirstOrDefault();
        }

        public bool InsertDecVie_InventarioConocimientoImpacto(DecVie_InventarioConocimientoImpacto decVie_InventarioConocimientoImpacto)
        {
            Add(decVie_InventarioConocimientoImpacto);
            return true;
        }

        public bool UpdateDecVie_InventarioConocimientoImpacto(DecVie_InventarioConocimientoImpacto decVie_InventarioConocimientoImpacto)
        {
            Update(decVie_InventarioConocimientoImpacto);
            return true;
        }
        DataTableAdapter<DecVie_InventarioConocimientoImpacto> IDecVie_InventarioConocimientoImpactoRepository.GetDataTableDecVie_InventarioConocimientoImpacto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_InventarioConocimientoImpacto, bool>> srchByFunc = null;
            Expression<Func<DecVie_InventarioConocimientoImpacto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmimpacto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_InventarioConocimientoImpacto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_InventarioConocimientoImpacto> result = new DataTableAdapter<DecVie_InventarioConocimientoImpacto>();

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