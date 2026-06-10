using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionAlcanceAnnoRepository
    {
        IEnumerable<DecVie_PlanAccionAlcanceAnno> GetAllDecVie_PlanAccionAlcanceAnno();
        DecVie_PlanAccionAlcanceAnno GetDecVie_PlanAccionAlcanceAnnoDetails(int id_alcanceanno);
        DecVie_PlanAccionAlcanceAnno GetDecVie_PlanAccionAlcanceAnnoNombre(string cd_nmalcanceanno);
        bool InsertDecVie_PlanAccionAlcanceAnno(DecVie_PlanAccionAlcanceAnno decVie_PlanAccionAlcanceAnno);
        bool UpdateDecVie_PlanAccionAlcanceAnno(DecVie_PlanAccionAlcanceAnno decVie_PlanAccionAlcanceAnno);
        bool DeleteDecVie_PlanAccionAlcanceAnno(int id_alcanceanno);
        DataTableAdapter<DecVie_PlanAccionAlcanceAnno> GetDataTableDecVie_PlanAccionAlcanceAnno(DataTableRequest model);
    }
}
