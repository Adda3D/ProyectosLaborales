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
    public class DecVie_InventarioConocimientoTipologiaRepository : SuperType<DecVie_InventarioConocimientoTipologia>, IDecVie_InventarioConocimientoTipologiaRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InventarioConocimientoTipologiaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InventarioConocimientoTipologiaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_InventarioConocimientoTipologia(int id_conocimientotipologia)
        {
            Delete(id_conocimientotipologia);
            return true;
        }

        public IEnumerable<DecVie_InventarioConocimientoTipologia> GetAllDecVie_InventarioConocimientoTipologia()
        {

            return Get();
        }

        public DecVie_InventarioConocimientoTipologia GetDecVie_InventarioConocimientoTipologiaDetails(int id_conocimientotipologia)
        {
            return Get(id_conocimientotipologia);
        }

        public DecVie_InventarioConocimientoTipologia GetDecVie_InventarioConocimientoTipologiaNombre(string cd_nmtipologia)
        {
            return Get(c => c.nmtipologia == cd_nmtipologia).FirstOrDefault();
        }

        public bool insertDecVie_InventarioConocimientoTipologia(DecVie_InventarioConocimientoTipologia decVie_InventarioConocimientoTipologia)
        {
            Add(decVie_InventarioConocimientoTipologia);
            return true;
        }

        public bool UpdateDecVie_InventarioConocimientoTipologia(DecVie_InventarioConocimientoTipologia decVie_InventarioConocimientoTipologia)
        {
            Update(decVie_InventarioConocimientoTipologia);
            return true;
        }
        DataTableAdapter<DecVie_InventarioConocimientoTipologia> IDecVie_InventarioConocimientoTipologiaRepository.GetDataTableDecVie_InventarioConocimientoTipologia(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_InventarioConocimientoTipologia, bool>> srchByFunc = null;
            Expression<Func<DecVie_InventarioConocimientoTipologia, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipologia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_InventarioConocimientoTipologia>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_InventarioConocimientoTipologia> result = new DataTableAdapter<DecVie_InventarioConocimientoTipologia>();

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