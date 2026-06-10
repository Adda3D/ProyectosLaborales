using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InventarioConocimientoImpactoRepository
    {
        IEnumerable<DecVie_InventarioConocimientoImpacto> GetAllDecVie_InventarioConocimientoImpacto();
        DecVie_InventarioConocimientoImpacto GetDecVie_InventarioConocimientoImpactoDetails(int id_conocimientoimpacto);
        DecVie_InventarioConocimientoImpacto GetDecVie_InventarioConocimientoImpactoNombre(string cd_nmimpacto);
        bool InsertDecVie_InventarioConocimientoImpacto(DecVie_InventarioConocimientoImpacto decVie_InventarioConocimientoImpacto);
        bool UpdateDecVie_InventarioConocimientoImpacto(DecVie_InventarioConocimientoImpacto decVie_InventarioConocimientoImpacto);
        bool DeleteDecVie_InventarioConocimientoImpacto(int id_conocimientoimpacto);
        DataTableAdapter<DecVie_InventarioConocimientoImpacto> GetDataTableDecVie_InventarioConocimientoImpacto(DataTableRequest model);
    }
}
