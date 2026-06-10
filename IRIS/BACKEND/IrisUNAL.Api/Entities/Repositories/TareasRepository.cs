using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{

    public class TareasRepository : SuperType<Tareas>, ITareasRepository
    {
        private ApplicationDbContext _context;

        public TareasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TareasRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteTareas(int id_tarea)
        {
            var datotarea = Get(id_tarea);

            if (datotarea != null)
            {
                if (datotarea.seguimiento != null && datotarea.seguimiento != "")
                    throw new Exception("La tarea tiene seguimiento registrado");

                if (datotarea.id_estadotarea == 4)
                    throw new Exception("La tarea tiene estado FINALIZADA");
            }
            else
            {
                throw new Exception("Tarea inexistente");
            }

            Delete(id_tarea);
            return true;
        }

        public IEnumerable<Tareas> GetAllTareas()
        {
            return Get();
        }

        public Tareas GetTareasDetails(int id_tarea)
        {
            var _tarea = Get(id_tarea);
            
            using (FuncionarioRepository _frp = new FuncionarioRepository())
            {                
                var _of = _frp.Get(f => f.correo == _tarea.funcionario).FirstOrDefault();
                if (_of != null)
                {
                    _tarea.Responsable = _of.nombrecompleto;
                }
            }

            return _tarea;

        }

        public bool InsertTareas(Tareas tareas)
        {
            //*** OBTIENE EL NOMBRE COMPLETO DEL USUARIO QUE ASIGNA LA TAREA
            UsuarioRepository _objusr = new UsuarioRepository();

            var _user = _objusr.Get(u => u.correoinstitucional == tareas.funcionarioasigna).FirstOrDefault();

            if (_user != null)
            {
                tareas.asignadopor = _user.nombrecompleto;
            }
            else
            {
                tareas.asignadopor = tareas.funcionarioasigna;
            }

            Add(tareas);
            return true;
        }

        public bool UpdateTareas(Tareas tareas)
        {
            Update(tareas);
            return true;
        }

        public DataTableAdapter<Tareas> GetDataTableTareasByFuncionarioEstado(string idfuncionario, int id_estadotarea, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Tareas, bool>> srchByFunc = null;
            Expression<Func<Tareas, string>> orderByFunc = null;
            Expression<Func<Tareas, DateTime>> orderByDateFunc = null;
            Expression<Func<Tareas, int>> orderByIntFunc = null;

            Expression<Func<Tareas, object>> parameter1 = t => t.ObjEstado;
            Expression<Func<Tareas, object>> parameter2 = t => t.ObjModulo;
            //Expression<Func<Tareas, object>> parameter3 = t => t.ObjFuncionario;
            Expression<Func<Tareas, object>>[] parameterArray = new Expression<Func<Tareas, object>>[] { parameter1, parameter2 };

            bool isOrderDesc = false;
            
            if (model.SortColumn.ToLower() == "fechaentrega")
                orderByDateFunc = CreateExpressionOrderByDate<Tareas>("fechaentrega");
            else
                if (model.SortColumn.ToLower() == "avance")
                    orderByIntFunc = CreateExpressionOrderByInt<Tareas>(model.SortColumn);
                else
                    orderByFunc = CreateExpressionOrderBy<Tareas>(model.SortColumn);

            //FILTRA POR EL FUNCIONARIO Y EL ESTADO
            switch (id_estadotarea)
            {
                case 0: //TODAS
                    srchByFunc = p => p.funcionario == idfuncionario;
                    break;
                case -1: // excepto las finalizadas
                    srchByFunc = p => p.funcionario == idfuncionario && p.id_estadotarea != 4;
                    break;
                default: //VIENE UN ESTADO DEL FILTRO
                    srchByFunc = p => p.funcionario == idfuncionario && p.id_estadotarea == id_estadotarea;
                    break;
            }            
            
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = (id_estadotarea != 0) ?
                    p => p.funcionario == idfuncionario && p.id_estadotarea == id_estadotarea && p.consecutivo.ToLower().Contains(model.SearchValue.ToLower()) : 
                    srchByFunc = p => p.funcionario == idfuncionario && p.consecutivo.ToLower().Contains(model.SearchValue.ToLower());
                
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fechaentrega") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                (model.SortColumn.ToLower() == "avance") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Tareas> result = new DataTableAdapter<Tareas>();

            using (FuncionarioRepository _frp = new FuncionarioRepository())
            {
                foreach (var _tarea in data)
                {                    
                    var _of = _frp.Get(f => f.correo == _tarea.funcionario).FirstOrDefault();
                    if (_of != null)
                    {
                        _tarea.Responsable = _of.nombrecompleto;
                    }                    
                }
            }

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Tareas> GetDataTableTareasByModuloRelacionado(int idtareamodulo, int idrelacionado, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Tareas, bool>> srchByFunc = null;
            Expression<Func<Tareas, string>> orderByFunc = null;
            Expression<Func<Tareas, DateTime>> orderByDateFunc = null;
            Expression<Func<Tareas, int>> orderByIntFunc = null;

            Expression<Func<Tareas, object>> parameter1 = t => t.ObjEstado;
            Expression<Func<Tareas, object>> parameter2 = t => t.ObjModulo;
            //Expression<Func<Tareas, object>> parameter3 = t => t.ObjFuncionario;
            Expression<Func<Tareas, object>>[] parameterArray = new Expression<Func<Tareas, object>>[] { parameter1, parameter2 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechaentrega")
                orderByDateFunc = CreateExpressionOrderByDate<Tareas>("fechaentrega");
            else
                if (model.SortColumn.ToLower() == "avance")
                    orderByIntFunc = CreateExpressionOrderByInt<Tareas>(model.SortColumn);
                else
                    orderByFunc = CreateExpressionOrderBy<Tareas>(model.SortColumn);

            //orderByIntFunc = CreateExpressionOrderByInt<Tareas>("id_evaluadores");

            //FILTRA POR EL MODULO Y EL ID RELACIONADO
            srchByFunc = p => p.idtareamodulo == idtareamodulo && p.idrelacionado == idrelacionado;

            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = p => p.idtareamodulo == idtareamodulo && p.idrelacionado == idrelacionado && p.consecutivo.ToLower().Contains(model.SearchValue.ToLower());                    

                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fechaentrega") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                (model.SortColumn.ToLower() == "avance") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Tareas> result = new DataTableAdapter<Tareas>();

            using (FuncionarioRepository _frp = new FuncionarioRepository())
            {
                foreach (var _tarea in data)
                {                    
                    var _of = _frp.Get(f => f.correo == _tarea.funcionario).FirstOrDefault();
                    if (_of != null)
                    {
                        _tarea.Responsable = _of.nombrecompleto;
                    }
                }
            }

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;            
        }

        public bool UpdateTareaEstadoAvance(TareasEstadoAvanceDTO tarea)
        {
            var datotarea = Get(tarea.id_tarea);
            var _nombreusuario = "";

            if (datotarea != null)
            {
                datotarea.id_estadotarea = tarea.id_estadotarea;
                datotarea.avance = tarea.avance;

                if (tarea.id_estadotarea == 4)
                {
                    datotarea.fechafin = DateTime.Now;
                    datotarea.avance = 100;
                }                

                Update(datotarea);

                using (UsuarioRepository _usrp = new UsuarioRepository())
                {
                    var _of = _usrp.Get(f => f.correoinstitucional == tarea.usuario).FirstOrDefault();
                    if (_of != null)
                    {
                        _nombreusuario = _of.nombrecompleto;
                    }
                }

                using (Tareas_SeguimientoRepository seguimientor = new Tareas_SeguimientoRepository())
                {
                    using (Estado_TareaRepository estadoR = new Estado_TareaRepository())
                    {
                        var objestadoT = estadoR.Get(tarea.id_estadotarea);
                        var estadonombre = "";

                        if (objestadoT != null)
                        {
                            estadonombre = objestadoT.nmestadotarea;
                        }
                       
                        var seguimiento = new Tareas_Seguimiento();
                        seguimiento.id_tarea = tarea.id_tarea;
                        seguimiento.fecharealiza = DateTime.Now;
                        seguimiento.usuariocreacion = tarea.usuario;
                        seguimiento.fechacreacion = DateTime.Now;
                        seguimiento.observaciones = "Usuario " + ((_nombreusuario != "") ? _nombreusuario : tarea.usuario) + " actualiza avance: " + datotarea.avance.ToString() + "%, estado: " + estadonombre;

                        seguimientor.InsertTareas_Seguimiento(seguimiento);                        
                    }
                }
                    return true;
            }
            else
            {
                return false;
            }

        }

        public DataTableAdapter<Tareas> GetDataTableTareasByRelacioncon(string relacioncon, int idrelacionado, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Tareas, bool>> srchByFunc = null;
            Expression<Func<Tareas, string>> orderByFunc = null;
            Expression<Func<Tareas, DateTime>> orderByDateFunc = null;
            Expression<Func<Tareas, int>> orderByIntFunc = null;

            Expression<Func<Tareas, object>> parameter1 = t => t.ObjEstado;
            Expression<Func<Tareas, object>> parameter2 = t => t.ObjModulo;
            //Expression<Func<Tareas, object>> parameter3 = t => t.ObjFuncionario;
            Expression<Func<Tareas, object>>[] parameterArray = new Expression<Func<Tareas, object>>[] { parameter1, parameter2 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechaentrega")
                orderByDateFunc = CreateExpressionOrderByDate<Tareas>("fechaentrega");
            else
                if (model.SortColumn.ToLower() == "avance")
                orderByIntFunc = CreateExpressionOrderByInt<Tareas>(model.SortColumn);
            else
                orderByFunc = CreateExpressionOrderBy<Tareas>(model.SortColumn);

            //orderByIntFunc = CreateExpressionOrderByInt<Tareas>("id_evaluadores");

            //FILTRA POR EL MODULO Y EL ID RELACIONADO
            srchByFunc = p => p.relacioncon == relacioncon && p.idrelacionado == idrelacionado;

            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = p => p.relacioncon == relacioncon && p.idrelacionado == idrelacionado && p.consecutivo.ToLower().Contains(model.SearchValue.ToLower());

                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fechaentrega") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                (model.SortColumn.ToLower() == "avance") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Tareas> result = new DataTableAdapter<Tareas>();

            using (FuncionarioRepository _frp = new FuncionarioRepository())
            {
                foreach (var _tarea in data)
                {
                    var _of = _frp.Get(f => f.correo == _tarea.funcionario).FirstOrDefault();
                    if (_of != null)
                    {
                        _tarea.Responsable = _of.nombrecompleto;
                    }
                }
            }

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<Tareas> GetDataTableTareasByAsignadoPorEstado(string asignadopor, int id_estadotarea, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Tareas, bool>> srchByFunc = null;
            Expression<Func<Tareas, string>> orderByFunc = null;
            Expression<Func<Tareas, DateTime>> orderByDateFunc = null;
            Expression<Func<Tareas, int>> orderByIntFunc = null;

            Expression<Func<Tareas, object>> parameter1 = t => t.ObjEstado;
            Expression<Func<Tareas, object>> parameter2 = t => t.ObjModulo;
            //Expression<Func<Tareas, object>> parameter3 = t => t.ObjFuncionario;
            Expression<Func<Tareas, object>>[] parameterArray = new Expression<Func<Tareas, object>>[] { parameter1, parameter2 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechaentrega")
                orderByDateFunc = CreateExpressionOrderByDate<Tareas>("fechaentrega");
            else
                if (model.SortColumn.ToLower() == "avance")
                orderByIntFunc = CreateExpressionOrderByInt<Tareas>(model.SortColumn);
            else
                orderByFunc = CreateExpressionOrderBy<Tareas>(model.SortColumn);

            //FILTRA POR EL FUNCIONARIO Y EL ESTADO
            switch (id_estadotarea)
            {
                case 0: //TODAS
                    srchByFunc = p => p.funcionarioasigna == asignadopor;
                    break;
                case -1: // excepto las finalizadas
                    srchByFunc = p => p.funcionarioasigna == asignadopor && p.id_estadotarea != 4;
                    break;
                default: //VIENE UN ESTADO DEL FILTRO
                    srchByFunc = p => p.funcionarioasigna == asignadopor && p.id_estadotarea == id_estadotarea;
                    break;
            }

            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = (id_estadotarea != 0) ?
                    p => p.funcionarioasigna == asignadopor && p.id_estadotarea == id_estadotarea && p.consecutivo.ToLower().Contains(model.SearchValue.ToLower()) :
                    srchByFunc = p => p.funcionarioasigna == asignadopor && p.consecutivo.ToLower().Contains(model.SearchValue.ToLower());

                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fechaentrega") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
                (model.SortColumn.ToLower() == "avance") ?
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList() :
                GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Tareas> result = new DataTableAdapter<Tareas>();

            using (FuncionarioRepository _frp = new FuncionarioRepository())
            {
                foreach (var _tarea in data)
                {
                    var _of = _frp.Get(f => f.correo == _tarea.funcionario).FirstOrDefault();
                    if (_of != null)
                    {
                        _tarea.Responsable = _of.nombrecompleto;
                    }
                }
            }

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