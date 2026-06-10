using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ConceptoRepository
    {
        IEnumerable<DecVie_Concepto> GetAllDecVie_Concepto();
        DecVie_Concepto GetDecVie_ConceptoDetails(int id_decvieconcepto);
        DecVie_Concepto GetDecVie_ConceptoNombre(string cd_nmconcepto);
        bool InsertDecVie_Concepto(DecVie_Concepto decVie_Concepto);
        bool UpdateDecVie_Concepto(DecVie_Concepto decVie_Concepto);
        bool DeleteDecVie_Concepto(int id_decvieconcepto);
        DataTableAdapter<DecVie_Concepto> GetDataTableDecVie_Concepto(DataTableRequest model);
    }
}
