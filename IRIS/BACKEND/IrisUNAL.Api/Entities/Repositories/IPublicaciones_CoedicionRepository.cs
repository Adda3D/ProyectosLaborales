using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_CoedicionRepository
    {
        IEnumerable<Publicaciones_Coedicion> GetAllPublicaciones_Coedicion();
        Publicaciones_Coedicion GetPublicaciones_CoedicionDetails(int id_coedicion);
        IEnumerable<Publicaciones_Coedicion> GetPublicaciones_CoedicionNumero(string cd_numcontrato);
        bool InsertPublicaciones_Coedicion(Publicaciones_Coedicion publicaciones_Coedicion);
        bool UpdatePublicaciones_Coedicion(Publicaciones_Coedicion publicaciones_Coedicion);
        bool DeletePublicaciones_Coedicion(int id_coedicion);
    }
}
