using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
  public interface IPublicaciones_TipologiaRepository
    {
        IEnumerable<Publicaciones_Tipologia> GetAllPublicaciones_Tipologia();
        Publicaciones_Tipologia GetPublicaciones_TipologiaDetails(int id_tipologia);        
        bool InsertPublicaciones_Tipologia(Publicaciones_Tipologia publicaciones_Tipologia);
        bool UpdatePublicaciones_Tipologia(Publicaciones_Tipologia publicaciones_Tipologia);
        bool DeletePublicaciones_Tipologia(int id_tipologia);
    }
}
