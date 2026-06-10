using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_PlanAccionMetaRepository
    {
        IEnumerable<DecVie_PlanAccionMeta> GetAllDecVie_PlanAccionMeta();
        DecVie_PlanAccionMeta GetDecVie_PlanAccionMetaDetails(int id_meta);
        DecVie_PlanAccionMeta GetDecVie_PlanAccionMetaNombre(string cd_nmmeta);
        bool InsertDecVie_PlanAccionMeta(DecVie_PlanAccionMeta decVie_PlanAccionMeta);
        bool UpdateDecVie_PlanAccionMeta(DecVie_PlanAccionMeta decVie_PlanAccionMeta);
        bool DeleteDecVie_PlanAccionMeta(int id_meta);
        DataTableAdapter<DecVie_PlanAccionMeta> GetDataTableDecVie_PlanAccionMeta(DataTableRequest model);
    }
}
