using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InventarioConocimientoSoporteRepository
    {
        IEnumerable<DecVie_InventarioConocimientoSoporte> GetAllDecVie_InventarioConocimientoSoporte();
        DecVie_InventarioConocimientoSoporte GetDecVie_InventarioConocimientoSoporteDetails(int id_conocimientosoporte);
        DecVie_InventarioConocimientoSoporte GetDecVie_InventarioConocimientoSoporteNombre(string cd_nmsoporte);
        bool InsertDecVie_InventarioConocimientoSoporte(DecVie_InventarioConocimientoSoporte decVie_InventarioConocimientoSoporte);
        bool UpdateDecVie_InventarioConocimientoSoporte(DecVie_InventarioConocimientoSoporte decVie_InventarioConocimientoSoporte);
        bool DeleteDecVie_InventarioConocimientoSoporte(int id_conocimientosoporte);
        DataTableAdapter<DecVie_InventarioConocimientoSoporte> GetDataTableDecVie_InventarioConocimientoSoporte(DataTableRequest model);
    }
}
