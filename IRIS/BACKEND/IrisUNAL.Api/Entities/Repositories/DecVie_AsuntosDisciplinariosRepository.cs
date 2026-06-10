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
    public class DecVie_AsuntosDisciplinariosRepository : SuperType<DecVie_AsuntosDisciplinarios>, IDecVie_AsuntosDisciplinariosRepository
    {
        private ApplicationDbContext _context;

        public DecVie_AsuntosDisciplinariosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_AsuntosDisciplinariosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_AsuntosDisciplinarios(int id_asuntosdisciplinarios)
        {
            Delete(id_asuntosdisciplinarios);
            return true;
        }

        public IEnumerable<DecVie_AsuntosDisciplinarios> GetAllDecVie_AsuntosDisciplinarios()
        {
            return Get();
        }

        public DecVie_AsuntosDisciplinarios GetDecVie_AsuntosDisciplinariosDetails(int id_asuntosdisciplinarios)
        {
            return Get(id_asuntosdisciplinarios);
        }

        public DecVie_AsuntosDisciplinarios GetDecVie_AsuntosDisciplinariosNombre(string cd_nmAsuntosDisciplinarios)
        {
            return Get(c => c.nmasuntosdisciplinarios == cd_nmAsuntosDisciplinarios).FirstOrDefault();
        }

        public bool InsertDecVie_AsuntosDisciplinarios(DecVie_AsuntosDisciplinarios decVie_AsuntosDisciplinarios)
        {
            Add(decVie_AsuntosDisciplinarios);
            return true;
        }

        public bool UpdateDecVie_AsuntosDisciplinarios(DecVie_AsuntosDisciplinarios decVie_AsuntosDisciplinarios)
        {
            Update(decVie_AsuntosDisciplinarios);
            return true;
        }
        DataTableAdapter<DecVie_AsuntosDisciplinarios> IDecVie_AsuntosDisciplinariosRepository.GetDataTableDecVie_AsuntosDisciplinarios(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_AsuntosDisciplinarios, bool>> srchByFunc = null;
            Expression<Func<DecVie_AsuntosDisciplinarios, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmasuntosdisciplinarios.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_AsuntosDisciplinarios>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_AsuntosDisciplinarios> result = new DataTableAdapter<DecVie_AsuntosDisciplinarios>();

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