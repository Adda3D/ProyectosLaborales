using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_OrigenManuscritoRepository
    {
        IEnumerable<Publicaciones_OrigenManuscrito> GetAllPublicaciones_OrigenManuscrito();
        Publicaciones_OrigenManuscrito GetPublicaciones_OrigenManuscritoDetails(int id_origenmanuscrito);
        Publicaciones_OrigenManuscrito GetPublicaciones_OrigenManuscritoNombre(string cd_nmorigenmanuscrito);
        bool InsertPublicaciones_OrigenManuscrito(Publicaciones_OrigenManuscrito publicaciones_OrigenManuscrito);
        bool UpdatePublicaciones_OrigenManuscrito(Publicaciones_OrigenManuscrito publicaciones_OrigenManuscrito);
        bool DeletePublicaciones_OrigenManuscrito(int id_origenmanuscrito);
        DataTableAdapter<Publicaciones_OrigenManuscrito> GetDataTablePublicaciones_OrigenManuscrito(DataTableRequest model);
    }
}
