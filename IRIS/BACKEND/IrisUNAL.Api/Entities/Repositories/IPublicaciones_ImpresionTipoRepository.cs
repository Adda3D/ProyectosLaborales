using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ImpresionTipoRepository
    {
        IEnumerable<Publicaciones_ImpresionTipo> GetAllPublicaciones_ImpresionTipo();
        Publicaciones_ImpresionTipo GetPublicaciones_ImpresionTipoDetails(int id_impresiontipo);
        Publicaciones_ImpresionTipo GetPublicaciones_ImpresionTipoNombre(string cd_nmimpresiontipo);
        bool InsertPublicaciones_ImpresionTipo(Publicaciones_ImpresionTipo publicaciones_ImpresionTipo);
        bool UpdatePublicaciones_ImpresionTipo(Publicaciones_ImpresionTipo publicaciones_ImpresionTipo);
        bool DeletePublicaciones_ImpresionTipo(int id_impresiontipo);
        DataTableAdapter<Publicaciones_ImpresionTipo> GetDataTablePublicaciones_ImpresionTipo(DataTableRequest model);
    }
}
