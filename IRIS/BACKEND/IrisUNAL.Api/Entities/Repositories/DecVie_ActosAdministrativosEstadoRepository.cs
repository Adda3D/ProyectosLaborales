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
    public class DecVie_ActosAdministrativosEstadoRepository : SuperType<DecVie_ActosAdministrativosEstado>, IDecVie_ActosAdministrativosEstadoRepository
    {
        public bool DeleteDecVie_ActosAdministrativosEstado(int id_estadoactoadministrativo)
        {
            Delete(id_estadoactoadministrativo);
            return true;
        }

        public IEnumerable<DecVie_ActosAdministrativosEstado> GetAllDecVie_ActosAdministrativosEstado()
        {
            return Get();
        }       

        public DecVie_ActosAdministrativosEstado GetDecVie_ActosAdministrativosEstadoDetails(int id_estadoactoadministrativo)
        {
            return Get(id_estadoactoadministrativo);
        }

        public DecVie_ActosAdministrativosEstado GetDecVie_ActosAdministrativosEstadoNombre(string cd_nmestadoactoadministrativo)
        {
            return Get(c => c.nmestadoactoadministrativo == cd_nmestadoactoadministrativo).FirstOrDefault();
        }

        public bool InsertDecVie_ActosAdministrativosEstado(DecVie_ActosAdministrativosEstado decVie_ActosAdministrativosEstado)
        {
            Add(decVie_ActosAdministrativosEstado);
            return true;
        }

        public bool UpdateDecVie_ActosAdministrativosEstado(DecVie_ActosAdministrativosEstado decVie_ActosAdministrativosEstado)
        {
            Update(decVie_ActosAdministrativosEstado);
            return true;
        }
        DataTableAdapter<DecVie_ActosAdministrativosEstado> IDecVie_ActosAdministrativosEstadoRepository.GetDataTableDecVie_ActosAdministrativosEstado(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_ActosAdministrativosEstado, bool>> srchByFunc = null;
            Expression<Func<DecVie_ActosAdministrativosEstado, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadoactoadministrativo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_ActosAdministrativosEstado>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_ActosAdministrativosEstado> result = new DataTableAdapter<DecVie_ActosAdministrativosEstado>();

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