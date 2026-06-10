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
    public class DecVie_InventarioRegistroPatenteTipoRepository : SuperType<DecVie_InventarioRegistroPatenteTipo>, IDecVie_InventarioRegistroPatenteTipoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InventarioRegistroPatenteTipoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InventarioRegistroPatenteTipoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_InventarioRegistroPatenteTipo(int id_patentetipo)
        {
            Delete(id_patentetipo);
            return true;
        }

        public IEnumerable<DecVie_InventarioRegistroPatenteTipo> GetAllDecVie_InventarioRegistroPatenteTipo()
        {
            return Get();
        }

        public DecVie_InventarioRegistroPatenteTipo GetDecVie_InventarioRegistroPatenteTipoDetails(int id_patentetipo)
        {
            return Get(id_patentetipo);
        }

        public DecVie_InventarioRegistroPatenteTipo GetDecVie_InventarioRegistroPatenteTipoNombre(string cd_nmpatentetipo)
        {
            return Get(c => c.nmpatentetipo == cd_nmpatentetipo).FirstOrDefault();
        }

        public bool InsertDecVie_InventarioRegistroPatenteTipo(DecVie_InventarioRegistroPatenteTipo decVie_InventarioRegistroPatenteTipo)
        {
            Add(decVie_InventarioRegistroPatenteTipo);
            return true;
        }

        public bool UpdateDecVie_InventarioRegistroPatenteTipo(DecVie_InventarioRegistroPatenteTipo decVie_InventarioRegistroPatenteTipo)
        {
            Update(decVie_InventarioRegistroPatenteTipo);
            return true;
        }
        DataTableAdapter<DecVie_InventarioRegistroPatenteTipo> IDecVie_InventarioRegistroPatenteTipoRepository.GetDataTableDecVie_InventarioRegistroPatenteTipo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_InventarioRegistroPatenteTipo, bool>> srchByFunc = null;
            Expression<Func<DecVie_InventarioRegistroPatenteTipo, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmpatentetipo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_InventarioRegistroPatenteTipo>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_InventarioRegistroPatenteTipo> result = new DataTableAdapter<DecVie_InventarioRegistroPatenteTipo>();

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