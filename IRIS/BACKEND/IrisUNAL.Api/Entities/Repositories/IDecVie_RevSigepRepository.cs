using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_RevSigepRepository
    {
        IEnumerable<DecVie_RevSigep> GetAllDecVie_RevSigep();
        DecVie_RevSigep GetDecVie_RevSigepDetails(int id_revsigep);
        DecVie_RevSigep GetDecVie_RevSigepNombre(string cd_nmrevsigep);
        bool InsertDecVie_RevSigep(DecVie_RevSigep decVie_RevSigep);
        bool UpdateDecVie_RevSigep(DecVie_RevSigep decVie_RevSigep);
        bool DeleteDecVie_RevSigep(int id_revsigep);
        DataTableAdapter<DecVie_RevSigep> GetDataTableDecVie_RevSigep(DataTableRequest model);
    }
}
