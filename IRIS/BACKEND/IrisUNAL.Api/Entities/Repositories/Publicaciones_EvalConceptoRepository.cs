using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_EvalConceptoRepository : SuperType<Publicaciones_EvalConcepto>, IPublicaciones_EvalConceptoRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EvalConceptoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EvalConceptoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EvalConcepto(int id_evalconcepto)
        {
            Delete(id_evalconcepto);
            return true;
        }

        public IEnumerable<Publicaciones_EvalConcepto> GetAllPublicaciones_EvalConcepto()
        {
            return Get();
        }

        public IEnumerable<Publicaciones_EvalConcepto> GetPublicaciones_EvalConceptoByPublicacion(int id_crearpublicacion)
        {
            return Get(c => c.id_crearpublicacion == id_crearpublicacion);
        }

        public Publicaciones_EvalConcepto GetPublicaciones_EvalConceptoDetails(int id_evalconcepto)
        {
            return Get(id_evalconcepto);
        }

        public bool InsertPublicaciones_EvalConcepto(Publicaciones_EvalConcepto publicaciones_EvalConcepto)
        {
            Add(publicaciones_EvalConcepto);
            return true;
        }

        public bool UpdatePublicaciones_EvalConcepto(Publicaciones_EvalConcepto publicaciones_EvalConcepto)
        {
            Update(publicaciones_EvalConcepto);
            return true;
        }

        public Publicaciones_EvalConcepto GetPublicaciones_EvalConceptoByEvaluador(int id_evaluadores)
        {
            return Get(e => e.id_evaluadores == id_evaluadores).FirstOrDefault();
        }

        public Publicaciones_EvalConcepto GetPublicaciones_EvalConceptoByPublicacionEvaluacion(int id_crearpublicacion, int id_evalgenerada)
        {
            return Get(e => e.id_crearpublicacion == id_crearpublicacion && e.id_evalgenerada == id_evalgenerada).FirstOrDefault();
        }
    }
}