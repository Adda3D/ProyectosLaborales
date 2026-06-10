using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_PreAvalRepository : SuperType<DecVie_PreAval>, IDecVie_PreAvalRepository
    {
        private ApplicationDbContext _context;

        public DecVie_PreAvalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_PreAvalRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_PreAval(int id_preaval)
        {
            Delete(id_preaval);
            return true;
        }

        public IEnumerable<DecVie_PreAval> GetAllDecVie_PreAval()
        {
            return Get();
        }

        public DecVie_PreAval GetDecVie_PreAvalCodigo(string cd_consecutivo)
        {
            return Get(c => c.consecutivo == cd_consecutivo).FirstOrDefault();
        }

        public DecVie_PreAval GetDecVie_PreAvalDetails(int id_preaval)
        {
            return Get(id_preaval);
        }

        public bool InsertDecVie_PreAval(DecVie_PreAval decVie_PreAval)
        {
            Add(decVie_PreAval);
            return true;
        }

        public bool UpdateDecVie_PreAval(DecVie_PreAval decVie_PreAval)
        {
            Update(decVie_PreAval);
                return true;
        }

        public bool UpdateDecVie_PreAvalConceptoDecanatura(DecVie_PreAvalConceptoDecanaturaDTO decVie_PreAvalConceptoDecanatura)
        {
            var datos = Get(decVie_PreAvalConceptoDecanatura.id_preaval);

            if (datos != null)
            {
                datos.id_conceptodecanatura = decVie_PreAvalConceptoDecanatura.id_conceptodecanatura;
                datos.id_estadopreaval = decVie_PreAvalConceptoDecanatura.id_estadopreaval;
                datos.observacionesdecanatura = decVie_PreAvalConceptoDecanatura.observacionesdecanatura;

                Update(datos);
            }

            return true;

        }

        public bool UpdateDecVie_PreAvalRevision(DecVie_PreAvalRevisionDTO decVie_PreAvalRevision)
        {
            var datos = Get(decVie_PreAvalRevision.id_preaval);

            if (datos != null)
            {
                datos.revisionprecontractual = decVie_PreAvalRevision.revisionprecontractual;
                datos.id_revsigep = decVie_PreAvalRevision.id_revsigep;
                datos.id_asuntosdisciplinarios = decVie_PreAvalRevision.id_asuntosdisciplinarios;
                datos.id_estadopreaval = decVie_PreAvalRevision.id_estadopreaval;

                Update(datos);
            }

            return true;

        }

        public DataTableAdapter<DecVie_PreAval> GetDataTableDecVie_PreAval(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_PreAval, DateTime>> orderByDateFunc = null;
            Expression<Func<DecVie_PreAval, bool>> srchByFunc = null;
            Expression<Func<DecVie_PreAval, string>> orderByFunc = null;
            Expression<Func<DecVie_PreAval, int>> orderByIntFunc = null;

            Expression<Func<DecVie_PreAval, object>> parameter1 = p => p.Objmacroproceso;
            Expression<Func<DecVie_PreAval, object>> parameter2 = p => p.Objpersona;
            Expression<Func<DecVie_PreAval, object>> parameter3 = p => p.Objrubro;
            Expression<Func<DecVie_PreAval, object>> parameter4 = p => p.Objdependencia;
            Expression<Func<DecVie_PreAval, object>> parameter5 = p => p.Objtipodocumentoscontractuales;
            /*Expression<Func<DecVie_PreAval, object>> parameter6 = p => p.Objrevsigep;
            Expression<Func<DecVie_PreAval, object>> parameter7 = p => p.Objasuntosdisciplinarios;
            Expression<Func<DecVie_PreAval, object>> parameter8 = p => p.Objconceptodecanatura;*/
            Expression<Func<DecVie_PreAval, object>> parameter9 = p => p.Objestadopreaval;

            Expression<Func<DecVie_PreAval, object>>[] parameterArray = new Expression<Func<DecVie_PreAval, object>>[] { parameter1, parameter2, parameter3, parameter4, parameter5, parameter9, };
            

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.consecutivo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn.ToLower() == "fecradicacion")
                orderByDateFunc = CreateExpressionOrderByDate<DecVie_PreAval>("fecradicacion");
            else

            if (model.SortColumn == "id_preaval")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_PreAval>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_PreAval>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_PreAval> data = null;
            if (model.SortColumn.ToLower() == "fecradicacion")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
            else
            if (model.SortColumn == "id_preaval")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_PreAval> result = new DataTableAdapter<DecVie_PreAval>();

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