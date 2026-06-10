using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DiagramacionRepository
    {
        IEnumerable<Publicaciones_Diagramacion> GetAllPublicaciones_Diagramacion();
        Publicaciones_Diagramacion GetPublicaciones_DiagramacionDetails(int id_diagramacion);
        Publicaciones_Diagramacion GetPublicaciones_DiagramacionByPublicacionTipo(int id_crearpublicacion, string tipodiagramacion);
        bool InsertPublicaciones_Diagramacion(Publicaciones_Diagramacion publicaciones_Diagramacion);
        bool UpdatePublicaciones_Diagramacion(Publicaciones_Diagramacion publicaciones_Diagramacion);
        bool DeletePublicaciones_Diagramacion(int id_diagramacion);
    }
}
