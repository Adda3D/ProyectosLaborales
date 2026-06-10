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
    public class DecVie_InventarioObsolescenciaConceptoRepository : SuperType<DecVie_InventarioObsolescenciaConcepto>, IDecVie_InventarioObsolescenciaConceptoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InventarioObsolescenciaConceptoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InventarioObsolescenciaConceptoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_InventarioObsolescenciaConcepto(int id_obsolescenciaconcepto)
        {
            Delete(id_obsolescenciaconcepto);
            return true;
        }

        public IEnumerable<DecVie_InventarioObsolescenciaConcepto> GetAllDecVie_InventarioObsolescenciaConcepto()
        {
            return Get();
        }

        public DecVie_InventarioObsolescenciaConcepto GetDecVie_InventarioObsolescenciaConceptoDetails(int id_obsolescenciaconcepto)
        {
            return Get(id_obsolescenciaconcepto);
        }

        public DecVie_InventarioObsolescenciaConcepto GetDecVie_InventarioObsolescenciaConceptoNombre(string cd_nmconcepto)
        {
            return Get(c => c.nmconcepto == cd_nmconcepto).FirstOrDefault();
        }

        public bool InsertDecVie_InventarioObsolescenciaConcepto(DecVie_InventarioObsolescenciaConcepto decVie_InventarioObsolescenciaConcepto)
        {
            Add(decVie_InventarioObsolescenciaConcepto);
            return true;
        }

        public bool UpdateDecVie_InventarioObsolescenciaConcepto(DecVie_InventarioObsolescenciaConcepto decVie_InventarioObsolescenciaConcepto)
        {
            Update(decVie_InventarioObsolescenciaConcepto);
            return true;
        }
        DataTableAdapter<DecVie_InventarioObsolescenciaConcepto> IDecVie_InventarioObsolescenciaConceptoRepository.GetDataTableDecVie_InventarioObsolescenciaConcepto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_InventarioObsolescenciaConcepto, bool>> srchByFunc = null;
            Expression<Func<DecVie_InventarioObsolescenciaConcepto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmconcepto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_InventarioObsolescenciaConcepto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_InventarioObsolescenciaConcepto> result = new DataTableAdapter<DecVie_InventarioObsolescenciaConcepto>();

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