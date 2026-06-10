using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ILiteral_UGIRepository
    {
        IEnumerable<Literal_UGI> GetAllLiteral_UGI();
        Literal_UGI GetLiteral_UGIDetails(int id_literal);
        Literal_UGI GetLiteral_UGINombre(string cd_nmliteral);
        bool InsertLiteral_UGI(Literal_UGI literal_UGI);
        bool UpdateLiteral_UGI(Literal_UGI literal_UGI);
        bool DeleteLiteral_UGI(int id_literal);
        DataTableAdapter<Literal_UGI> GetDataTableLiteral_UGI(DataTableRequest model);
    }
}
