using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IArea_AcademicaRepository
    {
        IEnumerable<Area_Academica> GetAllArea_Academica();
        Area_Academica GetArea_AcademicaDetails(int id_areaacad);
        IEnumerable<Area_Academica> GetArea_AcademicaDetails(string cd_areaacad);
        DataTableAdapter<Area_Academica> GetDataTableArea(DataTableRequest model);
        bool InsertArea_Academica(Area_Academica area_Academica);
        bool UpdateArea_Academica(Area_Academica area_Academica);
        bool DeleteArea_Academica(int id_areaacad);
    }
}
