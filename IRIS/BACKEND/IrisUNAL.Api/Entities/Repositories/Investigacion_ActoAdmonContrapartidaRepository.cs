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
    public class Investigacion_ActoAdmonContrapartidaRepository : SuperType<Investigacion_ActoAdmonContrapartida>, IInvestigacion_ActoAdmonContrapartidaRepository
    {
        private ApplicationDbContext _context;

        public Investigacion_ActoAdmonContrapartidaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_ActoAdmonContrapartidaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteInvestigacion_ActoAdmonContrapartida(int id_actoadmoncontrapartida)
        {
            Delete(id_actoadmoncontrapartida);
            return true;
        }

        public IEnumerable<Investigacion_ActoAdmonContrapartida> GetAllInvestigacion_ActoAdmonContrapartida()
        {
            return Get();
        }

        public Investigacion_ActoAdmonContrapartida GetInvestigacion_ActoAdmonContrapartidaCodigo(string cd_codigohermes)
        {
            return Get(c => c.codigohermes == cd_codigohermes).FirstOrDefault();
        }

        public Investigacion_ActoAdmonContrapartida GetInvestigacion_ActoAdmonContrapartidaDetails(int id_actoadmoncontrapartida)
        {
            return Get(id_actoadmoncontrapartida);
        }

        public bool InsertInvestigacion_ActoAdmonContrapartida(Investigacion_ActoAdmonContrapartida investigacion_ActoAdmonContrapartida)
        {
            Add(investigacion_ActoAdmonContrapartida);
            return true;
        }

        public bool UpdateInvestigacion_ActoAdmonContrapartida(Investigacion_ActoAdmonContrapartida investigacion_ActoAdmonContrapartida)
        {
            Update(investigacion_ActoAdmonContrapartida);
            return true;
        }
        DataTableAdapter<Investigacion_ActoAdmonContrapartida> IInvestigacion_ActoAdmonContrapartidaRepository.GetDataTableInvestigacion_ActoAdmonContrapartida(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Investigacion_ActoAdmonContrapartida, bool>> srchByFunc = null;
            Expression<Func<Investigacion_ActoAdmonContrapartida, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.codigohermes.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Investigacion_ActoAdmonContrapartida>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Investigacion_ActoAdmonContrapartida> result = new DataTableAdapter<Investigacion_ActoAdmonContrapartida>();

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