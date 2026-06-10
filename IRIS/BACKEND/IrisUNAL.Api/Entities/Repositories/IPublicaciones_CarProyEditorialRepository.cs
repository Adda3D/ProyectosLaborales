using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_CarProyEditorialRepository
    {
        IEnumerable<Publicaciones_CarProyEditorial> GetAllPublicaciones_CarProyEditorial();
        Publicaciones_CarProyEditorial GetPublicaciones_CarProyEditorialDetails(int id_carproyeditorial);
        Publicaciones_CarProyEditorial GetPublicaciones_CarProyEditorialNombre(string cd_nmcarproyeditorial);
        bool InsertPublicaciones_CarProyEditorial(Publicaciones_CarProyEditorial publicaciones_CarProyEditorial);
        bool UpdatePublicaciones_CarProyEditorial(Publicaciones_CarProyEditorial publicaciones_CarProyEditorial);
        bool DeletePublicaciones_CarProyEditorial(int id_carproyeditorial);
        DataTableAdapter<Publicaciones_CarProyEditorial> GetDataTablePublicaciones_CarProyEditorial(DataTableRequest model);
    }
}
