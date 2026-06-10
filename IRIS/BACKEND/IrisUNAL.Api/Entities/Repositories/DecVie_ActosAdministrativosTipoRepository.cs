using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_ActosAdministrativosTipoRepository : SuperType<DecVie_ActosAdministrativosTipo>, IDecVie_ActosAdministrativosTipoRepository
    {
        public bool DeleteDecVie_ActosAdministrativosTipo(int id_tipoactoadministrativo)
        {
            Delete(id_tipoactoadministrativo);
            return true;            
        }

        public IEnumerable<DecVie_ActosAdministrativosTipo> GetAllDecVie_ActosAdministrativosTipo()
        {
            return Get();
        }

        public DecVie_ActosAdministrativosTipo GetDecVie_ActosAdministrativosTipoDetails(int id_tipoactoadministrativo)
        {
            return Get(id_tipoactoadministrativo);
        }

        public DecVie_ActosAdministrativosTipo GetDecVie_ActosAdministrativosTipoNombre(string cd_nmidtipoactoadministrativo)
        {
            return Get(c => c.nmidtipoactoadministrativo == cd_nmidtipoactoadministrativo).FirstOrDefault();
        }

        public bool InsertDecVie_ActosAdministrativosTipo(DecVie_ActosAdministrativosTipo decVie_ActosAdministrativosTipo)
        {
            Add(decVie_ActosAdministrativosTipo);
            return true;
        }

        public bool UpdateDecVie_ActosAdministrativosTipo(DecVie_ActosAdministrativosTipo decVie_ActosAdministrativosTipo)
        {
            Update(decVie_ActosAdministrativosTipo);
            return true;
        }
        DataTableAdapter<DecVie_ActosAdministrativosTipo> IDecVie_ActosAdministrativosTipoRepository.GetDataTableDecVie_ActosAdministrativosTipo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_ActosAdministrativosTipo, bool>> srchByFunc = null;
            Expression<Func<DecVie_ActosAdministrativosTipo, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmidtipoactoadministrativo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_ActosAdministrativosTipo>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_ActosAdministrativosTipo> result = new DataTableAdapter<DecVie_ActosAdministrativosTipo>();

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