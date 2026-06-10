using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.TableModel;
using IrisUNAL.Api.Models.UGI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.UGI
{
    public class UGI_LiteralSemestreRepository : SuperType<UGI_LiteralSemestre>
    {
        private ApplicationDbContext _context;

        public UGI_LiteralSemestreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UGI_LiteralSemestreRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<UGI_LiteralSemestre> GetAllUGI_LiteralSemestre()
        {
            return Get();
        }
        public UGI_LiteralSemestre GetUGI_LiteralSemestreDetails(int id_ugiliteralsemestre)
        {
            return Get(id_ugiliteralsemestre);
        }
        public bool InsertUGI_LiteralSemestre(UGI_LiteralSemestre uGI_LiteralSemestre)
        {
            Add(uGI_LiteralSemestre);
            return true;
        }
        public bool UpdateUGI_LiteralSemestre(UGI_LiteralSemestre uGI_LiteralSemestre)
        {
            UpdateUGI_LiteralSemestre(uGI_LiteralSemestre);
            return true;
        }
        public bool DeleteUGI_LiteralSemestre(int id_ugiliteralsemestre)
        {
            Delete(id_ugiliteralsemestre);
            return true;
        }
        public DataTableAdapter<UGI_LiteralSemestre> GetDataTableUGI_LiteralSemestre(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            //Expression<Func<UGI_LiteralSemestre, DateTime>> orderByDateFunc = null;
            Expression<Func<UGI_LiteralSemestre, bool>> srchByFunc = null;
            Expression<Func<UGI_LiteralSemestre, string>> orderByFunc = null;
            Expression<Func<UGI_LiteralSemestre, int>> orderByIntFunc = null;

            Expression<Func<UGI_LiteralSemestre, object>> parameter1 = d => d.Objugisemestre;
            Expression<Func<UGI_LiteralSemestre, object>> parameter2 = d => d.Objliteral;

            Expression<Func<UGI_LiteralSemestre, object>>[] parameterArray = new Expression<Func<UGI_LiteralSemestre, object>>[] { parameter1, parameter2, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.NombreLiteral.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            //if (model.SortColumn.ToLower() == "fecresolucion")
            //    orderByDateFunc = CreateExpressionOrderByDate<UGI_LiteralSemestre>("fecresolucion");
            //else

            if (model.SortColumn == "id_ugiliteralsemestre")
            {
                orderByIntFunc = CreateExpressionOrderByInt<UGI_LiteralSemestre>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<UGI_LiteralSemestre>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<UGI_LiteralSemestre> data = null;
           /* if (model.SortColumn.ToLower() == "fecresolucion")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
            else*/
            if (model.SortColumn == "id_ugiliteralsemestre")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<UGI_LiteralSemestre> result = new DataTableAdapter<UGI_LiteralSemestre>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }
        public DataTableAdapter<UGI_LiteralSemestre> GetDataTableUGI_LiteralSemestreBySemestre(int id_ugisemestre, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<UGI_LiteralSemestre, bool>> srchByFunc = null;
            Expression<Func<UGI_LiteralSemestre, int>> orderByFunc = null;
            Expression<Func<UGI_LiteralSemestre, object>> parameter1 = p => p.Objugisemestre.Objsemestre;
            Expression<Func<UGI_LiteralSemestre, object>> parameter2 = p => p.Objliteral;

            Expression<Func<UGI_LiteralSemestre, object>>[] parameterArray = new Expression<Func<UGI_LiteralSemestre, object>>[] { parameter1, parameter2, };
            bool isOrderDesc = false;

            //FILTRA POR Ciclo Financiero
            srchByFunc = d => d.id_ugisemestre == id_ugisemestre;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_ugisemestre == id_ugisemestre && d.NombreSemestre.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderByInt<UGI_LiteralSemestre>("id_ugiliteralsemestre");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //**** TOTAL PROYECTADO
            var valoraportado = (from cs in _context.ugi_conceptosemestre
                                 where cs.id_ugisemestre == id_ugisemestre
                                 group cs by cs.id_ugiliteralsemestre into dt
                                 select new
                                 {
                                     valortotalizado = dt.Sum(x => x.valorproyectado),
                                     idliteral = dt.Key
                                 }).ToList();

            foreach (var literal in data)
            {
                var objtotal = valoraportado.Find(x => x.idliteral == literal.id_ugiliteralsemestre);

                if (objtotal != null)
                {
                    literal.valorproyectado = objtotal.valortotalizado;
                }
            }

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<UGI_LiteralSemestre> result = new DataTableAdapter<UGI_LiteralSemestre>();

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