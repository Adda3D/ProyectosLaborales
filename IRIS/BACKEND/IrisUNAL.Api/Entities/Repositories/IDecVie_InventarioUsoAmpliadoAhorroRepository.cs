using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InventarioUsoAmpliadoAhorroRepository
    {
        IEnumerable<DecVie_InventarioUsoAmpliadoAhorro> GetAllDecVie_InventarioUsoAmpliadoAhorro();
        DecVie_InventarioUsoAmpliadoAhorro GetDecVie_InventarioUsoAmpliadoAhorroDetails(int id_ahorro);
        DecVie_InventarioUsoAmpliadoAhorro GetDecVie_InventarioUsoAmpliadoAhorroNombre(string cd_nmahorro);
        bool InsertDecVie_InventarioUsoAmpliadoAhorro(DecVie_InventarioUsoAmpliadoAhorro decVie_InventarioUsoAmpliadoAhorro);
        bool UpdateDecVie_InventarioUsoAmpliadoAhorro(DecVie_InventarioUsoAmpliadoAhorro decVie_InventarioUsoAmpliadoAhorro);
        bool DeleteDecVie_InventarioUsoAmpliadoAhorro(int id_ahorro);
        DataTableAdapter<DecVie_InventarioUsoAmpliadoAhorro> GetDataTableDecVie_InventarioUsoAmpliadoAhorro(DataTableRequest model);
    }
}
