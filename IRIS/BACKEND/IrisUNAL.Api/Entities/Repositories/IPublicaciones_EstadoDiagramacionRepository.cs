using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EstadoDiagramacionRepository
    {
        IEnumerable<Publicaciones_EstadoDiagramacion> GetAllPublicaciones_EstadoDiagramacion();
        Publicaciones_EstadoDiagramacion GetPublicaciones_EstadoDiagramacionDetails(int id_estadodiagramacion);
        Publicaciones_EstadoDiagramacion GetPublicaciones_EstadoDiagramacionNombre(string cd_nmestadodiagramacion);
        bool InsertPublicaciones_EstadoDiagramacion(Publicaciones_EstadoDiagramacion publicaciones_EstadoDiagramacion);
        bool UpdatePublicaciones_EstadoDiagramacion(Publicaciones_EstadoDiagramacion publicaciones_EstadoDiagramacion);
        bool DeletePublicaciones_EstadoDiagramacion(int id_estadodiagramacion);
        DataTableAdapter<Publicaciones_EstadoDiagramacion> GetDataTablePublicaciones_EstadoDiagramacion(DataTableRequest model);
    }
}
