using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionTipoMedioRepository
    {
        IEnumerable<Publicaciones_DivulgacionTipoMedio> GetAllPublicaciones_DivulgacionTipoMedio();
        Publicaciones_DivulgacionTipoMedio GetPublicaciones_DivulgacionTipoMedioDetails(int id_tipomedio);
        Publicaciones_DivulgacionTipoMedio GetPublicaciones_DivulgacionTipoMedioNombre(string cd_nmtipomedio);
        bool InsertPublicaciones_DivulgacionTipoMedio(Publicaciones_DivulgacionTipoMedio publicaciones_DivulgacionTipoMedio);
        bool UpdatePublicaciones_DivulgacionTipoMedio(Publicaciones_DivulgacionTipoMedio publicaciones_DivulgacionTipoMedio);
        bool DeletePublicaciones_DivulgacionTipoMedio(int id_tipomedio);
        DataTableAdapter<Publicaciones_DivulgacionTipoMedio> GetDataTablePublicaciones_DivulgacionTipoMedio(DataTableRequest model);
    }
}
