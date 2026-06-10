using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InventarioConocimientoTipologiaRepository
    {
        IEnumerable<DecVie_InventarioConocimientoTipologia> GetAllDecVie_InventarioConocimientoTipologia();
        DecVie_InventarioConocimientoTipologia GetDecVie_InventarioConocimientoTipologiaDetails(int id_conocimientotipologia);
        DecVie_InventarioConocimientoTipologia GetDecVie_InventarioConocimientoTipologiaNombre(string cd_nmtipologia);
        bool insertDecVie_InventarioConocimientoTipologia(DecVie_InventarioConocimientoTipologia decVie_InventarioConocimientoTipologia);
        bool UpdateDecVie_InventarioConocimientoTipologia(DecVie_InventarioConocimientoTipologia decVie_InventarioConocimientoTipologia);
        bool DeleteDecVie_InventarioConocimientoTipologia(int id_conocimientotipologia);
        DataTableAdapter<DecVie_InventarioConocimientoTipologia> GetDataTableDecVie_InventarioConocimientoTipologia(DataTableRequest model);
    }
}
