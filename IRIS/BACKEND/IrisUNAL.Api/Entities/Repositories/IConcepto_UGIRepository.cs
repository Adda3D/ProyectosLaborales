using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System.Collections.Generic;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IConcepto_UGIRepository
    {
        bool DeleteConcepto_UGI(int id_conceptougi);
        IEnumerable<Concepto_UGI> GetAllConcepto_UGI();        
        Concepto_UGI GetConcepto_UGIDetails(int id_conceptougi);
        Concepto_UGI GetConcepto_UGINombre(string cd_concepto);
        bool InsertConcepto_UGI(Concepto_UGI concepto_UGI);
        bool UpdateConcepto_UGI(Concepto_UGI concepto_UGI);
        DataTableAdapter<Concepto_UGI> GetDataTableConcepto_UGI(DataTableRequest model);
    }
}