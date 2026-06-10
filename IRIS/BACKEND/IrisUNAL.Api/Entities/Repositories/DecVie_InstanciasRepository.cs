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
    public class DecVie_InstanciasRepository : SuperType<DecVie_Instancias>, IDecVie_InstanciasRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InstanciasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InstanciasRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_Instancias(int id_instancia)
        {
            Delete(id_instancia);
            return true;
        }

        public IEnumerable<DecVie_Instancias> GetAllDecVie_Instancias()
        {
            return Get();
        }

        public DecVie_Instancias GetDecVie_InstanciasDetails(int id_instancia)
        {
            return Get(id_instancia);
        }

        public DecVie_Instancias GetDecVie_InstanciasNombre(string cd_nminstancia)
        {
            return Get(c => c.nminstancia == cd_nminstancia).FirstOrDefault();
        }

        public bool InsertDecVie_Instancias(DecVie_Instancias decVie_Instancias)
        {
            Add(decVie_Instancias);
            return true;
        }

        public bool UpdateDecVie_Instancias(DecVie_Instancias decVie_Instancias)
        {
            Update(decVie_Instancias);
            return true;
        }
        public DataTableAdapter<DecVie_Instancias> GetDataTableDecVie_Instancias(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_Instancias, bool>> srchByFunc = null;
            Expression<Func<DecVie_Instancias, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nminstancia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_Instancias>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_Instancias> result = new DataTableAdapter<DecVie_Instancias>();

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