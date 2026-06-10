using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ImpresionPapelRepository
    {
        IEnumerable<Publicaciones_ImpresionPapel> GetAllPublicaciones_ImpresionPapel();
        Publicaciones_ImpresionPapel GetPublicaciones_ImpresionPapelDetails(int id_papel);
        Publicaciones_ImpresionPapel GetPublicaciones_ImpresionPapelNombre(string cd_nmpapel);
        bool InsertPublicaciones_ImpresionPapel(Publicaciones_ImpresionPapel publicaciones_ImpresionPapel);
        bool UpdatePublicaciones_ImpresionPapel(Publicaciones_ImpresionPapel publicaciones_ImpresionPapel);
        bool DeletePublicaciones_ImpresionPapel(int id_papel);
        DataTableAdapter<Publicaciones_ImpresionPapel> GetDataTablePublicaciones_ImpresionPapel(DataTableRequest model);
    }
}
