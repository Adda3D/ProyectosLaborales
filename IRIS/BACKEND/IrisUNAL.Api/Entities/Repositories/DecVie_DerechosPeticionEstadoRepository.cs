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
    public class DecVie_DerechosPeticionEstadoRepository : SuperType<DecVie_DerechosPeticionEstado>, IDecVie_DerechosPeticionEstadoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_DerechosPeticionEstadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_DerechosPeticionEstadoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_DerechosPeticionEstado(int id_estadoderpet)
        {
            Delete(id_estadoderpet);
            return true;
        }

        public IEnumerable<DecVie_DerechosPeticionEstado> GetAllDecVie_DerechosPeticionEstado()
        {
            return Get();
        }

        public DecVie_DerechosPeticionEstado GetDecVie_DerechosPeticionEstadoDetails(int id_estadoderpet)
        {
            return Get(id_estadoderpet);
        }

        public DecVie_DerechosPeticionEstado GetDecVie_DerechosPeticionEstadoNombre(string cd_nmestadoderpet)
        {
            return Get(C => C.nmestadoderpet == cd_nmestadoderpet).FirstOrDefault();
        }

        public bool InsertDecVie_DerechosPeticionEstado(DecVie_DerechosPeticionEstado decVie_DerechosPeticionEstado)
        {
            Add(decVie_DerechosPeticionEstado);
            return true;
        }

        public bool UpdateDecVie_DerechosPeticionEstado(DecVie_DerechosPeticionEstado decVie_DerechosPeticionEstado)
        {
            Update(decVie_DerechosPeticionEstado);
            return true;
        }
        DataTableAdapter<DecVie_DerechosPeticionEstado> IDecVie_DerechosPeticionEstadoRepository.GetDataTableDecVie_DerechosPeticionEstado(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_DerechosPeticionEstado, bool>> srchByFunc = null;
            Expression<Func<DecVie_DerechosPeticionEstado, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadoderpet.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_DerechosPeticionEstado>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_DerechosPeticionEstado> result = new DataTableAdapter<DecVie_DerechosPeticionEstado>();

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