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
    public class DecVie_ConsecutivoRepository : SuperType<DecVie_Consecutivo>, IDecVie_ConsecutivoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_ConsecutivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_ConsecutivoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_Consecutivo(int id_decvieconsecutivo)
        {
            Delete(id_decvieconsecutivo);
            return true;
        }

        public IEnumerable<DecVie_Consecutivo> GetAllDecVie_Consecutivo()
        {
            return Get();
        }

        public DecVie_Consecutivo GetDecVie_ConsecutivoDetails(int id_decvieconsecutivo)
        {
            return Get(id_decvieconsecutivo);
        }

        public DecVie_Consecutivo GetDecVie_ConsecutivoNumero(string cd_numconsecutivo)
        {
            return Get(c => c.numconsecutivo == cd_numconsecutivo).FirstOrDefault();
        }

        public bool InsertDecVie_Consecutivo(DecVie_Consecutivo decVie_Consecutivo)
        {   
            //Cambio ADDA se comento la linea 50 a las 58
            //string sconsecutivo = "";

            //GENERAR EL CONSECUTIVO
            //using (Consecutivo_AnnioRepository objconsecutivo = new Consecutivo_AnnioRepository())
            //{
                //sconsecutivo = objconsecutivo.GetConsecutivo_Annio(decVie_Consecutivo.id_prefijoconsecutivo, decVie_Consecutivo.fecha);
            //}

            //decVie_Consecutivo.numconsecutivo = sconsecutivo;
            
            Add(decVie_Consecutivo);
            return true;
        }

        public bool UpdateDecVie_Consecutivo(DecVie_Consecutivo decVie_Consecutivo)
        {
            Update(decVie_Consecutivo);
            return true;
        }

        public DataTableAdapter<DecVie_Consecutivo> GetDataTableDecVie_Consecutivo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_Consecutivo, DateTime>> orderByDateFunc = null;
            Expression<Func<DecVie_Consecutivo, bool>> srchByFunc = null;
            Expression<Func<DecVie_Consecutivo, string>> orderByFunc = null;
            Expression<Func<DecVie_Consecutivo, int>> orderByIntFunc = null;

            Expression<Func<DecVie_Consecutivo, object>> parameter2 = d => d.ObjFuncionario;
            Expression<Func<DecVie_Consecutivo, object>> parameter3 = d => d.ObjDependencia;
            Expression<Func<DecVie_Consecutivo, object>> parameter5 = d => d.ObjDecVieConcepto;
            Expression<Func<DecVie_Consecutivo, object>> parameter7 = d => d.ObjMacroproceso; 
            Expression<Func<DecVie_Consecutivo, object>> parameter8 = d => d.Objprefijo;

            Expression<Func<DecVie_Consecutivo, object>>[] parameterArray = new Expression<Func<DecVie_Consecutivo, object>>[] { parameter2, parameter3, parameter5, parameter7, parameter8, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.numconsecutivo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }
            
            isOrderDesc = model.SortColumnDir == "desc" ? false : true;

            if (model.SortColumn.ToLower() == "fecha")
                orderByDateFunc = CreateExpressionOrderByDate<DecVie_Consecutivo>("fecha");
            else

            if (model.SortColumn == "id_decvieconsecutivo")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_Consecutivo>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_Consecutivo>(model.SortColumn);
            }            

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_Consecutivo> data = null;
            if (model.SortColumn.ToLower() == "fecha")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
            else
            if (model.SortColumn == "id_decvieconsecutivo")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_Consecutivo> result = new DataTableAdapter<DecVie_Consecutivo>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DecVie_Consecutivo InsertDecVie_Consecutivo_Data(DecVie_Consecutivo decVie_Consecutivo)
        {
            // CAMBIO ADDA SE COMENTO 142 A LA 150
            //string sconsecutivo = "";

            ////GENERAR EL CONSECUTIVO
            //using (Consecutivo_AnnioRepository objconsecutivo = new Consecutivo_AnnioRepository())
            //{
            //    sconsecutivo = objconsecutivo.GetConsecutivo_Annio(decVie_Consecutivo.id_prefijoconsecutivo, decVie_Consecutivo.fecha);
            //}

            //decVie_Consecutivo.numconsecutivo = sconsecutivo;

            return Add(decVie_Consecutivo);            
        }

        public DecVie_Consecutivo UpdateDecVie_Consecutivo_Data(DecVie_Consecutivo decVie_Consecutivo)
        {
            return Update(decVie_Consecutivo);
        }
    }
}