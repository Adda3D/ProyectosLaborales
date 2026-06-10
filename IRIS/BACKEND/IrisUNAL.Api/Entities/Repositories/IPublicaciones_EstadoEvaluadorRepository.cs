using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EstadoEvaluadorRepository
    {
        IEnumerable<Publicaciones_EstadoEvaluador> GetAllPublicaciones_EstadoEvaluador();
        Publicaciones_EstadoEvaluador GetPublicaciones_EstadoEvaluadorDetails(int id_estadoevaluador);
        Publicaciones_EstadoEvaluador GetPublicaciones_EstadoEvaluadorNombre(string cd_nmestadoevaluador);
        bool InsertPublicaciones_EstadoEvaluador(Publicaciones_EstadoEvaluador publicaciones_EstadoEvaluador);
        bool UpdatePublicaciones_EstadoEvaluador(Publicaciones_EstadoEvaluador publicaciones_EstadoEvaluador);
        bool DeletePublicaciones_EstadoEvaluador(int id_estadoevaluador);
        DataTableAdapter<Publicaciones_EstadoEvaluador> GetDataTablePublicaciones_EstadoEvaluador(DataTableRequest model);
    }
}
