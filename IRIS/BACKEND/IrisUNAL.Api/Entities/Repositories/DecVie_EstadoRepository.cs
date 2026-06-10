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
    public class DecVie_EstadoRepository : SuperType<DecVie_Estado>, IDecVie_EstadoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_EstadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_EstadoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_Estado(int id_decvieestado)
        {
            Delete(id_decvieestado);
            return true;
        }

        public IEnumerable<DecVie_Estado> GetAllDecVie_Estado()
        {
            return Get();
        }

        public DecVie_Estado GetDecVie_EstadoDetails(int id_decvieestado)
        {
            return Get(id_decvieestado);
        }

        public DecVie_Estado GetDecVie_EstadoNombre(string cd_nmdecvieestado)
        {
            return Get(c => c.nmdecvieestado == cd_nmdecvieestado).FirstOrDefault();
        }

        public bool InsertDecVie_Estado(DecVie_Estado decVie_Estado)
        {
            Add(decVie_Estado);
            return true;
        }

        public bool UpdateDecVie_Estado(DecVie_Estado decVie_Estado)
        {
            Update(decVie_Estado);
            return true;
        }
        DataTableAdapter<DecVie_Estado> IDecVie_EstadoRepository.GetDataTableDecVie_Estado(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_Estado, bool>> srchByFunc = null;
            Expression<Func<DecVie_Estado, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmdecvieestado.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_Estado>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_Estado> result = new DataTableAdapter<DecVie_Estado>();

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