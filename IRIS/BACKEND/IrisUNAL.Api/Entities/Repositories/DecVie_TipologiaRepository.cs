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
    public class DecVie_TipologiaRepository : SuperType<DecVie_Tipologia>, IDecVie_TipologiaRepository
    {
        private ApplicationDbContext _context;

        public DecVie_TipologiaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_TipologiaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_Tipologia(int id_decvietipologia)
        {
            Delete(id_decvietipologia);
            return true;
        }

        public IEnumerable<DecVie_Tipologia> GetAllDecVie_Tipologia()
        {
            return Get();
        }

        public DecVie_Tipologia GetDecVie_TipologiaDetails(int id_decvietipologia)
        {
            return Get(id_decvietipologia);
        }

        public DecVie_Tipologia GetDecVie_TipologiaNombre(string cd_nmdecvietipologia)
        {
            return Get(c => c.nmdecvietipologia == cd_nmdecvietipologia).FirstOrDefault();
        }

        public bool InsertDecVie_Tipologia(DecVie_Tipologia decVie_Tipologia)
        {
            Add(decVie_Tipologia);
            return true;
        }

        public bool UpdateDecVie_Tipologia(DecVie_Tipologia decVie_Tipologia)
        {
            Update(decVie_Tipologia);
            return true;
        }

        public DataTableAdapter<DecVie_Tipologia> GetDataTableDecVieTipologia(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_Tipologia, bool>> srchByFunc = null;
            Expression<Func<DecVie_Tipologia, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmdecvietipologia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_Tipologia>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_Tipologia> result = new DataTableAdapter<DecVie_Tipologia>();

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