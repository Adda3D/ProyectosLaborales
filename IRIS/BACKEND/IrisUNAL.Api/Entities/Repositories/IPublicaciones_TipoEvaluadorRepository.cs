using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
   public interface IPublicaciones_TipoEvaluadorRepository
    {
        IEnumerable<Publicaciones_TipoEvaluador> GetAllPublicaciones_TipoEvaluador();
        Publicaciones_TipoEvaluador GetPublicaciones_TipoEvaluadorDetails(int id_tipoevaluador);        
        bool InsertPublicaciones_TipoEvaluador(Publicaciones_TipoEvaluador publicaciones_TipoEvaluador);
        bool UpdatePublicaciones_TipoEvaluador(Publicaciones_TipoEvaluador publicaciones_TipoEvaluador);
        bool DeletePublicaciones_TipoEvaluador(int id_tipoevaluador);
    }
}
