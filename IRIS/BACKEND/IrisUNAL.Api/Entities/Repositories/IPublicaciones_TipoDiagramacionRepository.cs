using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
   public interface IPublicaciones_TipoDiagramacionRepository
    {
        IEnumerable<Publicaciones_TipoDiagramacion> GetAllPublicaciones_TipoDiagramacion();
        Publicaciones_TipoDiagramacion GetPublicaciones_TipoDiagramacionDetails(int id_tipodiagramacion);
        Publicaciones_TipoDiagramacion GetPublicaciones_TipoDiagramacionNombre(string cd_nmtipodiagramacion);
        bool InsertPublicaciones_TipoDiagramacion(Publicaciones_TipoDiagramacion publicaciones_TipoDiagramacion);
        bool UpdatePublicaciones_TipoDiagramacion(Publicaciones_TipoDiagramacion publicaciones_TipoDiagramacion);
        bool DeletePublicaciones_TipoDiagramacion(int id_tipodiagramacion);
        DataTableAdapter<Publicaciones_TipoDiagramacion> GetDataTablePublicaciones_TipoDiagramacion(DataTableRequest model);
    }
}
