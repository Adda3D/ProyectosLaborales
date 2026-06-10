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
    public class DecVie_RevSigepRepository : SuperType<DecVie_RevSigep>, IDecVie_RevSigepRepository
    {
        private ApplicationDbContext _context;

        public DecVie_RevSigepRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_RevSigepRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_RevSigep(int id_revsigep)
        {
            Delete(id_revsigep);
            return true;
        }

        public IEnumerable<DecVie_RevSigep> GetAllDecVie_RevSigep()
        {
            return Get();
        }

        public DecVie_RevSigep GetDecVie_RevSigepDetails(int id_revsigep)
        {
            return Get(id_revsigep);
        }

        public DecVie_RevSigep GetDecVie_RevSigepNombre(string cd_nmrevsigep)
        {
            return Get(c => c.nmrevsigep == cd_nmrevsigep).FirstOrDefault();
        }

        public bool InsertDecVie_RevSigep(DecVie_RevSigep decVie_RevSigep)
        {
            Add(decVie_RevSigep);
            return true;
        }

        public bool UpdateDecVie_RevSigep(DecVie_RevSigep decVie_RevSigep)
        {
            Update(decVie_RevSigep);
            return true;
        }
        DataTableAdapter<DecVie_RevSigep> IDecVie_RevSigepRepository.GetDataTableDecVie_RevSigep(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_RevSigep, bool>> srchByFunc = null;
            Expression<Func<DecVie_RevSigep, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmrevsigep.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_RevSigep>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_RevSigep> result = new DataTableAdapter<DecVie_RevSigep>();

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