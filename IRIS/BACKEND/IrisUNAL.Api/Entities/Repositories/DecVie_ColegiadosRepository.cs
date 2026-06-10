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
    public class DecVie_ColegiadosRepository : SuperType<DecVie_Colegiados>, IDecVie_ColegiadosRepository
    {
        public bool DeleteDecVie_Colegiados(int id_colegiado)
        {
            Delete(id_colegiado);
            return true;
        }

        public IEnumerable<DecVie_Colegiados> GetAllDecVie_Colegiados()
        {
            return Get();
        }

        public DecVie_Colegiados GetDecVie_ColegiadosDetails(int id_colegiado)
        {
            return Get(id_colegiado);
        }

        public DecVie_Colegiados GetDecVie_ColegiadosNombre(string cd_nmcolegiado)
        {
            return Get(c => c.nmcolegiado == cd_nmcolegiado).FirstOrDefault();
        }

        public bool InsertDecVie_Colegiados(DecVie_Colegiados decVie_Colegiados)
        {
            Add(decVie_Colegiados);
            return true;
        }

        public bool UpdateDecVie_Colegiados(DecVie_Colegiados decVie_Colegiados)
        {
            Update(decVie_Colegiados);
            return true;
        }
        DataTableAdapter<DecVie_Colegiados> IDecVie_ColegiadosRepository.GetDataTableDecVie_Colegiados(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_Colegiados, bool>> srchByFunc = null;
            Expression<Func<DecVie_Colegiados, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmcolegiado.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_Colegiados>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_Colegiados> result = new DataTableAdapter<DecVie_Colegiados>();

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