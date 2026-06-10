using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Investigacion;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Investigacion
{
    public class Investigacion_DesembolsoRepository : SuperType<Investigacion_Desembolso>
    {
        private ApplicationDbContext _context;

        public Investigacion_DesembolsoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_DesembolsoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteInvestigacion_Desembolso(int id_desembolso)
        {
            Delete(id_desembolso);
            return true;
        }

        public Investigacion_Desembolso GetInvestigacion_DesembolsoDetails(int id_desembolso)
        {
            return Get(id_desembolso);
        }

        public bool InsertInvestigacion_Desembolso(Investigacion_Desembolso _investigacion_desembolso)
        {
            Add(_investigacion_desembolso);
            return true;
        }

        public bool UpdateInvestigacion_Desembolso(Investigacion_Desembolso _investigacion_desembolso)
        {
            Update(_investigacion_desembolso);
            return true;
        }

        public DataTableAdapter<Investigacion_Desembolso> GetDataTableInvestigacion_DesembolsoByProyecto(int id_crearproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_Desembolso, bool>> srchByFunc = null;
            Expression<Func<Investigacion_Desembolso, string>> orderByFunc = null;
            Expression<Func<Investigacion_Desembolso, DateTime>> orderByDateFunc = null;
//            Expression<Func<Investigacion_Desembolso, int>> orderByIntFunc = null;

            Expression<Func<Investigacion_Desembolso, object>> parameter1 = m => m.ObjProyecto;
            Expression<Func<Investigacion_Desembolso, object>>[] parameterArray = new Expression<Func<Investigacion_Desembolso, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechadesembolso")
                orderByDateFunc = CreateExpressionOrderByDate<Investigacion_Desembolso>("fechadesembolso");
            else
                orderByFunc = CreateExpressionOrderBy<Investigacion_Desembolso>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_crearproyecto == id_crearproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearproyecto == id_crearproyecto;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fechadesembolso") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_Desembolso> result = new DataTableAdapter<Investigacion_Desembolso>();

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