using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_HermesRepository
    {
        IEnumerable<Publicaciones_Hermes> GetAllPublicaciones_Hermes();
        Publicaciones_Hermes GetPublicaciones_HermesDetails(int id_hermes);
        IEnumerable<Publicaciones_Hermes> GetPublicaciones_HermesNumero(string cd_numhermes);
        bool InsertPublicaciones_Hermes(Publicaciones_Hermes publicaciones_Hermes);
        bool UpdatePublicaciones_Hermes(Publicaciones_Hermes publicaciones_Hermes);
        bool DeletePublicaciones_Hermes(int id_hermes);
    }
}
