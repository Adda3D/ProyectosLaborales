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
    public class Tareas_SeguimientoRepository : SuperType<Tareas_Seguimiento>
    {
        private ApplicationDbContext _context;

        public Tareas_SeguimientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tareas_SeguimientoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Tareas_Seguimiento> GetAllTareas_Seguimiento()
        {
            return Get();
        }

        public Tareas_Seguimiento GetTareas_SeguimientoDetails(int idtareaseguimiento)
        {
            return Get(idtareaseguimiento);
        }

        public bool InsertTareas_Seguimiento(Tareas_Seguimiento tareas_seguimiento)
        {
            var _nombreusuario = "";

            Add(tareas_seguimiento);

            using (UsuarioRepository _usrp = new UsuarioRepository())
            {
                var _of = _usrp.Get(f => f.correoinstitucional == tareas_seguimiento.UsuarioSeguimiento).FirstOrDefault();
                if (_of != null)
                {
                    _nombreusuario = _of.nombrecompleto;
                }
            }

            //*** ACTUALIZA EL CAMPOS SEGUIMIENTO EN LA TABLA TAREAS
            using (var _tareas = new TareasRepository())
            {
                var datos_tarea = _tareas.Get(tareas_seguimiento.id_tarea);
                datos_tarea.seguimiento = datos_tarea.seguimiento + Environment.NewLine + 
                    tareas_seguimiento.fecharealiza.ToString("yyyy-MM-dd") + "  " + _nombreusuario + Environment.NewLine + 
                    tareas_seguimiento.observaciones;
                _tareas.Update(datos_tarea);
            }

                return true;
        }

        public bool UpdateTareas_Seguimiento(Tareas_Seguimiento tareas_seguimiento)
        {
            Update(tareas_seguimiento);
            return true;
        }

        public bool DeleteTareas_Seguimiento(int idtareaseguimiento)
        {
            Delete(idtareaseguimiento);
            return true;
        }

        public DataTableAdapter<Tareas_Seguimiento> GetDataTableTareas_SeguimientoByTarea(int id_tarea, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Tareas_Seguimiento, bool>> srchByFunc = null;
            Expression<Func<Tareas_Seguimiento, string>> orderByFunc = null;
            Expression<Func<Tareas_Seguimiento, DateTime>> orderByDateFunc = null;
            Expression<Func<Tareas_Seguimiento, int>> orderByIntFunc = null;

            Expression<Func<Tareas_Seguimiento, object>> parameter1 = m => m.ObjTarea;
            //Expression<Func<Tareas_Seguimiento, object>> parameter2 = m => m.ObjEstado;
            Expression<Func<Tareas_Seguimiento, object>>[] parameterArray = new Expression<Func<Tareas_Seguimiento, object>>[] { parameter1 };

            bool isOrderDesc = false;

            /* NO TRAE ORDENAMIENTO DEL DATATABLES
            if (model.SortColumn.ToLower() == "fecdesigcomite")
                orderByDateFunc = CreateExpressionOrderByDate<Tareas_Seguimiento>("fecdesigcomite");
            else
                orderByFunc = CreateExpressionOrderBy<Tareas_Seguimiento>(model.SortColumn);
            */

            orderByIntFunc = CreateExpressionOrderByInt<Tareas_Seguimiento>("idtareaseguimiento");

            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_tarea == id_tarea;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_tarea == id_tarea;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Tareas_Seguimiento> result = new DataTableAdapter<Tareas_Seguimiento>();

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