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
    public class Convocatoria_RecursoParticipanteRepository : SuperType<Convocatoria_RecursoParticipante>
    {
        private ApplicationDbContext _context;

        public Convocatoria_RecursoParticipanteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Convocatoria_RecursoParticipanteRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Convocatoria_RecursoParticipante> GetAllConvocatoria_RecursoParticipante()
        {
            return Get();
        }
        public Convocatoria_RecursoParticipante GetConvocatoria_RecursoParticipanteDetails(int id_recursoparticipante)
        {
            return Get(id_recursoparticipante);
        }
        public Convocatoria_RecursoParticipante GetConvocatoria_RecursoParticipanteNombre(string cd_nmrecurso)
        {
            return Get(c => c.nmrecurso == cd_nmrecurso).FirstOrDefault();
        }
        public bool InsertConvocatoria_RecursoParticipante(Convocatoria_RecursoParticipante convocatoria_RecursoParticipante)
        {
            Add(convocatoria_RecursoParticipante);
            return true;
        }
        public bool UpdateConvocatoria_RecursoParticipante(Convocatoria_RecursoParticipante convocatoria_RecursoParticipante)
        {
            Update(convocatoria_RecursoParticipante);
            return true;
        }
        public bool DeleteConvocatoria_RecursoParticipante(int id_recursoparticipante)
        {
            Delete (id_recursoparticipante);
            return true;
        }
        public DataTableAdapter<Convocatoria_RecursoParticipante> GetDataTableConvocatoria_RecursoParticipanteByConvocatoria(int id_convocatoria, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<Convocatoria_RecursoParticipante, bool>> srchByFunc = null;
            Expression<Func<Convocatoria_RecursoParticipante, int>> orderByFunc = null;
            Expression<Func<Convocatoria_RecursoParticipante, object>> parameter1 = p => p.Objconvocatoria;

            Expression<Func<Convocatoria_RecursoParticipante, object>>[] parameterArray = new Expression<Func<Convocatoria_RecursoParticipante, object>>[] { parameter1, };
            bool isOrderDesc = false;

            //FILTRA POR Convocatoria
            srchByFunc = d => d.id_convocatoria == id_convocatoria;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_convocatoria == id_convocatoria && d.nmrecurso.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderByInt<Convocatoria_RecursoParticipante>("id_recursoparticipante");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Convocatoria_RecursoParticipante> result = new DataTableAdapter<Convocatoria_RecursoParticipante>();

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