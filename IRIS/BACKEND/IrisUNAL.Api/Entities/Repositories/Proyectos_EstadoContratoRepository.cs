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
    public class Proyectos_EstadoContratoRepository : SuperType<Proyectos_EstadoContrato>, IProyectos_EstadoContratoRepository
    {
        private ApplicationDbContext _context;

        public Proyectos_EstadoContratoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyectos_EstadoContratoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteProyectos_EstadoContrato(int id_estadocontrato)
        {
            Delete(id_estadocontrato);
            return true;
        }

        public IEnumerable<Proyectos_EstadoContrato> GetAllProyectos_EstadoContrato()
        {
            return Get();
        }

        public Proyectos_EstadoContrato GetProyectos_EstadoContratoDetails(int id_estadocontrato)
        {
            return Get(id_estadocontrato);
        }

        public Proyectos_EstadoContrato GetProyectos_EstadoContratoEstado(string cd_estadocontrato)
        {
            return Get(c=> c.estadocontrato==cd_estadocontrato).FirstOrDefault();
        }

        public bool InsertProyectos_EstadoContrato(Proyectos_EstadoContrato proyectos_EstadoContrato)
        {
            Add(proyectos_EstadoContrato);
            return true;
        }

        public bool UpdateProyectos_EstadoContrato(Proyectos_EstadoContrato proyectos_EstadoContrato)
        {
            Update(proyectos_EstadoContrato);
            return true;
        }
        DataTableAdapter<Proyectos_EstadoContrato> IProyectos_EstadoContratoRepository.GetDataTableProyectos_EstadoContrato(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Proyectos_EstadoContrato, bool>> srchByFunc = null;
            Expression<Func<Proyectos_EstadoContrato, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.estadocontrato.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Proyectos_EstadoContrato>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyectos_EstadoContrato> result = new DataTableAdapter<Proyectos_EstadoContrato>();

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