using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PreAvalRepository
    {
        IEnumerable<DecVie_PreAval> GetAllDecVie_PreAval();
        DecVie_PreAval GetDecVie_PreAvalDetails(int id_preaval);
        DecVie_PreAval GetDecVie_PreAvalCodigo(string cd_consecutivo);
        bool InsertDecVie_PreAval(DecVie_PreAval decVie_PreAval);
        bool UpdateDecVie_PreAval(DecVie_PreAval decVie_PreAval);
        bool UpdateDecVie_PreAvalRevision(DecVie_PreAvalRevisionDTO decVie_PreAvalRevision);
        bool UpdateDecVie_PreAvalConceptoDecanatura(DecVie_PreAvalConceptoDecanaturaDTO decVie_PreAvalConceptoDecanatura);
        bool DeleteDecVie_PreAval(int id_preaval);
        DataTableAdapter<DecVie_PreAval> GetDataTableDecVie_PreAval(DataTableRequest model);
    }
}
