using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ConceptoDecanaturaRepository
    {
        IEnumerable<DecVie_ConceptoDecanatura> GetAllDecVie_ConceptoDecanatura();
        DecVie_ConceptoDecanatura GetDecVie_ConceptoDecanaturaDetails(int id_conceptodecanatura);
        DecVie_ConceptoDecanatura GetDecVie_ConceptoDecanaturaNombre(string cd_nmconceptodecanatura);
        bool InsertDecVie_ConceptoDecanatura(DecVie_ConceptoDecanatura decVie_ConceptoDecanatura);
        bool UpdateDecVie_ConceptoDecanatura(DecVie_ConceptoDecanatura decVie_ConceptoDecanatura);
        bool DeleteDecVie_ConceptoDecanatura(int id_conceptodecanatura);
        DataTableAdapter<DecVie_ConceptoDecanatura> GetDataTableDecVie_ConceptoDecanatura(DataTableRequest model);
    }
}
