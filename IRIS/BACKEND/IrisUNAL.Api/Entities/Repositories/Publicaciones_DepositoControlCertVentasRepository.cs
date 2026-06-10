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
    public class Publicaciones_DepositoControlCertVentasRepository : SuperType<Publicaciones_DepositoControlCertVentas>, IPublicaciones_DepositoControlCertVentasRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoControlCertVentasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoControlCertVentasRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoControlCertVentas(int id_certventas)
        {
            Delete(id_certventas);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoControlCertVentas> GetAllPublicaciones_DepositoControlCertVentas()
        {
            return Get();
        }

        public Publicaciones_DepositoControlCertVentas GetPublicaciones_DepositoControlCertVentasDetails(int id_certventas)
        {
            return Get(id_certventas);
        }

        public bool InsertPublicaciones_DepositoControlCertVentas(Publicaciones_DepositoControlCertVentas publicaciones_DepositoControlCertVentas)
        {
            Add(publicaciones_DepositoControlCertVentas);
            return true;
        }

        public bool UpdatePublicaciones_DepositoControlCertVentas(Publicaciones_DepositoControlCertVentas publicaciones_DepositoControlCertVentas)
        {
            Update(publicaciones_DepositoControlCertVentas);
            return true;
        }

        public DataTableAdapter<Publicaciones_DepositoControlCertVentas> GetDataTablePublicaciones_DepositoControlCertVentasByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DepositoControlCertVentas, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DepositoControlCertVentas, string>> orderByFunc = null;
            Expression<Func<Publicaciones_DepositoControlCertVentas, DateTime>> orderByDateFunc = null;
            Expression<Func<Publicaciones_DepositoControlCertVentas, int>> orderByIntFunc = null;

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "id_certventas")
                orderByIntFunc = CreateExpressionOrderByInt<Publicaciones_DepositoControlCertVentas>("id_certventas");
            else
                if (model.SortColumn.ToLower() == "fecenvio")
                orderByDateFunc = CreateExpressionOrderByDate<Publicaciones_DepositoControlCertVentas>("fecenvio");


            //FILTRA POR LA PUBLICACION
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearpublicacion == id_crearpublicacion;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();

            var data = (model.SortColumn.ToLower() == "fecenvio") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DepositoControlCertVentas> result = new DataTableAdapter<Publicaciones_DepositoControlCertVentas>();

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