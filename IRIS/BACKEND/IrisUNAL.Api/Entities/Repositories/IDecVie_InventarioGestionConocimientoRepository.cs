using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InventarioGestionConocimientoRepository
    {
        IEnumerable<DecVie_InventarioGestionConocimiento> GetAllDecVie_InventarioGestionConocimiento();
        DecVie_InventarioGestionConocimiento GetDecVie_InventarioGestionConocimientoDetails(int id_invgesconocimiento);
        bool InsertDecVie_InventarioGestionConocimiento(DecVie_InventarioGestionConocimiento decVie_InventarioGestionConocimiento);
        bool UpdateDecVie_InventarioGestionConocimiento(DecVie_InventarioGestionConocimiento decVie_InventarioGestionConocimiento);
        bool DeleteDecVie_InventarioGestionConocimiento(int id_invgesconocimiento);
        DataTableAdapter<DecVie_InventarioGestionConocimiento> GetDataTableDecVie_InventarioGestionConocimiento(DataTableRequest model);
        string ExcelDecVie_InventarioGestionConocimiento(int id_invgesconocimiento);
    }
}
