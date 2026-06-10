using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ColeccionRepository
    {
        IEnumerable<Publicaciones_Coleccion> GetAllPublicaciones_Coleccion();
        Publicaciones_Coleccion GetPublicaciones_ColeccionDetails(int id_coleccion);
        Publicaciones_Coleccion GetPublicaciones_ColeccionNombre(string cd_nmcoleccion);
        int GetPublicaciones_ColeccionConsecutivo(int id_coleccion);
        bool InsertPublicaciones_Coleccion(Publicaciones_Coleccion publicaciones_Coleccion);
        bool UpdatePublicaciones_Coleccion(Publicaciones_Coleccion publicaciones_Coleccion);
        bool DeletePublicaciones_Coleccion(int id_coleccion);
        DataTableAdapter<Publicaciones_Coleccion> GetDataTablePublicaciones_Coleccion(DataTableRequest model);
    }
}
