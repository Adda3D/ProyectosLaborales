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
    public class DecVie_EstadoPreAvalRepository : SuperType<DecVie_EstadoPreAval>, IDecVie_EstadoPreAvalRepository
    {
        private ApplicationDbContext _context;

        public DecVie_EstadoPreAvalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_EstadoPreAvalRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_EstadoPreAval(int id_estadopreaval)
        {
            Delete(id_estadopreaval);
            return true;
        }

        public IEnumerable<DecVie_EstadoPreAval> GetAllDecVie_EstadoPreAval()
        {
            return Get();
        }

        public DecVie_EstadoPreAval GetDecVie_EstadoPreAvalDetails(int id_estadopreaval)
        {
            return Get(id_estadopreaval);
        }

        public DecVie_EstadoPreAval GetDecVie_EstadoPreAvalNombre(string cd_nmestadopreaval)
        {
            return Get(c => c.nmestadopreaval == cd_nmestadopreaval).FirstOrDefault();
        }

        public bool InsertDecVie_EstadoPreAval(DecVie_EstadoPreAval decVie_EstadoPreAval)
        {
            Add(decVie_EstadoPreAval);
            return true;
        }

        public bool UpdateDecVie_EstadoPreAval(DecVie_EstadoPreAval decVie_EstadoPreAval)
        {
            Update(decVie_EstadoPreAval);
            return true;
        }
        DataTableAdapter<DecVie_EstadoPreAval> IDecVie_EstadoPreAvalRepository.GetDataTableDecVie_EstadoPreAval(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_EstadoPreAval, bool>> srchByFunc = null;
            Expression<Func<DecVie_EstadoPreAval, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadopreaval.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_EstadoPreAval>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_EstadoPreAval> result = new DataTableAdapter<DecVie_EstadoPreAval>();

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