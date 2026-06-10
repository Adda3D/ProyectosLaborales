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
    public class DecVie_InventarioConocimientoSoporteRepository : SuperType<DecVie_InventarioConocimientoSoporte>, IDecVie_InventarioConocimientoSoporteRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InventarioConocimientoSoporteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InventarioConocimientoSoporteRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_InventarioConocimientoSoporte(int id_conocimientosoporte)
        {
            Delete(id_conocimientosoporte);
            return true;
        }

        public IEnumerable<DecVie_InventarioConocimientoSoporte> GetAllDecVie_InventarioConocimientoSoporte()
        {
            return Get();
        }

        public DecVie_InventarioConocimientoSoporte GetDecVie_InventarioConocimientoSoporteDetails(int id_conocimientosoporte)
        {
            return Get(id_conocimientosoporte);
        }

        public DecVie_InventarioConocimientoSoporte GetDecVie_InventarioConocimientoSoporteNombre(string cd_nmsoporte)
        {
            return Get(c => c.nmsoporte == cd_nmsoporte).FirstOrDefault();
        }

        public bool InsertDecVie_InventarioConocimientoSoporte(DecVie_InventarioConocimientoSoporte decVie_InventarioConocimientoSoporte)
        {
            Add(decVie_InventarioConocimientoSoporte);
            return true;
        }

        public bool UpdateDecVie_InventarioConocimientoSoporte(DecVie_InventarioConocimientoSoporte decVie_InventarioConocimientoSoporte)
        {
            Update(decVie_InventarioConocimientoSoporte);
            return true;
        }
        DataTableAdapter<DecVie_InventarioConocimientoSoporte> IDecVie_InventarioConocimientoSoporteRepository.GetDataTableDecVie_InventarioConocimientoSoporte(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_InventarioConocimientoSoporte, bool>> srchByFunc = null;
            Expression<Func<DecVie_InventarioConocimientoSoporte, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmsoporte.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_InventarioConocimientoSoporte>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_InventarioConocimientoSoporte> result = new DataTableAdapter<DecVie_InventarioConocimientoSoporte>();

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