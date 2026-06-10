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
    public class DecVie_InventarioConocimientoContratanteRepository : SuperType<DecVie_InventarioConocimientoContratante>, IDecVie_InventarioConocimientoContratanteRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InventarioConocimientoContratanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InventarioConocimientoContratanteRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_InventarioConocimientoContratante(int id_conocimientocontratante)
        {
            Delete(id_conocimientocontratante);
            return true;
        }

        public IEnumerable<DecVie_InventarioConocimientoContratante> GetAllDecVie_InventarioConocimientoContratante()
        {
            return Get();
        }

        public DecVie_InventarioConocimientoContratante GetDecVie_InventarioConocimientoContratanteDetails(int id_conocimientocontratante)
        {
            return Get(id_conocimientocontratante);
        }

        public DecVie_InventarioConocimientoContratante GetDecVie_InventarioConocimientoContratanteNombre(string cd_nmcontratante)
        {
            return Get(c => c.nmcontratante == cd_nmcontratante).FirstOrDefault();
        }

        public bool InsertDecVie_InventarioConocimientoContratante(DecVie_InventarioConocimientoContratante decVie_InventarioConocimientoContratante)
        {
            Add(decVie_InventarioConocimientoContratante);
            return true;
        }

        public bool UpdateDecVie_InventarioConocimientoContratante(DecVie_InventarioConocimientoContratante decVie_InventarioConocimientoContratante)
        {
            Update(decVie_InventarioConocimientoContratante);
            return true;
        }
        DataTableAdapter<DecVie_InventarioConocimientoContratante> IDecVie_InventarioConocimientoContratanteRepository.GetDataTableDecVie_InventarioConocimientoContratante(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_InventarioConocimientoContratante, bool>> srchByFunc = null;
            Expression<Func<DecVie_InventarioConocimientoContratante, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmcontratante.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_InventarioConocimientoContratante>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_InventarioConocimientoContratante> result = new DataTableAdapter<DecVie_InventarioConocimientoContratante>();

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