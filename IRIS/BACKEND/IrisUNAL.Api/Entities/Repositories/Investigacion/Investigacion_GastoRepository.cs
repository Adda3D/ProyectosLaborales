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
    public class Investigacion_GastoRepository : SuperType<Investigacion_Gasto>
    {
        private ApplicationDbContext _context;

        public Investigacion_GastoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_GastoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteInvestigacion_Gasto(int id_investigaciongasto)
        {
            Delete(id_investigaciongasto);
            return true;
        }

        public IEnumerable<Investigacion_Gasto> GetAllInvestigacion_Gasto()
        {
            return Get();
        }

        public Investigacion_Gasto GetInvestigacion_GastoDetails(int id_investigaciongasto)
        {
            return Get(id_investigaciongasto);
        }

        public bool InsertInvestigacion_Gasto(Investigacion_Gasto _investigacion_gasto)
        {
            Console.WriteLine("Resolucion ID (Insert): " + _investigacion_gasto.resolucion_id);  // Debug: Verifica si está llegando el valor
            Add(_investigacion_gasto);  // Se inserta el objeto completo, incluido resolucion_id
            return true;
        }

        public bool UpdateInvestigacion_Gasto(Investigacion_Gasto _investigacion_gasto)
        {
            Console.WriteLine("Resolucion ID (Update): " + _investigacion_gasto.resolucion_id);  // Debug: Verifica si está llegando el valor
            Update(_investigacion_gasto);  // Se actualiza el objeto completo, incluido resolucion_id
            return true;
        }



        //Cmbio ADDA para busqueda por identificación
        public DataTableAdapter<Investigacion_Gasto> GetDataTableInvestigacion_GastoByProyecto(int id_crearproyecto, int id_partida, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_Gasto, bool>> srchByFunc = null;
            Expression<Func<Investigacion_Gasto, string>> orderByFunc = null;
            Expression<Func<Investigacion_Gasto, DateTime>> orderByDateFunc = null;

            Expression<Func<Investigacion_Gasto, object>> parameter1 = m => m.ObjPersona;
            Expression<Func<Investigacion_Gasto, object>> parameter2 = m => m.ObjConcepto;
            Expression<Func<Investigacion_Gasto, object>> parameter3 = m => m.ObjRubro;
            Expression<Func<Investigacion_Gasto, object>>[] parameterArray = new Expression<Func<Investigacion_Gasto, object>>[] { parameter1, parameter2, parameter3 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechainicio")
                orderByDateFunc = CreateExpressionOrderByDate<Investigacion_Gasto>("fechainicio");
            else
                orderByFunc = CreateExpressionOrderBy<Investigacion_Gasto>(model.SortColumn);

            // FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_crearproyecto == id_crearproyecto && p.id_partida == id_partida;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                var searchValueLower = model.SearchValue.ToLower();
                srchByFunc = d =>
                    d.id_crearproyecto == id_crearproyecto &&
                    d.id_partida == id_partida &&
                    (d.nombregasto.ToLower().Contains(searchValueLower) ||
                     d.ObjPersona.numidentificacion.ToLower().Contains(searchValueLower)); // Búsqueda por identificación
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //**** TOTAL PAGADO POR GASTO
            var valoraportado = (from ap in _context.investigacion_aplicarpago
                                 where ap.id_crearproyecto == id_crearproyecto
                                 group ap by ap.id_investigaciongasto into dt
                                 select new
                                 {
                                     valorpagado = dt.Sum(x => x.valorneto),
                                     idgasto = dt.Key
                                 }).ToList();

            foreach (var detgasto in data)
            {
                var objpago = valoraportado.Find(x => x.idgasto == detgasto.id_investigaciongasto);

                if (objpago != null)
                {
                    detgasto.TotalPagado = objpago.valorpagado;
                }
            }

            // Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_Gasto> result = new DataTableAdapter<Investigacion_Gasto>();

            // Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            // Regresamos el objeto result
            return result;
        }


        //public DataTableAdapter<Investigacion_Gasto> GetDataTableInvestigacion_GastoByProyecto(int id_crearproyecto, int id_partida, DataTableRequest model)
        //{
        //    var totalRows = 0;
        //    var RowsFiltered = totalRows;

        //    Expression<Func<Investigacion_Gasto, bool>> srchByFunc = null;
        //    Expression<Func<Investigacion_Gasto, string>> orderByFunc = null;
        //    Expression<Func<Investigacion_Gasto, DateTime>> orderByDateFunc = null;

        //    Expression<Func<Investigacion_Gasto, object>> parameter1 = m => m.ObjPersona;
        //    Expression<Func<Investigacion_Gasto, object>> parameter2 = m => m.ObjConcepto;
        //    Expression<Func<Investigacion_Gasto, object>> parameter3 = m => m.ObjRubro;
        //    Expression<Func<Investigacion_Gasto, object>>[] parameterArray = new Expression<Func<Investigacion_Gasto, object>>[] { parameter1, parameter2, parameter3 };

        //    bool isOrderDesc = false;

        //    if (model.SortColumn.ToLower() == "fechainicio")
        //        orderByDateFunc = CreateExpressionOrderByDate<Investigacion_Gasto>("fechainicio");
        //    else
        //        orderByFunc = CreateExpressionOrderBy<Investigacion_Gasto>(model.SortColumn);


        //    //FILTRA POR EL PROYECTO
        //    srchByFunc = p => p.id_crearproyecto == id_crearproyecto && p.id_partida == id_partida;
        //    totalRows = CountFiltered(srchByFunc);
        //    RowsFiltered = totalRows;

        //    if (model.SearchValue != null && model.SearchValue != "")
        //    {
        //        srchByFunc = d => d.id_crearproyecto == id_crearproyecto && d.id_partida == id_partida && d.nombregasto.ToLower().Contains(model.SearchValue.ToLower());
        //        RowsFiltered = CountFiltered(srchByFunc);
        //    }

        //    isOrderDesc = model.SortColumnDir == "asc" ? false : true;

        //    var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

        //    //**** TOTAL PAGADO POR GASTO
        //    var valoraportado = (from ap in _context.investigacion_aplicarpago
        //                         where ap.id_crearproyecto == id_crearproyecto
        //                         group ap by ap.id_investigaciongasto into dt
        //                         select new
        //                         {
        //                             valorpagado = dt.Sum(x => x.valorneto),
        //                             idgasto = dt.Key
        //                         }).ToList();

        //    foreach (var detgasto in data)
        //    {
        //        var objpago = valoraportado.Find(x => x.idgasto == detgasto.id_investigaciongasto);

        //        if (objpago != null)
        //        {
        //            detgasto.TotalPagado = objpago.valorpagado;
        //        }
        //    }

        //    //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
        //    DataTableAdapter<Investigacion_Gasto> result = new DataTableAdapter<Investigacion_Gasto>();

        //    //Llenamos con información nuestro DataTableAdapter
        //    result.Data = data;
        //    result.Draw = model.draw;
        //    result.RecordsTotal = totalRows;
        //    result.RecordsFiltered = RowsFiltered;
        //    //Regresamos el objeto result
        //    return result;
        //}

        public Investigacion_Gasto GetInvestigacion_GastoRelaciones(int id_investigaciongasto)
        {
            Expression<Func<Investigacion_Gasto, object>> parameter1 = m => m.ObjPersona;
            Expression<Func<Investigacion_Gasto, object>> parameter2 = m => m.ObjConcepto;
            Expression<Func<Investigacion_Gasto, object>> parameter3 = m => m.ObjRubro;
            Expression<Func<Investigacion_Gasto, object>>[] parameterArray = new Expression<Func<Investigacion_Gasto, object>>[] { parameter1, parameter2, parameter3 };

            return Get(c => c.id_investigaciongasto == id_investigaciongasto, parameterArray).FirstOrDefault();
        }
    }
}