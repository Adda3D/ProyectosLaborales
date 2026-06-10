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
    public class FuncionarioRepository : SuperType<Funcionario>
    {
        private ApplicationDbContext _context;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public FuncionarioRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Funcionario> GetAllFuncionario()
        {
            return Get();
        }
        public Funcionario GetFuncionarioDetails(int idfuncionario)
        {
            return Get(idfuncionario);
        }
        public Funcionario GetFuncionarioIdentificacion(string identificacion)
        {
            return Get(f => f.numidentificacion == identificacion).FirstOrDefault();
        }
        public bool InsertFuncionario(Funcionario funcionario)
        {
            Add(funcionario);
            return true;
        }
        public bool UpdateFuncionario(Funcionario funcionario)
        {
            Update(funcionario);
            return true;

        }
        public bool DeleteFuncionario(int idfuncionario)
        {
            Delete(idfuncionario);
            return true;
        }
        public DataTableAdapter<Funcionario> GetDataTableFuncionario(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Funcionario, bool>> srchByFunc = null;
            Expression<Func<Funcionario, string>> orderByFunc = null;

            Expression<Func<Funcionario, object>> parameter1 = v => v.depfuncionario;
            Expression<Func<Funcionario, object>>[] parameterArray = new Expression<Func<Funcionario, object>>[] { parameter1 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nombres.ToLower().Contains(model.SearchValue.ToLower()) || d.apellidos.ToLower().Contains(model.SearchValue.ToLower()) || d.numidentificacion.Contains(model.SearchValue);
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Funcionario>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();
            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Funcionario> result = new DataTableAdapter<Funcionario>();

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