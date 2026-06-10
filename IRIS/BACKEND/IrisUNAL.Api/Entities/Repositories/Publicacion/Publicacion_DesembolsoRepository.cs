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
    public class Publicacion_DesembolsoRepository : SuperType<Publicacion_Desembolso>
    {
        private ApplicationDbContext _context;

        public Publicacion_DesembolsoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicacion_DesembolsoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeletePublicacion_Desembolso(int id_desembolso)
        {
            Delete(id_desembolso);
            return true;
        }

        public Publicacion_Desembolso GetPublicacion_DesembolsoDetails(int id_desembolso)
        {
            return Get(id_desembolso);
        }

        public bool InsertPublicacion_Desembolso(Publicacion_Desembolso _publicacion_desembolso)
        {
            Add(_publicacion_desembolso);
            return true;
        }

        public bool UpdatePublicacion_Desembolso(Publicacion_Desembolso _publicacion_desembolso)
        {
            Update(_publicacion_desembolso);
            return true;
        }

        public DataTableAdapter<Publicacion_Desembolso> GetDataTablePublicacion_DesembolsoByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicacion_Desembolso, bool>> srchByFunc = null;
            Expression<Func<Publicacion_Desembolso, string>> orderByFunc = null;
            Expression<Func<Publicacion_Desembolso, DateTime>> orderByDateFunc = null;
            //            Expression<Func<Publicacion_Desembolso, int>> orderByIntFunc = null;

            Expression<Func<Publicacion_Desembolso, object>> parameter1 = m => m.ObjPublicacion;
            Expression<Func<Publicacion_Desembolso, object>>[] parameterArray = new Expression<Func<Publicacion_Desembolso, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechadesembolso")
                orderByDateFunc = CreateExpressionOrderByDate<Publicacion_Desembolso>("fechadesembolso");
            else
                orderByFunc = CreateExpressionOrderBy<Publicacion_Desembolso>(model.SortColumn);


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

            var data = (model.SortColumn.ToLower() == "fechadesembolso") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicacion_Desembolso> result = new DataTableAdapter<Publicacion_Desembolso>();

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