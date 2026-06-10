using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ImpresionTintasTacoRepository
    {
        IEnumerable<Publicaciones_ImpresionTintasTaco> GetAllPublicaciones_ImpresionTintasTaco();
        Publicaciones_ImpresionTintasTaco GetPublicaciones_ImpresionTintasTacoDetails(int id_tintastaco);
        Publicaciones_ImpresionTintasTaco GetPublicaciones_ImpresionTintasTacoNombre(string cd_nmtintastaco);
        bool InsertPublicaciones_ImpresionTintasTaco(Publicaciones_ImpresionTintasTaco publicaciones_ImpresionTintasTaco);
        bool UpdatePublicaciones_ImpresionTintasTaco(Publicaciones_ImpresionTintasTaco publicaciones_ImpresionTintasTaco);
        bool DeletePublicaciones_ImpresionTintasTaco(int id_tintastaco);
        DataTableAdapter<Publicaciones_ImpresionTintasTaco> GetDataTablePublicaciones_ImpresionTintasTaco(DataTableRequest model);
    }
}
