using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DiagFinalTituloRepository
    {
        IEnumerable<Publicaciones_DiagFinalTitulo> GetAllPublicaciones_DiagFinalTitulo();
        Publicaciones_DiagFinalTitulo GetPublicaciones_DiagFinalTituloDetails(int id_diagfinaltitulo);
        Publicaciones_DiagFinalTitulo GetPublicaciones_DiagFinalTituloNombre(string cd_nmdiagfinaltitulo);
        bool InsertPublicaciones_DiagFinalTitulo(Publicaciones_DiagFinalTitulo publicaciones_DiagFinalTitulo);
        bool UpdatePublicaciones_DiagFinalTitulo(Publicaciones_DiagFinalTitulo publicaciones_DiagFinalTitulo);
        bool DeletePublicaciones_DiagFinalTitulo(int id_diagfinaltitulo);
        DataTableAdapter<Publicaciones_DiagFinalTitulo> GetDataTablePublicaciones_DiagFinalTitulo(DataTableRequest model);
    }
}
