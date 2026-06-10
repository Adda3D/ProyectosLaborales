using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Seguimiento_RelacionVinculoRepository : SuperType<Seguimiento_RelacionVinculo>, ISeguimiento_RelacionVinculoRepository
    {
        private ApplicationDbContext _context;

        public Seguimiento_RelacionVinculoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_RelacionVinculoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimiento_RelacionVinculo(int id_relacionvinculo)
        {
            Delete(id_relacionvinculo);
            return true;
        }

        public IEnumerable<Seguimiento_RelacionVinculo> GetAllSeguimiento_RelacionVinculo()
        {
            return Get();
        }

        public Seguimiento_RelacionVinculo GetSeguimiento_RelacionVinculoDetails(int id_relacionvinculo)
        {
            return Get(id_relacionvinculo);
        }

        public IEnumerable<Seguimiento_RelacionVinculo> GetSeguimiento_RelacionVinculoNombre(string cd_nombrerelacionvinculo)
        {
            return Get(c=>c.nombrerelacionvinculo==cd_nombrerelacionvinculo);
        }

        public bool InsertSeguimiento_RelacionVinculo(Seguimiento_RelacionVinculo seguimiento_RelacionVinculo)
        {
            Add(seguimiento_RelacionVinculo);
            return true;
        }

        public bool UpdateSeguimiento_RelacionVinculo(Seguimiento_RelacionVinculo seguimiento_RelacionVinculo)
        {
            Update(seguimiento_RelacionVinculo);
            return true;
        }
    }
}