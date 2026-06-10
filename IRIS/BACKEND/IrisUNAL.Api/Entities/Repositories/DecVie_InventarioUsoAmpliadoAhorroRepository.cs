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
    public class DecVie_InventarioUsoAmpliadoAhorroRepository : SuperType<DecVie_InventarioUsoAmpliadoAhorro>, IDecVie_InventarioUsoAmpliadoAhorroRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InventarioUsoAmpliadoAhorroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InventarioUsoAmpliadoAhorroRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_InventarioUsoAmpliadoAhorro(int id_ahorro)
        {
            Delete(id_ahorro);
            return true;
        }

        public IEnumerable<DecVie_InventarioUsoAmpliadoAhorro> GetAllDecVie_InventarioUsoAmpliadoAhorro()
        {
            return Get();
        }

        public DecVie_InventarioUsoAmpliadoAhorro GetDecVie_InventarioUsoAmpliadoAhorroDetails(int id_ahorro)
        {
            return Get(id_ahorro);
        }

        public DecVie_InventarioUsoAmpliadoAhorro GetDecVie_InventarioUsoAmpliadoAhorroNombre(string cd_nmahorro)
        {
            return Get(c => c.nmahorro == cd_nmahorro).FirstOrDefault();
        }

        public bool InsertDecVie_InventarioUsoAmpliadoAhorro(DecVie_InventarioUsoAmpliadoAhorro decVie_InventarioUsoAmpliadoAhorro)
        {
            Add(decVie_InventarioUsoAmpliadoAhorro);
            return true;
        }

        public bool UpdateDecVie_InventarioUsoAmpliadoAhorro(DecVie_InventarioUsoAmpliadoAhorro decVie_InventarioUsoAmpliadoAhorro)
        {
            Update(decVie_InventarioUsoAmpliadoAhorro);
            return true;
        }
        DataTableAdapter<DecVie_InventarioUsoAmpliadoAhorro> IDecVie_InventarioUsoAmpliadoAhorroRepository.GetDataTableDecVie_InventarioUsoAmpliadoAhorro(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_InventarioUsoAmpliadoAhorro, bool>> srchByFunc = null;
            Expression<Func<DecVie_InventarioUsoAmpliadoAhorro, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmahorro.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_InventarioUsoAmpliadoAhorro>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_InventarioUsoAmpliadoAhorro> result = new DataTableAdapter<DecVie_InventarioUsoAmpliadoAhorro>();

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