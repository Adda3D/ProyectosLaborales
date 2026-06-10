using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimiento_FinancieroExcelRepository
    {
        IEnumerable<Seguimiento_FinancieroExcel> GetAllSeguimiento_FinancieroExcel();
        Seguimiento_FinancieroExcel GetSeguimiento_FinancieroExcelDetails(int id_financieroexcel);
        IEnumerable<Seguimiento_FinancieroExcel> GetSeguimiento_FinancieroExcelCodigo(string cd_codigoquipu);
        bool InsertSeguimiento_FinancieroExcel(Seguimiento_FinancieroExcel seguimiento_FinancieroExcel);
        bool UpdateSeguimiento_FinancieroExcel(Seguimiento_FinancieroExcel seguimiento_FinancieroExcel);
        bool DeleteSeguimiento_FinancieroExcel(int id_financieroexcel);
    }
}
