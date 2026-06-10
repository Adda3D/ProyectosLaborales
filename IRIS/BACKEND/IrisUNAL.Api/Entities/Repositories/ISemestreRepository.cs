using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISemestreRepository
    {
        IEnumerable<Semestre> GetAllSemestre();
        Semestre GetSemestreDetails(int id_semestre);
        Semestre GetSemestreNombre(string cd_nmsemestre);
        bool InsertSemestre(Semestre semestre);
        bool UpdateSemestre(Semestre semestre);
        bool DeleteSemestre(int id_semestre);
        DataTableAdapter<Semestre> GetDataTableSemestre(DataTableRequest model);
    }
}
