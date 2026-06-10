using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionMediosRepository
    {
        IEnumerable<Publicaciones_DivulgacionMedios> GetAllPublicaciones_DivulgacionMedios();
        Publicaciones_DivulgacionMedios GetPublicaciones_DivulgacionMediosDetails(int id_medio);
        Publicaciones_DivulgacionMedios GetPublicaciones_DivulgacionMediosNombre(string cd_nommedio);
        bool InsertPublicaciones_DivulgacionMedios(Publicaciones_DivulgacionMedios publicaciones_DivulgacionMedios);
        bool UpdatePublicaciones_DivulgacionMedios(Publicaciones_DivulgacionMedios publicaciones_DivulgacionMedios);
        bool DeletePublicaciones_DivulgacionMedios(int id_medio);
        DataTableAdapter<Publicaciones_DivulgacionMedios> GetDataTablePublicaciones_DivulgacionMedios(DataTableRequest model);
    }
}
