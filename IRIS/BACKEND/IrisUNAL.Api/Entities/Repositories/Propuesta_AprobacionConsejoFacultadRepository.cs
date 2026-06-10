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
    public class Propuesta_AprobacionConsejoFacultadRepository : SuperType<Propuesta_AprobacionConsejoFacultad>, IPropuesta_AprobacionConsejoFacultadRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_AprobacionConsejoFacultadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_AprobacionConsejoFacultadRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_AprobacionConsejoFacultad(int id_aprobacionconsejofacultad)
        {
            Delete(id_aprobacionconsejofacultad);
            return true;
        }

        public IEnumerable<Propuesta_AprobacionConsejoFacultad>GetAllPropuesta_AprobacionConsejoFacultad()
        {
            return Get();
        }

        public IEnumerable<Propuesta_AprobacionConsejoFacultad>GetPropuesta_AprobacionConsejoFacultadDetails(string cd_nmaprconfac)
        {
            return Get(c=>c.nmaprconfac==cd_nmaprconfac);
        }

        public Propuesta_AprobacionConsejoFacultad GetPropuesta_AprobacionConsejoFacultadDetails(int id_aprobacionconsejofacultad)
        {
            return Get(id_aprobacionconsejofacultad);
        }

        public bool InsertPropuesta_AprobacionConsejoFacultad(Propuesta_AprobacionConsejoFacultad propuesta_AprobacionConsejoFacultad)
        {
            Add(propuesta_AprobacionConsejoFacultad);
            return true;
        }

        public bool UpdatePropuesta_AprobacionConsejoFacultad(Propuesta_AprobacionConsejoFacultad propuesta_AprobacionConsejoFacultad)
        {
            Update(propuesta_AprobacionConsejoFacultad);
            return true;
        }

        public DataTableAdapter<Propuesta_AprobacionConsejoFacultad> GetDataTablePropuestaTipoAprobacion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_AprobacionConsejoFacultad, bool>> srchByFunc = null;
            Expression<Func<Propuesta_AprobacionConsejoFacultad, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmaprconfac.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_AprobacionConsejoFacultad>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_AprobacionConsejoFacultad> result = new DataTableAdapter<Propuesta_AprobacionConsejoFacultad>();

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