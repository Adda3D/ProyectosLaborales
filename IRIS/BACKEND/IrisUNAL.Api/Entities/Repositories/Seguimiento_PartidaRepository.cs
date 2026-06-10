using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Seguimiento_PartidaRepository : SuperType<Seguimiento_Partida>, ISeguimiento_PartidaRepository
    {
        private ApplicationDbContext _context;

        public Seguimiento_PartidaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_PartidaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimiento_Partida(int id_partida)
        {
            Delete(id_partida);
            return true;
        }

        public IEnumerable<Seguimiento_Partida> GetAllSeguimiento_Partida()
        {
            return Get();
        }

        public IEnumerable<Seguimiento_Partida> GetSeguimiento_PartidaCodigo(string cd_codigointernopartida)
        {
            return Get(c => c.codigointernopartida==cd_codigointernopartida);
        }

        public Seguimiento_Partida GetSeguimiento_PartidaDetails(int id_partida)
        {
            return Get(id_partida);
        }

        public bool InsertSeguimiento_Partida(Seguimiento_Partida seguimiento_Partida)
        {
            Add(seguimiento_Partida);
            return true;
        }

        public bool UpdateSeguimiento_Partida(Seguimiento_Partida seguimiento_Partida)
        {
            Update(seguimiento_Partida);
            return true;
        }
    }
}