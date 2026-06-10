using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Publicacion;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Publicacion
{
    public class Publicacion_AplicarpagoRepository : SuperType<Publicacion_Aplicarpago>
    {
        private ApplicationDbContext _context;

        public Publicacion_AplicarpagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicacion_AplicarpagoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeletePublicacion_Aplicarpago(int id_publicacionpago)
        {
            Delete(id_publicacionpago);
            return true;
        }

        public IEnumerable<Publicacion_Aplicarpago> GetAllPublicacion_Aplicarpago()
        {
            return Get();
        }

        public Publicacion_Aplicarpago GetPublicacion_AplicarpagoDetails(int id_publicacionpago)
        {
            return Get(id_publicacionpago);
        }

        public bool InsertPublicacion_Aplicarpago(Publicacion_Aplicarpago _publicacion_aplicarpago)
        {
            Add(_publicacion_aplicarpago);
            return true;
        }

        public bool UpdatePublicacion_Aplicarpago(Publicacion_Aplicarpago _publicacion_aplicarpago)
        {
            Update(_publicacion_aplicarpago);
            return true;
        }

        public DataTableAdapter<Publicacion_Aplicarpago> GetDataTablePagosByPublicacionGasto(int id_publicaciongasto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicacion_Aplicarpago, bool>> srchByFunc = null;
            Expression<Func<Publicacion_Aplicarpago, string>> orderByFunc = null;
            Expression<Func<Publicacion_Aplicarpago, DateTime>> orderByDateFunc = null;

            Expression<Func<Publicacion_Aplicarpago, object>> parameter1 = m => m.ObjSemestre;
            //Expression<Func<Publicacion_Aplicarpago, object>> parameter2 = m => m.objConcepto;
            Expression<Func<Publicacion_Aplicarpago, object>>[] parameterArray = new Expression<Func<Publicacion_Aplicarpago, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechapago")
                orderByDateFunc = CreateExpressionOrderByDate<Publicacion_Aplicarpago>("fechapago");
            else
                orderByFunc = CreateExpressionOrderBy<Publicacion_Aplicarpago>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_publicaciongasto == id_publicaciongasto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_publicaciongasto == id_publicaciongasto && d.orpa.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            var data = (model.SortColumn.ToLower() == "fechapago") ?
                Get(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc).ToList() :
                Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicacion_Aplicarpago> result = new DataTableAdapter<Publicacion_Aplicarpago>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Publicacion_Aplicarpago> GetDataTablePublicacion_AplicarpagoByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicacion_Aplicarpago, bool>> srchByFunc = null;
            Expression<Func<Publicacion_Aplicarpago, string>> orderByFunc = null;
            Expression<Func<Publicacion_Aplicarpago, DateTime>> orderByDateFunc = null;

            Expression<Func<Publicacion_Aplicarpago, object>> parameter1 = m => m.ObjGasto;
            Expression<Func<Publicacion_Aplicarpago, object>> parameter2 = m => m.ObjGasto.ObjPersona;
            Expression<Func<Publicacion_Aplicarpago, object>> parameter3 = m => m.ObjGasto.ObjRubro;
            Expression<Func<Publicacion_Aplicarpago, object>> parameter4 = m => m.ObjGasto.ObjConcepto;
            Expression<Func<Publicacion_Aplicarpago, object>>[] parameterArray = new Expression<Func<Publicacion_Aplicarpago, object>>[] { parameter1, parameter2, parameter3, parameter4 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechapago")
                orderByDateFunc = CreateExpressionOrderByDate<Publicacion_Aplicarpago>("fechapago");
            else
                orderByFunc = CreateExpressionOrderBy<Publicacion_Aplicarpago>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearpublicacion == id_crearpublicacion && d.orpa.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fechapago") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();


            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicacion_Aplicarpago> result = new DataTableAdapter<Publicacion_Aplicarpago>();

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