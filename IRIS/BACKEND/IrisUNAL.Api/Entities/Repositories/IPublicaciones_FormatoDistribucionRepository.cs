using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_FormatoDistribucionRepository
    {
        IEnumerable<Publicaciones_FormatoDistribucion> GetAllPublicaciones_FormatoDistribucion();
        Publicaciones_FormatoDistribucion GetPublicaciones_FormatoDistribucionDetails(int id_formatodistribucion);
        Publicaciones_FormatoDistribucion GetPublicaciones_FormatoDistribucionNombre(string cd_nmformatodis);
        bool InsertPublicaciones_FormatoDistribucion(Publicaciones_FormatoDistribucion publicaciones_FormatoDistribucion);
        bool UpdatePublicaciones_FormatoDistribucion(Publicaciones_FormatoDistribucion publicaciones_FormatoDistribucion);
        bool DeletePublicaciones_FormatoDistribucion(int id_formatodistribucion);
        DataTableAdapter<Publicaciones_FormatoDistribucion> GetDataTablePublicaciones_FormatoDistribucion(DataTableRequest model);
    }
}
