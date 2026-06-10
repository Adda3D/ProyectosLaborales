using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InventarioConocimientoContratanteRepository
    {
        IEnumerable<DecVie_InventarioConocimientoContratante> GetAllDecVie_InventarioConocimientoContratante();
        DecVie_InventarioConocimientoContratante GetDecVie_InventarioConocimientoContratanteDetails(int id_conocimientocontratante);
        DecVie_InventarioConocimientoContratante GetDecVie_InventarioConocimientoContratanteNombre(string cd_nmcontratante);
        bool InsertDecVie_InventarioConocimientoContratante(DecVie_InventarioConocimientoContratante decVie_InventarioConocimientoContratante);
        bool UpdateDecVie_InventarioConocimientoContratante(DecVie_InventarioConocimientoContratante decVie_InventarioConocimientoContratante);
        bool DeleteDecVie_InventarioConocimientoContratante(int id_conocimientocontratante);
        DataTableAdapter<DecVie_InventarioConocimientoContratante> GetDataTableDecVie_InventarioConocimientoContratante(DataTableRequest model);
    }
}
