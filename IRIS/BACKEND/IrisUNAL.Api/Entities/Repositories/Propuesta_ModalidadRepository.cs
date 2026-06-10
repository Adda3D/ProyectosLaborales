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
    public class Propuesta_ModalidadRepository : SuperType<Propuesta_Modalidad>, IPropuesta_ModalidadRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_ModalidadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_ModalidadRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_Modalidad(int id_modalidad)
        {
            Delete(id_modalidad);
            return true;
        }

        public IEnumerable<Propuesta_Modalidad> GetAllPropuesta_Modalidad()
        {
            return Get();
        }

        public Propuesta_Modalidad GetPropuesta_ModalidadDetails(int id_modalidad)
        {
            return Get(id_modalidad);
        }

        public IEnumerable<Propuesta_Modalidad> GetPropuesta_ModalidadDetails(string cd_nmmodalidad)
        {
            return Get(c=>c.nmmodalidad==cd_nmmodalidad);
        }

        public bool InsertPropuesta_Modalidad(Propuesta_Modalidad propuesta_Modalidad)
        {
            Add(propuesta_Modalidad);
            return true;
        }

        public bool UpdatePropuesta_Modalidad(Propuesta_Modalidad propuesta_Modalidad)
        {
            Update(propuesta_Modalidad);
            return true;
        }

        public DataTableAdapter<Propuesta_Modalidad> GetDataTablePropuestaModalidad(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_Modalidad, bool>> srchByFunc = null;
            Expression<Func<Propuesta_Modalidad, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmmodalidad.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_Modalidad>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_Modalidad> result = new DataTableAdapter<Propuesta_Modalidad>();

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