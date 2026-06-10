using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
   public interface IPublicaciones_TipoObraRepository
    {
        IEnumerable<Publicaciones_TipoObra> GetAllPublicaciones_TipoObra();
        Publicaciones_TipoObra GetPublicaciones_TipoObraDetails(int id_tipoobra);
        Publicaciones_TipoObra GetPublicaciones_TipoObraNombre(String cd_nmtipoobra);
        bool InsertPublicaciones_TipoObra(Publicaciones_TipoObra publicaciones_TipoObra);
        bool UpdatePublicaciones_TipoObra(Publicaciones_TipoObra publicaciones_TipoObra);
        bool DeletePublicaciones_TipoObra(int id_tipoobra);
        DataTableAdapter<Publicaciones_TipoObra> GetDataTablePublicaciones_TipoObra(DataTableRequest model);
    }
}
