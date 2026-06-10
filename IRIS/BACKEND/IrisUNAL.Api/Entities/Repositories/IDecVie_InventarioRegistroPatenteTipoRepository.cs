using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InventarioRegistroPatenteTipoRepository
    {
        IEnumerable<DecVie_InventarioRegistroPatenteTipo> GetAllDecVie_InventarioRegistroPatenteTipo();
        DecVie_InventarioRegistroPatenteTipo GetDecVie_InventarioRegistroPatenteTipoDetails(int id_patentetipo);
        DecVie_InventarioRegistroPatenteTipo GetDecVie_InventarioRegistroPatenteTipoNombre(string cd_nmpatentetipo);
        bool InsertDecVie_InventarioRegistroPatenteTipo(DecVie_InventarioRegistroPatenteTipo decVie_InventarioRegistroPatenteTipo);
        bool UpdateDecVie_InventarioRegistroPatenteTipo(DecVie_InventarioRegistroPatenteTipo decVie_InventarioRegistroPatenteTipo);
        bool DeleteDecVie_InventarioRegistroPatenteTipo(int id_patentetipo);
        DataTableAdapter<DecVie_InventarioRegistroPatenteTipo> GetDataTableDecVie_InventarioRegistroPatenteTipo(DataTableRequest model);
    }
}
