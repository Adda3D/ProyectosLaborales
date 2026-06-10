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
    public class Publicaciones_DistribuidorRepository : SuperType<Publicaciones_Distribuidor>
    {
        private ApplicationDbContext _context;

        public Publicaciones_DistribuidorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DistribuidorRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Publicaciones_Distribuidor> GetAllPublicaciones_Distribuidor()
        {
            return Get();
        }

        public Publicaciones_Distribuidor GetPublicaciones_DistribuidorDetails(int iddistribuidor)
        {
            return Get(iddistribuidor);
        }

        public bool InsertPublicaciones_Distribuidor(Publicaciones_Distribuidor _publicaciones_distribuidor)
        {
            Add(_publicaciones_distribuidor);
            return true;
        }

        public bool UpdatePublicaciones_Distribuidor(Publicaciones_Distribuidor _publicaciones_distribuidor)
        {
            Update(_publicaciones_distribuidor);
            return true;
        }

        public bool DeletePublicaciones_Distribuidor(int iddistribuidor)
        {
            Delete(iddistribuidor);
            return true;
        }

        public DataTableAdapter<Publicaciones_Distribuidor> GetDataTablePublicaciones_Distribuidor(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_Distribuidor, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_Distribuidor, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.distribuidor.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_Distribuidor>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_Distribuidor> result = new DataTableAdapter<Publicaciones_Distribuidor>();

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