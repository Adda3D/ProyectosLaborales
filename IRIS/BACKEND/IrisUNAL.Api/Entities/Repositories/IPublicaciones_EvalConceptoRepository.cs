using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EvalConceptoRepository
    {
        IEnumerable<Publicaciones_EvalConcepto> GetAllPublicaciones_EvalConcepto();
        Publicaciones_EvalConcepto GetPublicaciones_EvalConceptoDetails(int id_evalconcepto);
        IEnumerable<Publicaciones_EvalConcepto> GetPublicaciones_EvalConceptoByPublicacion(int id_crearpublicacion);
        Publicaciones_EvalConcepto GetPublicaciones_EvalConceptoByEvaluador(int id_evaluadores);
        Publicaciones_EvalConcepto GetPublicaciones_EvalConceptoByPublicacionEvaluacion(int id_crearpublicacion, int id_evalgenerada);
        bool InsertPublicaciones_EvalConcepto(Publicaciones_EvalConcepto publicaciones_EvalConcepto);
        bool UpdatePublicaciones_EvalConcepto(Publicaciones_EvalConcepto publicaciones_EvalConcepto);
        bool DeletePublicaciones_EvalConcepto(int id_evalconcepto);
    }
}
