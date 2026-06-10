using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ImpresionRepository
    {
        IEnumerable<Publicaciones_Impresion> GetAllPublicaciones_Impresion();
        Publicaciones_Impresion GetPublicaciones_ImpresionDetails(int id_impresion);
        Publicaciones_Impresion GetPublicaciones_ImpresionByPublicacion(int id_crearpublicacion);
        bool InsertPublicaciones_Impresion(Publicaciones_Impresion publicaciones_Impresion);
        bool UpdatePublicaciones_Impresion(Publicaciones_Impresion publicaciones_Impresion);
        bool DeletePublicaciones_Impresion(int id_impresion);
    }
}
