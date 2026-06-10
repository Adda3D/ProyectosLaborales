using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EstadoCorreccionRepository
    {
        IEnumerable<Publicaciones_EstadoCorreccion> GetAllPublicaciones_EstadoCorreccion();
        Publicaciones_EstadoCorreccion GetPublicaciones_EstadoCorreccionDetails(int id_estadocorreccion);
        Publicaciones_EstadoCorreccion GetPublicaciones_EstadoCorreccionNombre(string cd_nmestadocorreccion);
        bool InsertPublicaciones_EstadoCorreccion(Publicaciones_EstadoCorreccion publicaciones_EstadoCorreccion);
        bool UpdatePublicaciones_EstadoCorreccion(Publicaciones_EstadoCorreccion publicaciones_EstadoCorreccion);
        bool DeletePublicaciones_EstadoCorreccion(int id_estadocorreccion);
        DataTableAdapter<Publicaciones_EstadoCorreccion> GetDataTablePublicaciones_EstadoCorreccion(DataTableRequest model);
    }
}
