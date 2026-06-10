using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_ImpresionRepository : SuperType<Publicaciones_Impresion>, IPublicaciones_ImpresionRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ImpresionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ImpresionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Impresion(int id_impresion)
        {
            Delete(id_impresion);
            return true;
        }

        public IEnumerable<Publicaciones_Impresion> GetAllPublicaciones_Impresion()
        {
            return Get();
        }

        public Publicaciones_Impresion GetPublicaciones_ImpresionDetails(int id_impresion)
        {
            return Get(id_impresion);
        }

        public bool InsertPublicaciones_Impresion(Publicaciones_Impresion publicaciones_Impresion)
        {
            Add(publicaciones_Impresion);
            return true;
        }

        public bool UpdatePublicaciones_Impresion(Publicaciones_Impresion publicaciones_Impresion)
        {
            Update(publicaciones_Impresion);
            return true;
        }

        public Publicaciones_Impresion GetPublicaciones_ImpresionByPublicacion(int id_crearpublicacion)
        {
            return Get(i => i.id_crearpublicacion == id_crearpublicacion).FirstOrDefault();
        }
    }
}