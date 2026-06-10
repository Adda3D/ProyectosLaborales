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
    public class Seguimiento_DesembolsoRepository : SuperType<Seguimiento_Desembolso>, ISeguimiento_DesembolsoRepository
    {
        private ApplicationDbContext _context;

        public Seguimiento_DesembolsoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_DesembolsoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimiento_Desembolso(int id_segdesembolso)
        {
            Delete(id_segdesembolso);
            return true;
        }

        public IEnumerable<Seguimiento_Desembolso> GetAllSeguimiento_Desembolso()
        {
            return Get();
        }

        public Seguimiento_Desembolso GetSeguimiento_DesembolsoDetails(int id_segdesembolso)
        {
            return Get(id_segdesembolso);
        }

        public bool InsertSeguimiento_Desembolso(Seguimiento_Desembolso seguimiento_Desembolso)
        {
            Add(seguimiento_Desembolso);
            return true;
        }

        public bool UpdateSeguimiento_Desembolso(Seguimiento_Desembolso seguimiento_Desembolso)
        {
            Update(seguimiento_Desembolso);
            return true;
        }

        public DataTableAdapter<Seguimiento_Desembolso> GetDataTableProyectoDesembolsosByProyecto(int id_asignacionproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Seguimiento_Desembolso, bool>> srchByFunc = null;
            Expression<Func<Seguimiento_Desembolso, string>> orderByFunc = null;
            Expression<Func<Seguimiento_Desembolso, DateTime>> orderByDateFunc = null;

            Expression<Func<Seguimiento_Desembolso, object>> parameter1 = m => m.ObjProyecto;
            Expression<Func<Seguimiento_Desembolso, object>>[] parameterArray = new Expression<Func<Seguimiento_Desembolso, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechadesembolso")
                orderByDateFunc = CreateExpressionOrderByDate<Seguimiento_Desembolso>("fechadesembolso");
            else
                orderByFunc = CreateExpressionOrderBy<Seguimiento_Desembolso>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_asignacionproyecto == id_asignacionproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_asignacionproyecto == id_asignacionproyecto;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            var data = (model.SortColumn.ToLower() == "fechadesembolso") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Seguimiento_Desembolso> result = new DataTableAdapter<Seguimiento_Desembolso>();

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