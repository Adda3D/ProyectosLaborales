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
    public class DecVie_SerieDocumentalRepository : SuperType<DecVie_SerieDocumental>, IDecVie_SerieDocumentalRepository
    {
        private ApplicationDbContext _context;

        public DecVie_SerieDocumentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_SerieDocumentalRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_SerieDocumental(int id_seriedocumental)
        {
            Delete(id_seriedocumental);
            return true;
        }

        public IEnumerable<DecVie_SerieDocumental> GetAllDecVie_SerieDocumental()
        {
            return Get();
        }

        public DecVie_SerieDocumental GetDecVie_SerieDocumentalDetails(int id_seriedocumental)
        {
            return Get(id_seriedocumental);
        }

        public DecVie_SerieDocumental GetDecVie_SerieDocumentalNombre(string cd_nminstancia)
        {
            return Get(c => c.nminstancia == cd_nminstancia).FirstOrDefault();
        }

        public bool InsertDecVie_SerieDocumental(DecVie_SerieDocumental decVie_SerieDocumental)
        {
            Add(decVie_SerieDocumental);
            return true;
        }

        public bool UpdateDecVie_SerieDocumental(DecVie_SerieDocumental decVie_SerieDocumental)
        {
            Update(decVie_SerieDocumental);
            return true;
        }

        DataTableAdapter<DecVie_SerieDocumental> IDecVie_SerieDocumentalRepository.GetDataTableDecVie_SerieDocumental(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_SerieDocumental, bool>> srchByFunc = null;
            Expression<Func<DecVie_SerieDocumental, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nminstancia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_SerieDocumental>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_SerieDocumental> result = new DataTableAdapter<DecVie_SerieDocumental>();

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