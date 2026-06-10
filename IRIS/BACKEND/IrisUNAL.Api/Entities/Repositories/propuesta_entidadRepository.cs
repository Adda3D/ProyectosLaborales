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
    public class propuesta_entidadRepository : SuperType<Propuesta_Entidad>
    {
        private ApplicationDbContext _context;

        public propuesta_entidadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public propuesta_entidadRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Propuesta_Entidad> GetAllpropuesta_entidad()
        {
            return Get();
        }
        public Propuesta_Entidad Getpropuesta_entidadDetails(int idpropuesta_entidad)
        {
            return Get(idpropuesta_entidad);
        }
        public Propuesta_Entidad Getpropuesta_entidadDetails(string nroidentificacion)
        {
            return Get(p => p.numidentificacion == nroidentificacion).FirstOrDefault();
        }

        public Propuesta_Entidad GetPropuestaEntidadRazonSocial(string razonsocial)
        {
            return Get(p => p.razonsocial.Contains(razonsocial)).FirstOrDefault();
        }

        public bool Insertpropuesta_entidad(Propuesta_Entidad propuestaentidad)
        {
            Add(propuestaentidad);
            return true;

        }
        public bool Updatepropuesta_entidad(Propuesta_Entidad propuestaentidad)
        {
            Update(propuestaentidad);
            return true;
        }
        public bool Deletepropuesta_entidad(int idpropuesta_entidad)
        {
            Delete(idpropuesta_entidad);
            return true;
        }
        public DataTableAdapter<Propuesta_Entidad> GetDataTablepropuesta_entidad(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_Entidad, bool>> srchByFunc = null;
            Expression<Func<Propuesta_Entidad, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.numidentificacion.ToLower().Contains(model.SearchValue.ToLower()) || d.razonsocial.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_Entidad>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_Entidad> result = new DataTableAdapter<Propuesta_Entidad>();

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