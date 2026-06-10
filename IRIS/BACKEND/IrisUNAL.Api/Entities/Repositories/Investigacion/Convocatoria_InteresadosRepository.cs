using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Investigacion;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Investigacion
{
    public class Convocatoria_InteresadosRepository : SuperType<Convocatoria_Interesados>
    {
        private ApplicationDbContext _context;

        public Convocatoria_InteresadosRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Convocatoria_InteresadosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Convocatoria_Interesados> GetAllConvocatoria_Interesados()
        {
            return Get();
        }
        public Convocatoria_Interesados GetConvocatoria_InteresadosDetails(int id_interesados)
        {
            return Get(id_interesados);
        }
        public Convocatoria_Interesados GetConvocatoria_InteresadosNombre(string cd_nombreinteresado)
        {
            return Get(c => c.nombreinteresado == cd_nombreinteresado).FirstOrDefault();
        }
        public bool InsertConvocatoria_Interesados(Convocatoria_Interesados convocatoria_Interesados)
        {
            Add(convocatoria_Interesados);
            return true;
        }
        public bool UpdateConvocatoria_Interesados(Convocatoria_Interesados convocatoria_Interesados)
        {
            Update(convocatoria_Interesados);
            return true;
        }
        public bool DeleteConvocatoria_Interesados(int id_interesados)
        {
            Delete(id_interesados);
            return true;
        }
        public DataTableAdapter<Convocatoria_Interesados> GetDataTableConvocatoria_InteresadosByConvocatoria(int id_convocatoria, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Convocatoria_Interesados, bool>> srchByFunc = null;
            Expression<Func<Convocatoria_Interesados, int>> orderByFunc = null;
            Expression<Func<Convocatoria_Interesados, object>> parameter1 = p => p.Objconvocatoria;

            Expression<Func<Convocatoria_Interesados, object>>[] parameterArray = new Expression<Func<Convocatoria_Interesados, object>>[] { parameter1, };
            bool isOrderDesc = false;

            //FILTRA POR Convocatoria
            srchByFunc = d => d.id_convocatoria == id_convocatoria;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_convocatoria == id_convocatoria && d.nombreinteresado.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderByInt<Convocatoria_Interesados>("id_interesados");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Convocatoria_Interesados> result = new DataTableAdapter<Convocatoria_Interesados>();

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