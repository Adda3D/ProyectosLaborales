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

    public class Investigacion_CrearGrupoRepository : SuperType<Investigacion_CrearGrupo>, IInvestigacion_CrearGrupoRepository
    {
        private ApplicationDbContext _context;

        public Investigacion_CrearGrupoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_CrearGrupoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteInvestigacion_CrearGrupo(int id_creargrupo)
        {
            Delete(id_creargrupo);
            return true;
        }

        public IEnumerable<Investigacion_CrearGrupo> GetAllInvestigacion_CrearGrupo()
        {
            return Get();
        }

        public Investigacion_CrearGrupo GetInvestigacion_CrearGrupoCodigo(string cd_codigohermes)
        {
            return Get(c => c.codigohermes == cd_codigohermes).FirstOrDefault();
        }

        public Investigacion_CrearGrupo GetInvestigacion_CrearGrupoDetails(int id_creargrupo)
        {
            return Get(id_creargrupo);
        }

        public bool InsertInvestigacion_CrearGrupo(Investigacion_CrearGrupo investigacion_CrearGrupo)
        {
            Add(investigacion_CrearGrupo);
            return true;
        }

        public bool UpdateInvestigacion_CrearGrupo(Investigacion_CrearGrupo investigacion_CrearGrupo)
        {
            Update(investigacion_CrearGrupo);
            return true;
        }
        public DataTableAdapter<Investigacion_CrearGrupo> GetDataTableInvestigacion_CrearGrupo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_CrearGrupo, bool>> srchByFunc = null;
            Expression<Func<Investigacion_CrearGrupo, string>> orderByFunc = null;
            Expression<Func<Investigacion_CrearGrupo, DateTime>> orderByDateFunc = null;

            Expression<Func<Investigacion_CrearGrupo, object>> parameter1 = d => d.idpersona;
            Expression<Func<Investigacion_CrearGrupo, object>> parameter2 = d => d.idacademica;
            Expression<Func<Investigacion_CrearGrupo, object>> parameter3 = d => d.funcionariocoordinador;
            Expression<Func<Investigacion_CrearGrupo, object>>[] parameterArray = new Expression<Func<Investigacion_CrearGrupo, object>>[] { parameter1, parameter2, parameter3 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.codigohermes.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Investigacion_CrearGrupo>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = (model.SortColumn.ToLower() == "yearsuscripcion") ?
               GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList() :
               GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_CrearGrupo> result = new DataTableAdapter<Investigacion_CrearGrupo>();

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