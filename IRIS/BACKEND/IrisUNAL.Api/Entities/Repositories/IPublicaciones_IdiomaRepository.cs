using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_IdiomaRepository
    {
        IEnumerable<Publicaciones_Idioma> GetAllPublicaciones_Idioma();
        Publicaciones_Idioma GetPublicaciones_IdiomaDetails(int id_idioma);
        Publicaciones_Idioma GetPublicaciones_IdiomaNombre(string cd_nmidioma);
        bool InsertPublicaciones_Idioma(Publicaciones_Idioma publicaciones_Idioma);
        bool UpdatePublicaciones_Idioma(Publicaciones_Idioma publicaciones_Idioma);
        bool DeletePublicaciones_Idioma(int id_idioma);
        DataTableAdapter<Publicaciones_Idioma> GetDataTablePublicaciones_Idioma(DataTableRequest model);
    }
}
