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
    public class Propuesta_AvalConsejoFacultadRepository : SuperType<Propuesta_AvalConsejoFacultad>, IPropuesta_AvalConsejoFacultadRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_AvalConsejoFacultadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_AvalConsejoFacultadRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_AvalConsejoFacultad(int id_avalconfac)
        {
            Delete(id_avalconfac);
            return true;
        }

        public IEnumerable<Propuesta_AvalConsejoFacultad> GetAllPropuesta_AvalConsejoFacultad()
        {
            return Get();
        }

        public Propuesta_AvalConsejoFacultad GetPropuesta_AvalConsejoFacultadDetails(int id_avalconfac)
        {
            return Get(id_avalconfac);
        }

        public Propuesta_AvalConsejoFacultad GetPropuesta_AvalConsejoFacultadDetails(string cd_numeroaval)
        {
            return Get(c => c.numeroaval == cd_numeroaval).FirstOrDefault();
        }

        public bool InsertPropuesta_AvalConsejoFacultad(Propuesta_AvalConsejoFacultad propuesta_AvalConsejoFacultad)
        {
            Add(propuesta_AvalConsejoFacultad);
            return true;
        }

        public bool UpdatePropuesta_AvalConsejoFacultad(Propuesta_AvalConsejoFacultad propuesta_AvalConsejoFacultad)
        {
            Update(propuesta_AvalConsejoFacultad);
            return true;
        }

        public DataTableAdapter<Propuesta_AvalConsejoFacultad> GetDataTablePropuestaAvalConsejoFacultad(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Propuesta_AvalConsejoFacultad, bool>> srchByFunc = null;
            Expression<Func<Propuesta_AvalConsejoFacultad, string>> orderByFunc = null;

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.numeroaval.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Propuesta_AvalConsejoFacultad>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Propuesta_AvalConsejoFacultad> result = new DataTableAdapter<Propuesta_AvalConsejoFacultad>();

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