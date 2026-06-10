using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Seguimiento_RubroRepository : SuperType<Seguimiento_Rubro>, ISeguimiento_RubroRepository
    {
        private ApplicationDbContext _context;

        public Seguimiento_RubroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_RubroRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimiento_Rubro(int id_rubro)
        {
            Delete(id_rubro);
            return true;
        }

        public IEnumerable<Seguimiento_Rubro> GetAllSeguimiento_Rubro()
        {
            return Get();
        }

        public IEnumerable<Seguimiento_Rubro> GetSeguimiento_RubroCodigo(string cd_codigointernorubro)
        {
            return Get(c=>c.codigointernorubro == cd_codigointernorubro);
        }

        public Seguimiento_Rubro GetSeguimiento_RubroDetails(int id_rubro)
        {
            return Get(id_rubro);
        }

        public bool InsertSeguimiento_Rubro(Seguimiento_Rubro seguimiento_Rubro)
        {
            Add(seguimiento_Rubro);
            return true;
        }

        public bool UpdateSeguimiento_Rubro(Seguimiento_Rubro seguimiento_Rubro)
        {
            Update(seguimiento_Rubro);
            return true;
        }

        public IEnumerable<Seguimiento_Rubro> GetAllSeguimiento_RubroByPartida(int id_partida)
        {
            return Get(r => r.id_partida == id_partida);
        }
    }
}