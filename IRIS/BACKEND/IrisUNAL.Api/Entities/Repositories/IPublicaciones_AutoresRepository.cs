using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_AutoresRepository
    {
        IEnumerable<Publicaciones_Autores> GetAllPublicaciones_Autores();
        Publicaciones_Autores GetPublicaciones_AutoresDetails(int id_autores);
        Publicaciones_Autores GetPublicaciones_AutoresByPublicacion(int id_crearpublicacion, int id_persona);
        bool InsertPublicaciones_Autores(Publicaciones_Autores publicaciones_Autores);
        bool UpdatePublicaciones_Autores(Publicaciones_Autores publicaciones_Autores);
        bool DeletePublicaciones_Autores(int id_autores);
        DataTableAdapter<Publicaciones_Autores> GetDataTablePublicaciones_AutoresByPublicacion(int id_crearpublicacion, DataTableRequest model);
        Publicaciones_Autores GetPublicaciones_AutoresDetailsPersona(int id_autores);
        bool UpdatePublicaciones_AutoresLanzamiento(Publicaciones_Autores publicaciones_Autores);
        bool UpdatePublicaciones_AutoresCierre(Publicaciones_Autores publicaciones_Autores);
    }
}
