using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionTituloRepository
    {
        IEnumerable<Publicaciones_DivulgacionTitulo> GetAllPublicaciones_DivulgacionTitulo();
        Publicaciones_DivulgacionTitulo GetPublicaciones_DivulgacionTituloDetails(int id_divtitulo);
        Publicaciones_DivulgacionTitulo GetPublicaciones_DivulgacionTituloNombre(string cd_nmtitulo);
        bool InsertPublicaciones_DivulgacionTitulo(Publicaciones_DivulgacionTitulo publicaciones_DivulgacionTitulo);
        bool UpdatePublicaciones_DivulgacionTitulo(Publicaciones_DivulgacionTitulo publicaciones_DivulgacionTitulo);
        bool DeletePublicaciones_DivulgacionTitulo(int id_divtitulo);
        DataTableAdapter<Publicaciones_DivulgacionTitulo> GetDataTablePublicaciones_DivulgacionTitulo(DataTableRequest model);
    }
}
