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
    public class Alerta_SeguimientoRepository : SuperType<Alerta_Seguimiento>
    {
        private ApplicationDbContext _context;

        public Alerta_SeguimientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Alerta_SeguimientoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public Alerta_Seguimiento GetAlerta_SeguimientoDetails(int idalertaseguimiento)
        {
            return Get(idalertaseguimiento);
        }
        
        public IEnumerable<Alerta_Seguimiento> GetAlerta_SeguimientoByUsuarioEstado(string usuario, string estado)
        {
            return (estado == "TODAS") ?
                Get(a => a.usuario == usuario) :
                Get(a => a.usuario == usuario && a.estado == estado);
        }

        public bool InsertAlerta_Seguimiento(Alerta_Seguimiento alerta_seguimiento)
        {
            Add(alerta_seguimiento);
            return true;
        }

        public bool UpdateAlerta_Seguimiento(Alerta_Seguimiento alerta_seguimiento)
        {
            Update(alerta_seguimiento);
            return true;
        }

        public bool UpdateAlerta_SeguimientoCerrar(int idalertaseguimiento)
        {
            var datoalerta = Get(idalertaseguimiento);

            datoalerta.estado = "CERRADA";
            datoalerta.fechafinaliza = DateTime.Now;

            Update(datoalerta);
            return true;
        }

        public bool DeleteAlerta_Seguimiento(int idalertaseguimiento)
        {
            var datoalerta = Get(idalertaseguimiento);

            if (datoalerta != null)
            {
                if (datoalerta.estado == "CERRADA")
                    throw new Exception("La alerta tiene estado CERRADA");
            }
            else
            {
                throw new Exception("Alerta inexistente");
            }

            Delete(idalertaseguimiento);
            return true;
        }

        public DataTableAdapter<Alerta_Seguimiento> GetDataTableAlerta_SeguimientoByUsuarioEstado(string usuario, string estado, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Alerta_Seguimiento, bool>> srchByFunc = null;
            Expression<Func<Alerta_Seguimiento, string>> orderByFunc = null;
            Expression<Func<Alerta_Seguimiento, DateTime>> orderByDateFunc = null;
            //Expression<Func<Alerta_Seguimiento, int>> orderByIntFunc = null;

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechavence")
                orderByDateFunc = CreateExpressionOrderByDate<Alerta_Seguimiento>("fechavence");
            else
                orderByFunc = CreateExpressionOrderBy<Alerta_Seguimiento>(model.SortColumn);

            //FILTRA POR EL FUNCIONARIO Y EL ESTADO
            switch (estado)
            {
                case "ABIERTA":
                    srchByFunc = p => p.usuario == usuario && p.estado == estado;
                    break;
                case "CERRADA": 
                    srchByFunc = p => p.usuario == usuario && p.estado == estado;
                    break;
                default: 
                    srchByFunc = p => p.usuario == usuario;
                    break;
            }

            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = (estado != "TODAS") ?
                    p => p.usuario == usuario && p.estado== estado && p.consecutivo.ToLower().Contains(model.SearchValue.ToLower()) :
                    srchByFunc = p => p.usuario == usuario && p.consecutivo.ToLower().Contains(model.SearchValue.ToLower());

                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "fechavence") ?
                Get(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc).ToList() :
                Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Alerta_Seguimiento> result = new DataTableAdapter<Alerta_Seguimiento>();

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