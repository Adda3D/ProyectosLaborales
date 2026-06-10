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
    public class DecVie_InventarioUsoAmpliadoInsumoRepository : SuperType<DecVie_InventarioUsoAmpliadoInsumo>, IDecVie_InventarioUsoAmpliadoInsumoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InventarioUsoAmpliadoInsumoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InventarioUsoAmpliadoInsumoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_InventarioUsoAmpliadoInsumo(int id_insumo)
        {
            Delete(id_insumo);
            return true;
        }

        public IEnumerable<DecVie_InventarioUsoAmpliadoInsumo> GetAllDecVie_InventarioUsoAmpliadoInsumo()
        {
            return Get();
        }

        public DecVie_InventarioUsoAmpliadoInsumo GetDecVie_InventarioUsoAmpliadoInsumoDetails(int id_insumo)
        {
            return Get(id_insumo);
        }

        public DecVie_InventarioUsoAmpliadoInsumo GetDecVie_InventarioUsoAmpliadoInsumoNombre(string cd_nminsumo)
        {
            return Get(c => c.nminsumo == cd_nminsumo).FirstOrDefault();
        }

        public bool InsertDecVie_InventarioUsoAmpliadoInsumo(DecVie_InventarioUsoAmpliadoInsumo decVie_InventarioUsoAmpliadoInsumo)
        {
            Add(decVie_InventarioUsoAmpliadoInsumo);
            return true;
        }

        public bool UpdateDecVie_InventarioUsoAmpliadoInsumo(DecVie_InventarioUsoAmpliadoInsumo decVie_InventarioUsoAmpliadoInsumo)
        {
            Update(decVie_InventarioUsoAmpliadoInsumo);
            return true;
        }
        DataTableAdapter<DecVie_InventarioUsoAmpliadoInsumo> IDecVie_InventarioUsoAmpliadoInsumoRepository.GetDataTableDecVie_InventarioUsoAmpliadoInsumo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_InventarioUsoAmpliadoInsumo, bool>> srchByFunc = null;
            Expression<Func<DecVie_InventarioUsoAmpliadoInsumo, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nminsumo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_InventarioUsoAmpliadoInsumo>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_InventarioUsoAmpliadoInsumo> result = new DataTableAdapter<DecVie_InventarioUsoAmpliadoInsumo>();

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