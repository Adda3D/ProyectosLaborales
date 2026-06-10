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
    public class Publicaciones_DepositoDisposicionLegalRepository : SuperType<Publicaciones_DepositoDisposicionLegal>
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoDisposicionLegalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoDisposicionLegalRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Publicaciones_DepositoDisposicionLegal> GetAllPublicaciones_DepositoDisposicionLegal()
        {
            return Get();
        }

        public Publicaciones_DepositoDisposicionLegal GetPublicaciones_DepositoDisposicionLegalDetails(int iddisposicionlegal)
        {
            return Get(iddisposicionlegal);
        }

        public bool InsertPublicaciones_DepositoDisposicionLegal(Publicaciones_DepositoDisposicionLegal publicaciones_depositodisposicionlegal)
        {
            Add(publicaciones_depositodisposicionlegal);
            return true;
        }

        public bool UpdatePublicaciones_DepositoDisposicionLegal(Publicaciones_DepositoDisposicionLegal publicaciones_depositodisposicionlegal)
        {
            Update(publicaciones_depositodisposicionlegal);
            return true;
        }

        public bool DeletePublicaciones_DepositoDisposicionLegal(int iddisposicionlegal)
        {
            Delete(iddisposicionlegal);
            return true;
        }

        public DataTableAdapter<Publicaciones_DepositoDisposicionLegal> GetDataTablePublicaciones_DepositoDisposicionLegal(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DepositoDisposicionLegal, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DepositoDisposicionLegal, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.disposicionlegal.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_DepositoDisposicionLegal>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DepositoDisposicionLegal> result = new DataTableAdapter<Publicaciones_DepositoDisposicionLegal>();

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