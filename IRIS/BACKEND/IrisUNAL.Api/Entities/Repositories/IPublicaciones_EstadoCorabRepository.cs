using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EstadoCorabRepository
    {
        IEnumerable<Publicaciones_EstadoCorab> GetAllPublicaciones_EstadoCorab();
        Publicaciones_EstadoCorab GetPublicaciones_EstadoCorabDetails(int id_estadocorab);
        Publicaciones_EstadoCorab GetPublicaciones_EstadoCorabNombre(string cd_nmestadocorab);
        bool InsertPublicaciones_EstadoCorab(Publicaciones_EstadoCorab publicaciones_EstadoCorab);
        bool UpdatePublicaciones_EstadoCorab(Publicaciones_EstadoCorab publicaciones_EstadoCorab);
        bool DeletePublicaciones_EstadoCorab(int id_estadocorab);
        DataTableAdapter<Publicaciones_EstadoCorab> GetDataTablePublicaciones_EstadoCorab(DataTableRequest model);
    }
}
