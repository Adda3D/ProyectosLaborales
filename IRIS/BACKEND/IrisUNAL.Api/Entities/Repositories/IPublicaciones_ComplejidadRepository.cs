using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ComplejidadRepository
    {
        IEnumerable<Publicaciones_Complejidad> GetAllPublicaciones_Complejidad();
        Publicaciones_Complejidad GetPublicaciones_ComplejidadDetails(int id_complejidad);
        Publicaciones_Complejidad GetPublicaciones_ComplejidadNombre(string cd_nmcomplejidad);
        bool InsertPublicaciones_Complejidad(Publicaciones_Complejidad publicaciones_Complejidad);
        bool UpdatePublicaciones_Complejidad(Publicaciones_Complejidad publicaciones_Complejidad);
        bool DeletePublicaciones_Complejidad(int id_complejidad);
        DataTableAdapter<Publicaciones_Complejidad> GetDataTablePublicaciones_Complejidad(DataTableRequest model);
    }
}
