using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ImpresionGramajeRepository
    {
        IEnumerable<Publicaciones_ImpresionGramaje> GetAllPublicaciones_ImpresionGramaje();
        Publicaciones_ImpresionGramaje GetPublicaciones_ImpresionGramajeDetails(int id_gramaje);
        Publicaciones_ImpresionGramaje GetPublicaciones_ImpresionGramajeNombre(string cd_nmgramaje);
        bool InsertPublicaciones_ImpresionGramaje(Publicaciones_ImpresionGramaje publicaciones_ImpresionGramaje);
        bool UpdatePublicaciones_ImpresionGramaje(Publicaciones_ImpresionGramaje publicaciones_ImpresionGramaje);
        bool DeletePublicaciones_ImpresionGramaje(int id_gramaje);
        DataTableAdapter<Publicaciones_ImpresionGramaje> GetDataTablePublicaciones_ImpresionGramaje(DataTableRequest model);
    }
}
