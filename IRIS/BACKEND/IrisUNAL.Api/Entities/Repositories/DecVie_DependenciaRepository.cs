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
    public class DecVie_DependenciaRepository : SuperType<DecVie_Dependencia>, IDecVie_DependenciaRepository
    {
        private ApplicationDbContext _context;

        public DecVie_DependenciaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_DependenciaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_Dependencia(int id_decviedependencia)
        {
            Delete(id_decviedependencia);
            return true;
        }

        public IEnumerable<DecVie_Dependencia> GetAllDecVie_Dependencia()
        {
            return Get();
        }

        public DecVie_Dependencia GetDecVie_DependenciaDetails(int id_decviedependencia)
        {
            return Get(id_decviedependencia);
        }

        public DecVie_Dependencia GetDecVie_DependenciaNombre(string cd_nmdecviedependencia)
        {
            return Get(c => c.nmdecviedependencia == cd_nmdecviedependencia).FirstOrDefault();
        }

        public bool InsertDecVie_Dependencia(DecVie_Dependencia decVie_Dependencia)
        {
            Add(decVie_Dependencia);
            return true;
        }

        public bool UpdateDecVie_Dependencia(DecVie_Dependencia decVie_Dependencia)
        {
            Update(decVie_Dependencia);
            return true;
        }
        DataTableAdapter<DecVie_Dependencia> IDecVie_DependenciaRepository.GetDataTableDecVie_Dependencia(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_Dependencia, bool>> srchByFunc = null;
            Expression<Func<DecVie_Dependencia, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmdecviedependencia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_Dependencia>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_Dependencia> result = new DataTableAdapter<DecVie_Dependencia>();

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