using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using Npgsql;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_InventarioGestionConocimientoRepository : SuperType<DecVie_InventarioGestionConocimiento>, IDecVie_InventarioGestionConocimientoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_InventarioGestionConocimientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_InventarioGestionConocimientoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_InventarioGestionConocimiento(int id_invgesconocimiento)
        {
            Delete(id_invgesconocimiento);
            return true;
        }

        public IEnumerable<DecVie_InventarioGestionConocimiento> GetAllDecVie_InventarioGestionConocimiento()
        {
            return Get();
        }

        public DecVie_InventarioGestionConocimiento GetDecVie_InventarioGestionConocimientoDetails(int id_invgesconocimiento)
        {
            return Get(id_invgesconocimiento);
        }

        public bool InsertDecVie_InventarioGestionConocimiento(DecVie_InventarioGestionConocimiento decVie_InventarioGestionConocimiento)
        {
            Add(decVie_InventarioGestionConocimiento);
            return true;
        }

        public bool UpdateDecVie_InventarioGestionConocimiento(DecVie_InventarioGestionConocimiento decVie_InventarioGestionConocimiento)
        {
            Update(decVie_InventarioGestionConocimiento);
            return true;
        }
        public DataTableAdapter<DecVie_InventarioGestionConocimiento> GetDataTableDecVie_InventarioGestionConocimiento(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_InventarioGestionConocimiento, DateTime>> orderByDateFunc = null;
            Expression<Func<DecVie_InventarioGestionConocimiento, bool>> srchByFunc = null;
            Expression<Func<DecVie_InventarioGestionConocimiento, string>> orderByFunc = null;
            Expression<Func<DecVie_InventarioGestionConocimiento, int>> orderByIntFunc = null;

            Expression<Func<DecVie_InventarioGestionConocimiento, object>> parameter1 = d => d.Objsoporte;
            Expression<Func<DecVie_InventarioGestionConocimiento, object>> parameter2 = d => d.Objtipologia;
            Expression<Func<DecVie_InventarioGestionConocimiento, object>> parameter3 = d => d.Objenfasis;
            Expression<Func<DecVie_InventarioGestionConocimiento, object>> parameter4 = d => d.Objcontratante;
            Expression<Func<DecVie_InventarioGestionConocimiento, object>> parameter5 = d => d.Objimpacto;
            Expression<Func<DecVie_InventarioGestionConocimiento, object>> parameter6 = d => d.Objpatentetipo;
            Expression<Func<DecVie_InventarioGestionConocimiento, object>> parameter7 = d => d.Objinsumo;
            Expression<Func<DecVie_InventarioGestionConocimiento, object>> parameter8 = d => d.Objahorro;
            Expression<Func<DecVie_InventarioGestionConocimiento, object>> parameter9 = d => d.Objobsolescenciaconcepto;

            Expression<Func<DecVie_InventarioGestionConocimiento, object>>[] parameterArray = new Expression<Func<DecVie_InventarioGestionConocimiento, object>>[] { parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9, };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.vigencia.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            if (model.SortColumn.ToLower() == "fechavaloracion")
                orderByDateFunc = CreateExpressionOrderByDate<DecVie_InventarioGestionConocimiento>("fechavaloracion");
            else

            if (model.SortColumn == "id_invgesconocimiento")
            {
                orderByIntFunc = CreateExpressionOrderByInt<DecVie_InventarioGestionConocimiento>(model.SortColumn);
            }
            else
            {
                orderByFunc = CreateExpressionOrderBy<DecVie_InventarioGestionConocimiento>(model.SortColumn);
            }

            //var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            //GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            List<DecVie_InventarioGestionConocimiento> data = null;
            if (model.SortColumn.ToLower() == "fechavaloracion")
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByDateFunc, isOrderDesc, parameterArray).ToList();
            else
            if (model.SortColumn == "id_invgesconocimiento")
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByIntFunc, isOrderDesc, parameterArray).ToList();
            }
            else
            {
                data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();
            }
            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_InventarioGestionConocimiento> result = new DataTableAdapter<DecVie_InventarioGestionConocimiento>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }
        public string ExcelDecVie_InventarioGestionConocimiento(int id_invgesconocimiento)
        {
            var archivoreturn = "/Export/InventarioGestionConocimiento_" + id_invgesconocimiento.ToString() + ".xlsx";
            var archivo = HttpContext.Current.Server.MapPath("~/Export/InventarioGestionConocimiento_" + id_invgesconocimiento.ToString() + ".xlsx");
            var plantilla = HttpContext.Current.Server.MapPath("~/Plantillas/InventarioGestionConocimiento.xlsx");            

            SLDocument xlsdocument = new SLDocument(plantilla);
            string qry = "select ig.id_invgesconocimiento, nmsoporte, vigencia, nmtipologia, nmenfasis, razonsocial, beneficiarios, nminsumo, " +
                        "nmimpacto, nmpatentetipo, vigenciapatente, entidadpatente, coalesce(gastos, 0) gastos, coalesce(costodirecto, 0) costodirecto, " +
                        "coalesce(total, 0) total, nmahorro,fechavaloracion, nmconcepto, coalesce(presupuestoejecutado, 0) presupuestoejecutado, " +
                        "coalesce(designadogestion, 0) designadogestion " +
                         "from decvie_inventariogestionconocimiento ig " +
                         "join decvie_inventarioconocimientosoporte cs on ig.id_conocimientosoporte = cs.id_conocimientosoporte " +
                         "join decvie_inventarioconocimientotipologia tp on ig.id_conocimientotipologia = tp.id_conocimientotipologia " +
                         "join decvie_inventarioconocimientoenfasis ce on ig.id_conocimientoenfasis = ce.id_conocimientoenfasis " +
                         "join propuesta_entidad pe on ig.idpropuesta_entidad = pe.idpropuesta_entidad " +
                         "left join decvie_inventarioconocimientoimpacto ci on ig.id_conocimientoimpacto = ci.id_conocimientoimpacto " +
                         "left join decvie_inventarioregistropatentetipo pt on ig.id_patentetipo = pt.id_patentetipo " +
                         "left join decvie_inventariousoampliadoinsumo ai on ig.id_insumo = ai.id_insumo " +
                         "left join decvie_inventariousoampliadoahorro aa on ig.id_ahorro = aa.id_ahorro " +
                         "left join decvie_inventarioobsolescenciaconcepto oc on ig.id_obsolescenciaconcepto = oc.id_obsolescenciaconcepto " +
                         "where ig.id_invgesconocimiento = @id_invgesconocimiento ";

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@id_invgesconocimiento", id_invgesconocimiento));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<DecVie_InventarioGestionConocimientoDTO>(qry, Param).ToList();

            int filaxls = 5;
            string celdaxls = "";
            
            foreach (var registro in datos)
            {
                filaxls += 1;                
                
                celdaxls = "A" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.nmsoporte);                
                celdaxls = "B" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.vigencia);                
                celdaxls = "C" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.nmtipologia);                
                celdaxls = "D" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.nmenfasis);                
                celdaxls = "E" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.razonsocial);                
                celdaxls = "F" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.beneficiarios);                
                celdaxls = "G" + filaxls.ToString();                
                xlsdocument.SetCellValue(celdaxls, registro.nmimpacto);                
                celdaxls = "H" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.nmpatentetipo);                
                celdaxls = "I" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.vigenciapatente);                
                celdaxls = "J" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.entidadpatente);                
                celdaxls = "K" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.gastos.ToString());                
                celdaxls = "L" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.costodirecto.ToString());                
                celdaxls = "M" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.total.ToString());                
                celdaxls = "N" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.nminsumo);                
                celdaxls = "O" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.nmahorro);
                celdaxls = "P" + filaxls.ToString();

                if (registro.fechavaloracion != null)
                {
                    DateTime fechavaloracion = (DateTime)registro.fechavaloracion;
                    xlsdocument.SetCellValue(celdaxls, fechavaloracion.ToString("yyy-MM-dd"));
                }
                
                celdaxls = "Q" + filaxls.ToString();
                xlsdocument.SetCellValue(celdaxls, registro.nmconcepto);                
                celdaxls = "R" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.presupuestoejecutado.ToString());                
                celdaxls = "S" + filaxls.ToString();
                xlsdocument.SetCellValueNumeric(celdaxls, registro.designadogestion.ToString());

            }

            xlsdocument.SaveAs(archivo);
            return archivoreturn;
        }
    }
}