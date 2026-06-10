using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_AreaCurricularRepository
    {
        IEnumerable<Publicaciones_AreaCurricular> GetAllPublicaciones_AreaCurricular();
        Publicaciones_AreaCurricular GetPublicaciones_AreaCurricularDetails(int id_areacurricular);
        Publicaciones_AreaCurricular GetPublicaciones_AreaCurricularDetails(string cd_nmareacurricular);
        bool InsertPublicaciones_AreaCurricular(Publicaciones_AreaCurricular publicaciones_AreaCurricular);
        bool UpdatePublicaciones_AreaCurricular(Publicaciones_AreaCurricular publicaciones_AreaCurricular);
        bool DeletePublicaciones_AreaCurricular(int id_areacurricular);
        DataTableAdapter<Publicaciones_AreaCurricular> GetDataTablePublicaciones_AreaCurricular(DataTableRequest model);
    }
}
