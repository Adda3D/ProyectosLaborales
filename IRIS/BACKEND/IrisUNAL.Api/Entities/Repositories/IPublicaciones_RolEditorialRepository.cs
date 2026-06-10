using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
   public interface IPublicaciones_RolEditorialRepository
    {
        IEnumerable<Publicaciones_RolEditorial> GetAllPublicaciones_RolEditorial();
        Publicaciones_RolEditorial GetPublicaciones_RolEditorialDetails(int id_roleditorial);
        IEnumerable<Publicaciones_RolEditorial> GetPublicaciones_RolEditorialNombre(string cd_nmroleditorial);
        bool InsertPublicaciones_RolEditorial(Publicaciones_RolEditorial publicaciones_RolEditorial);
        bool UpdatePublicaciones_RolEditorial(Publicaciones_RolEditorial publicaciones_RolEditorial);
        bool DeletePublicaciones_RolEditorial(int id_roleditorial);
    }
}
