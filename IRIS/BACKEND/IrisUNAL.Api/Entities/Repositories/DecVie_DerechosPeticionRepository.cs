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
    public class DecVie_DerechosPeticionRepository : SuperType<DecVie_DerechosPeticion>, IDecVie_DerechosPeticionRepository
    {
        private ApplicationDbContext _context;

        public DecVie_DerechosPeticionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_DerechosPeticionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_DerechosPeticion(int id_derechopeticion)
        {
            Delete(id_derechopeticion);
            return true;
        }

        public IEnumerable<DecVie_DerechosPeticion> GetAllDecVie_DerechosPeticion()
        {
            return Get();
        }

        public DecVie_DerechosPeticion GetDecVie_DerechosPeticionDetails(int id_derechopeticion)
        {
            return Get(id_derechopeticion);
        }

        public DecVie_DerechosPeticion GetDecVie_DerechosPeticionNumero(string cd_numradicacion)
        {
            return Get(c => c.numradicacion == cd_numradicacion).FirstOrDefault();
        }

        public bool InsertDecVie_DerechosPeticion(DecVie_DerechosPeticion decVie_DerechosPeticion)
        {
            Add(decVie_DerechosPeticion);
            return true;
        }

        public bool UpdateDecVie_DerechosPeticion(DecVie_DerechosPeticion decVie_DerechosPeticion)
        {
            Update(decVie_DerechosPeticion);
            return true;
        }
        public DataTableAdapter<DecVie_DerechosPeticion> GetDataTableDecVie_DerechosPeticion(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_DerechosPeticion, DateTime>> orderByDateFunc = null;
            Expression<Func<DecVie_DerechosPeticion, bool>> srchByFunc = null;
            Expression<Func<DecVie_DerechosPeticion, string>> orderByFunc = null;
            Expression<Func<DecVie_DerechosPeticion, int>> orderByIntFunc = null;

            Expression<Func<DecVie_DerechosPeticion, object>> parameter1 = d => d.Objorigen;
            Expression<Func<DecVie_DerechosPeticion, object>> parameter2 = d => d.Objinstancia;
            Expression<Func<DecVie_DerechosPeticion, object>> parameter3 = d => d.Objmacroproceso;
            Expression<Func<DecVie_DerechosPeticion, object>> parameter4 = d => d.Objdependencia;
            Expression<Func<DecVie_DerechosPeticion, object>> parameter5 = d => d.Objoficina;
            Expression<Func<DecVie_DerechosPeticion, object>> parameter6 = d => d.Objestadoderechopeticion;
            Expression<Func<DecVie_DerechosPeticion, object>> parameter7 = d => d.Objtipopersona;

            Expression<Func<DecVie_DerechosPeticion, object>>[] parameterArray = new Expression<Func<DecVie_DerechosPeticion, object>>[] { parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.numradicacion.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn.ToLower() == "fecha")
                orderByDateFunc = CreateExpressionOrderByDate<DecVie_DerechosPeticion>("fecha");
            else

            if (model.SortColumn == "id_derechopeticion")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_DerechosPeticion>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_DerechosPeticion>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_DerechosPeticion> data = null;
            if (model.SortColumn.ToLower() == "fecha")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
            else
            if (model.SortColumn == "id_derechopeticion")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_DerechosPeticion> result = new DataTableAdapter<DecVie_DerechosPeticion>();

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