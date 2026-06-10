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
    public class Seguimiento_AcuerdoRepository : SuperType<Seguimiento_Acuerdo>
    {
        private ApplicationDbContext _context;

        public Seguimiento_AcuerdoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_AcuerdoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Seguimiento_Acuerdo> GetAllSeguimiento_Acuerdo()
        {
            return Get();
        }

        public Seguimiento_Acuerdo GetSeguimiento_AcuerdoDetails(int idacuerdo)
        {
            return Get(idacuerdo);
        }

        public Seguimiento_Acuerdo GetSeguimiento_AcuerdoNroAcuerdo(string nroacuerdo)
        {
            return Get(a => a.nroacuerdo == nroacuerdo).FirstOrDefault();
        }

        public bool InsertSeguimiento_Acuerdo(Seguimiento_Acuerdo seguimiento_acuerdo)
        {
            Add(seguimiento_acuerdo);
            return true;
        }
        public bool UpdateSeguimiento_Acuerdo(Seguimiento_Acuerdo seguimiento_acuerdo)
        {
            Update(seguimiento_acuerdo);
            return true;

        }
        public bool DeleteSeguimiento_Acuerdo(int idacuerdo)
        {
            Delete(idacuerdo);
            return true;
        }
        public DataTableAdapter<Seguimiento_Acuerdo> GetDataTableSeguimiento_Acuerdo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Seguimiento_Acuerdo, bool>> srchByFunc = null;
            Expression<Func<Seguimiento_Acuerdo, string>> orderByFunc = null;

            Expression<Func<Seguimiento_Acuerdo, object>> parameter1 = v => v.ObjProyecto;
            Expression<Func<Seguimiento_Acuerdo, object>>[] parameterArray = new Expression<Func<Seguimiento_Acuerdo, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nroacuerdo.ToLower().Contains(model.SearchValue.ToLower()) || d.nombreacuerdo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Seguimiento_Acuerdo>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();
            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Seguimiento_Acuerdo> result = new DataTableAdapter<Seguimiento_Acuerdo>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Seguimiento_Acuerdo> GetDataTableSeguimiento_AcuerdoByProyecto(int id_asignacionproyecto, DataTableRequest model)
        {
            var totalRows = 0; // Count();
            var RowsFiltered = totalRows;

            Expression<Func<Seguimiento_Acuerdo, bool>> srchByFunc = null;
            Expression<Func<Seguimiento_Acuerdo, string>> orderByFunc = null;
            Expression<Func<Seguimiento_Acuerdo, DateTime>> orderByDateFunc = null;

            //Expression<Func<Seguimiento_Acuerdo, object>> parameter1 = v => v.ObjProyecto;
            //Expression<Func<Seguimiento_Acuerdo, object>>[] parameterArray = new Expression<Func<Seguimiento_Acuerdo, object>>[] { parameter1 };

            bool isOrderDesc = false;

            //FILTRA POR LA PROYECTO
            srchByFunc = p => p.id_asignacionproyecto == id_asignacionproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = p => p.id_asignacionproyecto == id_asignacionproyecto && (p.nroacuerdo.ToLower().Contains(model.SearchValue.ToLower()) || p.nombreacuerdo.ToLower().Contains(model.SearchValue.ToLower()));
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn.ToLower() == "iniciaacuerdo")
                orderByDateFunc = CreateExpressionOrderByDate<Seguimiento_Acuerdo>("iniciaacuerdo");
            else
                orderByFunc = CreateExpressionOrderBy<Seguimiento_Acuerdo>(model.SortColumn);

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //var data = (model.SortColumn.ToLower() == "strfechaseguimiento") ?
            //    GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
            //    GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter <Seguimiento_Acuerdo> result = new DataTableAdapter<Seguimiento_Acuerdo>();

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