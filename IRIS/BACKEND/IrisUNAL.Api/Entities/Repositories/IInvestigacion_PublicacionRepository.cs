using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IInvestigacion_PublicacionRepository
    {
        IEnumerable<Investigacion_Publicacion> GetAllInvestigacion_Publicacion();
        Investigacion_Publicacion GetInvestigacion_PublicacionDetails(int id_invpublicacion);
        IEnumerable<Investigacion_Publicacion> GetInvestigacion_PublicacionCodigo(string codigohermes);
        bool InsertInvestigacion_Publicacion(Investigacion_Publicacion investigacion_Publicacion);
        bool UpdateInvestigacion_Publicacion(Investigacion_Publicacion investigacion_Publicacion);
        bool DeleteInvestigacion_Publicacion(int id_invpublicacion);
    }
}
