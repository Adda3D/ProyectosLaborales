using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InventarioUsoAmpliadoInsumoRepository
    {
        IEnumerable<DecVie_InventarioUsoAmpliadoInsumo> GetAllDecVie_InventarioUsoAmpliadoInsumo();
        DecVie_InventarioUsoAmpliadoInsumo GetDecVie_InventarioUsoAmpliadoInsumoDetails(int id_insumo);
        DecVie_InventarioUsoAmpliadoInsumo GetDecVie_InventarioUsoAmpliadoInsumoNombre(string cd_nminsumo);
        bool InsertDecVie_InventarioUsoAmpliadoInsumo(DecVie_InventarioUsoAmpliadoInsumo decVie_InventarioUsoAmpliadoInsumo);
        bool UpdateDecVie_InventarioUsoAmpliadoInsumo(DecVie_InventarioUsoAmpliadoInsumo decVie_InventarioUsoAmpliadoInsumo);
        bool DeleteDecVie_InventarioUsoAmpliadoInsumo(int id_insumo);
        DataTableAdapter<DecVie_InventarioUsoAmpliadoInsumo> GetDataTableDecVie_InventarioUsoAmpliadoInsumo(DataTableRequest model);
    }
}
