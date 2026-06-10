using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_CostosOrigenContratoRepository : SuperType<Publicaciones_CostosOrigenContrato>, IPublicaciones_CostosOrigenContratoRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_CostosOrigenContratoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_CostosOrigenContratoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_CostosOrigenContrato(int id_origencontrato)
        {
            Delete(id_origencontrato);
            return true;
        }

        public IEnumerable<Publicaciones_CostosOrigenContrato> GetAllPublicaciones_CostosOrigenContrato()
        {
            return Get();
        }

        public Publicaciones_CostosOrigenContrato GetPublicaciones_CostosOrigenContratoDetails(int id_origencontrato)
        {
            return Get(id_origencontrato);
        }

        public IEnumerable<Publicaciones_CostosOrigenContrato> GetPublicaciones_CostosOrigenContratoNombre(string cd_proyecto)
        {
            return Get(c => c.proyecto == cd_proyecto);
        }

        public bool InsertPublicaciones_CostosOrigenContrato(Publicaciones_CostosOrigenContrato publicaciones_CostosOrigenContrato)
        {
            Add(publicaciones_CostosOrigenContrato);
            return true;
        }

        public bool UpdatePublicaciones_CostosOrigenContrato(Publicaciones_CostosOrigenContrato publicaciones_CostosOrigenContrato)
        {
            Update(publicaciones_CostosOrigenContrato);
            return true;
        }
    }
}