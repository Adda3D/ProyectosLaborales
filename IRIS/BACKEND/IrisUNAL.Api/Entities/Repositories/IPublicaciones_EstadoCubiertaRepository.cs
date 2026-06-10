using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EstadoCubiertaRepository
    {
        IEnumerable<Publicaciones_EstadoCubierta> GetAllPublicaciones_EstadoCubierta();
        Publicaciones_EstadoCubierta GetPublicaciones_EstadoCubiertaDetails(int id_estadocubierta);
        Publicaciones_EstadoCubierta GetPublicaciones_EstadoCubiertaNombre(string cd_nmestadocubierta);
        bool InsertPublicaciones_EstadoCubierta(Publicaciones_EstadoCubierta publicaciones_EstadoCubierta);
        bool UpdatePublicaciones_EstadoCubierta(Publicaciones_EstadoCubierta publicaciones_EstadoCubierta);
        bool DeletePublicaciones_EstadoCubierta(int id_estadocubierta);
        DataTableAdapter<Publicaciones_EstadoCubierta> GetDataTablePublicaciones_EstadoCubierta(DataTableRequest model);
    }
}
