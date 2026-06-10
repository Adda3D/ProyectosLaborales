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
    public class DecVie_SubSerieDocRepository : SuperType<DecVie_SubSerieDoc>, IDecVie_SubSerieDocRepository
    {
        private ApplicationDbContext _context;

        public DecVie_SubSerieDocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_SubSerieDocRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_SubSerieDoc(int id_subseriedoc)
        {
            Delete(id_subseriedoc);
            return true;
        }

        public IEnumerable<DecVie_SubSerieDoc> GetAllDecVie_SubSerieDoc()
        {
            return Get();
        }

        public DecVie_SubSerieDoc GetDecVie_SubSerieDocDetails(int id_subseriedoc)
        {
            return Get(id_subseriedoc);
        }

        public DecVie_SubSerieDoc GetDecVie_SubSerieDocNombre(string cd_nmsubseriedoc)
        {
            return Get(c => c.nmsubseriedoc == cd_nmsubseriedoc).FirstOrDefault();
        }

        public bool InsertDecVie_SubSerieDoc(DecVie_SubSerieDoc decVie_SubSerieDoc)
        {
            Add(decVie_SubSerieDoc);
            return true;
        }

        public bool UpdateDecVie_SubSerieDoc(DecVie_SubSerieDoc decVie_SubSerieDoc)
        {
            Update(decVie_SubSerieDoc);
            return true;
        }        

        DataTableAdapter<DecVie_SubSerieDoc> IDecVie_SubSerieDocRepository.GetDataTableDecVie_SubSerieDoc(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_SubSerieDoc, bool>> srchByFunc = null;
            Expression<Func<DecVie_SubSerieDoc, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmsubseriedoc.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_SubSerieDoc>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_SubSerieDoc> result = new DataTableAdapter<DecVie_SubSerieDoc>();

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