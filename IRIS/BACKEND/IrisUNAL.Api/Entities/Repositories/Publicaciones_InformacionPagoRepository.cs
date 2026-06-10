using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_InformacionPagoRepository : SuperType<Publicaciones_InformacionPago>, IPublicaciones_InformacionPagoRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_InformacionPagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_InformacionPagoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_InformacionPago(int id_informacionpago)
        {
            Delete(id_informacionpago);
            return true;
        }

        public IEnumerable<Publicaciones_InformacionPago> GetAllPublicaciones_InformacionPago()
        {
            return Get();
        }

        public Publicaciones_InformacionPago GetPublicaciones_InformacionPagoDetails(int id_informacionpago)
        {
            return Get(id_informacionpago);
        }

        public bool InsertPublicaciones_InformacionPago(Publicaciones_InformacionPago publicaciones_InformacionPago)
        {
            Add(publicaciones_InformacionPago);
            return true;
        }

        public bool UpdatePublicaciones_InformacionPago(Publicaciones_InformacionPago publicaciones_InformacionPago)
        {
            Update(publicaciones_InformacionPago);
            return true;
        }

        public Publicaciones_InformacionPago GetPublicaciones_InformacionPagoByEvaluador(int id_evaluadores)
        {
            return Get(p => p.id_evaluadores == id_evaluadores).FirstOrDefault();
        }
    }
}