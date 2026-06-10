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
    public class Seguimiento_CrearGastoRepository : SuperType<Seguimiento_CrearGasto>, ISeguimiento_CrearGastoRepository
    {
        private ApplicationDbContext _context;

        public Seguimiento_CrearGastoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_CrearGastoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimiento_CrearGasto(int id_creargasto)
        {
            Delete(id_creargasto);
            return true;
        }

        public IEnumerable<Seguimiento_CrearGasto> GetAllSeguimiento_CrearGasto()
        {
            return Get();
        }

        public Seguimiento_CrearGasto GetSeguimiento_CrearGastoDetails(int id_creargasto)
        {
            return Get(id_creargasto);
        }

        public bool InsertSeguimiento_CrearGasto(Seguimiento_CrearGasto seguimiento_CrearGasto)
        {
            Add(seguimiento_CrearGasto);
            return true;
        }

        public bool UpdateSeguimiento_CrearGasto(Seguimiento_CrearGasto seguimiento_CrearGasto)
        {
            Update(seguimiento_CrearGasto);
            return true;
        }

        public DataTableAdapter<Seguimiento_CrearGasto> GetDataTableProyectoGastosByProyecto(int id_asignacionproyecto, int id_partida, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Seguimiento_CrearGasto, bool>> srchByFunc = null;
            Expression<Func<Seguimiento_CrearGasto, string>> orderByFunc = null;
            Expression<Func<Seguimiento_CrearGasto, DateTime>> orderByDateFunc = null;

            Expression<Func<Seguimiento_CrearGasto, object>> parameter1 = m => m.objPersona;
            Expression<Func<Seguimiento_CrearGasto, object>> parameter2 = m => m.objConcepto;
            Expression<Func<Seguimiento_CrearGasto, object>> parameter3 = m => m.ObjRubro;
            Expression<Func<Seguimiento_CrearGasto, object>>[] parameterArray = new Expression<Func<Seguimiento_CrearGasto, object>>[] { parameter1,parameter2, parameter3 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechaasignacion")
                orderByDateFunc = CreateExpressionOrderByDate<Seguimiento_CrearGasto>("fechaasignacion");
            else
                orderByFunc = CreateExpressionOrderBy<Seguimiento_CrearGasto>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_asignacionproyecto == id_asignacionproyecto && p.id_partida == id_partida;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_asignacionproyecto == id_asignacionproyecto && d.id_partida == id_partida && d.nombregasto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //**** TOTAL PAGADO POR GASTO
            var valoraportado = (from ap in _context.seguimiento_aplicarpago
                                 where ap.id_asignacionproyecto == id_asignacionproyecto
                                 group ap by ap.id_creargasto into dt
                                 select new
                                 {
                                     valorpagado = dt.Sum(x => x.valorneto),
                                     idgasto = dt.Key
                                 }).ToList();

            foreach (var detgasto in data)
            {
                var objpago = valoraportado.Find(x => x.idgasto == detgasto.id_creargasto);

                if (objpago != null)
                {
                    detgasto.TotalPagado = objpago.valorpagado;
                }
            }

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Seguimiento_CrearGasto> result = new DataTableAdapter<Seguimiento_CrearGasto>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public Seguimiento_CrearGasto GetSeguimiento_CrearGastoRelaciones(int id_creargasto)
        {
            Expression<Func<Seguimiento_CrearGasto, object>> parameter1 = m => m.objPersona;
            Expression<Func<Seguimiento_CrearGasto, object>> parameter2 = m => m.objConcepto;
            Expression<Func<Seguimiento_CrearGasto, object>> parameter3 = m => m.ObjRubro;
            Expression<Func<Seguimiento_CrearGasto, object>>[] parameterArray = new Expression<Func<Seguimiento_CrearGasto, object>>[] { parameter1, parameter2, parameter3 };

            return Get(c => c.id_creargasto == id_creargasto, parameterArray).FirstOrDefault();            
        }
    }
}