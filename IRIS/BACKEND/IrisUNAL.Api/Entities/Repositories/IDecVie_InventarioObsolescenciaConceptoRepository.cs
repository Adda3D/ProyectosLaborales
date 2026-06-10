using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_InventarioObsolescenciaConceptoRepository
    {
        IEnumerable<DecVie_InventarioObsolescenciaConcepto> GetAllDecVie_InventarioObsolescenciaConcepto();
        DecVie_InventarioObsolescenciaConcepto GetDecVie_InventarioObsolescenciaConceptoDetails(int id_obsolescenciaconcepto);
        DecVie_InventarioObsolescenciaConcepto GetDecVie_InventarioObsolescenciaConceptoNombre(string cd_nmconcepto);
        bool InsertDecVie_InventarioObsolescenciaConcepto(DecVie_InventarioObsolescenciaConcepto decVie_InventarioObsolescenciaConcepto);
        bool UpdateDecVie_InventarioObsolescenciaConcepto(DecVie_InventarioObsolescenciaConcepto decVie_InventarioObsolescenciaConcepto);
        bool DeleteDecVie_InventarioObsolescenciaConcepto(int id_obsolescenciaconcepto);
        DataTableAdapter<DecVie_InventarioObsolescenciaConcepto> GetDataTableDecVie_InventarioObsolescenciaConcepto(DataTableRequest model);
    }
}
