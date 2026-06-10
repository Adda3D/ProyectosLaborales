using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimiento_ConceptoRepository
    {
        IEnumerable<Seguimiento_Concepto> GetAllSeguimiento_Concepto();
        Seguimiento_Concepto GetSeguimiento_ConceptoDetails(int id_concepto);
        IEnumerable<Seguimiento_Concepto> GetSeguimiento_ConceptoCodigo(string cd_codigointernoconcepto);
        IEnumerable<Seguimiento_Concepto> GetSeguimiento_ConceptoByRubro(int id_rubro);
        bool InsertSeguimiento_Concepto(Seguimiento_Concepto seguimiento_Concepto);
        bool UpdateSeguimiento_Concepto(Seguimiento_Concepto seguimiento_Concepto);
        bool DeleteSeguimiento_Concepto(int id_concepto);
        DataTableAdapter<Seguimiento_Concepto> GetDataTableSeguimiento_Concepto(DataTableRequest model);
    }
}
