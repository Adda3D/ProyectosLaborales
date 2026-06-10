using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DigitalizacionRepository
    {
        IEnumerable<Publicaciones_Digitalizacion> GetAllPublicaciones_Digitalizacion();
        Publicaciones_Digitalizacion GetPublicaciones_DigitalizacionDetails(int id_digitalizacion);
        Publicaciones_Digitalizacion GetPublicaciones_DigitalizacionByPublicacion(int id_crearpublicacion);
        bool InsertPublicaciones_Digitalizacion(Publicaciones_Digitalizacion publicaciones_Digitalizacion);
        bool UpdatePublicaciones_Digitalizacion(Publicaciones_Digitalizacion publicaciones_Digitalizacion);
        bool DeletePublicaciones_Digitalizacion(int id_digitalizacion);
    }
}
