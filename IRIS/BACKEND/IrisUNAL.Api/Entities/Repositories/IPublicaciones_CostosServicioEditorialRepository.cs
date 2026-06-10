using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_CostosServicioEditorialRepository
    {
        IEnumerable<Publicaciones_CostosServicioEditorial> GetAllPublicaciones_CostosServicioEditorial();
        Publicaciones_CostosServicioEditorial GetPublicaciones_CostosServicioEditorialDetails(int id_servicioeditorial);
        Publicaciones_CostosServicioEditorial GETPublicaciones_CostosServicioEditorialNombre(string cd_nomservicioeditorial);
        bool InsertPublicaciones_CostosServicioEditorial(Publicaciones_CostosServicioEditorial publicaciones_CostosServicioEditorial);
        bool UpdatePublicaciones_CostosServicioEditorial(Publicaciones_CostosServicioEditorial publicaciones_CostosServicioEditorial);
        bool DeletePublicaciones_CostosServicioEditorial(int id_servicioeditorial);
        DataTableAdapter<Publicaciones_CostosServicioEditorial> GetDataTablePublicaciones_CostosServicioEditorial(DataTableRequest model);
    }
}
