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
    public class DecVie_DerechosPeticionOficinaRepository : SuperType<DecVie_DerechosPeticionOficina>, IDecVie_DerechosPeticionOficinaRepository
    {
        private ApplicationDbContext _context;

        public DecVie_DerechosPeticionOficinaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_DerechosPeticionOficinaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_DerechosPeticionOficina(int id_oficina)
        {
            Delete(id_oficina);
            return true;
        }

        public IEnumerable<DecVie_DerechosPeticionOficina> GetAllDecVie_DerechosPeticionOficina()
        {
            return Get();
        }

        public DecVie_DerechosPeticionOficina GetDecVie_DerechosPeticionOficinaDetails(int id_oficina)
        {
            return Get(id_oficina);
        }

        public DecVie_DerechosPeticionOficina GetDecVie_DerechosPeticionOficinaNombre(string cd_nmoficina)
        {
            return Get(c => c.nmoficina == cd_nmoficina).FirstOrDefault();
        }

        public bool InsertDecVie_DerechosPeticionOficina(DecVie_DerechosPeticionOficina decVie_DerechosPeticionOficina)
        {
            Add(decVie_DerechosPeticionOficina);
            return true;
        }

        public bool UpdateDecVie_DerechosPeticionOficina(DecVie_DerechosPeticionOficina decVie_DerechosPeticionOficina)
        {
            Update(decVie_DerechosPeticionOficina);
            return true;
        }
        DataTableAdapter<DecVie_DerechosPeticionOficina> IDecVie_DerechosPeticionOficinaRepository.GetDataTableDecVie_DerechosPeticionOficina(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_DerechosPeticionOficina, bool>> srchByFunc = null;
            Expression<Func<DecVie_DerechosPeticionOficina, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmoficina.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_DerechosPeticionOficina>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_DerechosPeticionOficina> result = new DataTableAdapter<DecVie_DerechosPeticionOficina>();

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