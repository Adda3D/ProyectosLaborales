using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InventarioConocimientoEnfasisRepository
    {
        IEnumerable<DecVie_InventarioConocimientoEnfasis> GetAllDecVie_InventarioConocimientoEnfasis();
        DecVie_InventarioConocimientoEnfasis GetDecVie_InventarioConocimientoEnfasisDetails(int id_conocimientoenfasis);
        DecVie_InventarioConocimientoEnfasis GetDecVie_InventarioConocimientoEnfasisNombre(string cd_nmenfasis);
        bool InsertDecVie_InventarioConocimientoEnfasis(DecVie_InventarioConocimientoEnfasis decVie_InventarioConocimientoEnfasis);
        bool UpdateDecVie_InventarioConocimientoEnfasis(DecVie_InventarioConocimientoEnfasis decVie_InventarioConocimientoEnfasis);
        bool DeleteDecVie_InventarioConocimientoEnfasis(int id_conocimientoenfasis);
        DataTableAdapter<DecVie_InventarioConocimientoEnfasis> GetDataTableDecVie_InventarioConocimientoEnfasis(DataTableRequest model);
    }
}
