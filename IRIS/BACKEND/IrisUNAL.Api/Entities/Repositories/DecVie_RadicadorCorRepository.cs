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
    public class DecVie_RadicadorCorRepository : SuperType<DecVie_RadicadorCor>, IDecVie_RadicadorCorRepository
    {
        private ApplicationDbContext _context;

        public DecVie_RadicadorCorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_RadicadorCorRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_RadicadorCor(int id_radicadorcor)
        {
            Delete(id_radicadorcor);
            return true;
        }

        public IEnumerable<DecVie_RadicadorCor> GetAllDecVie_RadicadorCor()
        {
            return Get();
        }

        public DecVie_RadicadorCor GetDecVie_RadicadorCorDetails(int id_radicadorcor)
        {
            return Get(id_radicadorcor);
        }

        public DecVie_RadicadorCor GetDecVie_RadicadorCorNombre(string cd_numerodocumento)
        {
            return Get(c => c.numerodocumento == cd_numerodocumento).FirstOrDefault();
        }

        public bool InsertDecVie_RadicadorCor(DecVie_RadicadorCor decVie_RadicadorCor)
        {
            Add(decVie_RadicadorCor);
            return true;
        }

        public bool UpdateDecVie_RadicadorCor(DecVie_RadicadorCor decVie_RadicadorCor)
        {
            Update(decVie_RadicadorCor);
            return true;
        }
        public DataTableAdapter<DecVie_RadicadorCor> GetDataTableDecVie_RadicadorCor(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_RadicadorCor, DateTime>> orderByDateFunc = null;
            Expression<Func<DecVie_RadicadorCor, bool>> srchByFunc = null;
            Expression<Func<DecVie_RadicadorCor, string>> orderByFunc = null;
            Expression<Func<DecVie_RadicadorCor, int>> orderByIntFunc = null;

            Expression<Func<DecVie_RadicadorCor, object>> parameter2 = d => d.Objorigensolicitud;
            Expression<Func<DecVie_RadicadorCor, object>> parameter3 = d => d.Objinstancia;
            Expression<Func<DecVie_RadicadorCor, object>> parameter5 = d => d.Objalcancesolicitud;
            Expression<Func<DecVie_RadicadorCor, object>> parameter7 = d => d.Objmacroproceso;
            Expression<Func<DecVie_RadicadorCor, object>> parameter8 = d => d.Objdependencia;
            Expression<Func<DecVie_RadicadorCor, object>> parameter9 = d => d.Objestado;

            Expression<Func<DecVie_RadicadorCor, object>>[] parameterArray = new Expression<Func<DecVie_RadicadorCor, object>>[] { parameter2, parameter3, parameter5, parameter7, parameter9, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.ogdchasqui.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn.ToLower() == "fecradicacion")
                orderByDateFunc = CreateExpressionOrderByDate<DecVie_RadicadorCor>("fecradicacion");
            else

            if (model.SortColumn == "id_radicadorcor")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_RadicadorCor>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_RadicadorCor>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_RadicadorCor> data = null;
            if (model.SortColumn.ToLower() == "fecradicacion")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
            else
            if (model.SortColumn == "id_radicadorcor")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_RadicadorCor> result = new DataTableAdapter<DecVie_RadicadorCor>();

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