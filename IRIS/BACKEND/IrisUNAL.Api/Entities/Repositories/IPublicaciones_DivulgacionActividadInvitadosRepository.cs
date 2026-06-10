using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionActividadInvitadosRepository
    {
        IEnumerable<Publicaciones_DivulgacionActividadInvitados> GetAllPublicaciones_DivulgacionActividadInvitados();
        Publicaciones_DivulgacionActividadInvitados GetPublicaciones_DivulgacionActividadInvitadosDetails(int id_invitados);        
        bool InsertPublicaciones_DivulgacionActividadInvitados(Publicaciones_DivulgacionActividadInvitados publicaciones_DivulgacionActividadInvitados);
        bool UpdatePublicaciones_DivulgacionActividadInvitados(Publicaciones_DivulgacionActividadInvitados publicaciones_DivulgacionActividadInvitados);
        bool DeletePublicaciones_DivulgacionActividadInvitados(int id_invitados);
        DataTableAdapter<Publicaciones_DivulgacionActividadInvitados> GetDataTablePublicaciones_DivulgacionActividadInvitadosByPublicacion(int id_crearpublicacion, DataTableRequest model);
        bool UpdatePublicaciones_DivulgacionActividadInvitadosCierre(Publicaciones_DivulgacionActividadInvitados publicaciones_DivulgacionActividadInvitados);
    }
}
