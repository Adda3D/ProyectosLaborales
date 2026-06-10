using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Seguimiento_DetalleRubroRepository : SuperType<Seguimiento_DetalleRubro>, ISeguimiento_DetalleRubroRepository
    {
        private ApplicationDbContext _context;

        public Seguimiento_DetalleRubroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_DetalleRubroRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimiento_DetalleRubro(int id_detallerubro)
        {
            Delete(id_detallerubro);
            return true;
        }

        public IEnumerable<Seguimiento_DetalleRubro> GetAllSeguimiento_DetalleRubro()
        {
            return Get();
        }

        public IEnumerable<Seguimiento_DetalleRubro> GetSeguimiento_DetalleRubroCodigo(string cd_codigointernorubro)
        {
            return Get(c => c.codigointernorubro == cd_codigointernorubro);
        }

        public Seguimiento_DetalleRubro GetSeguimiento_DetalleRubroDetails(int id_detallerubro)
        {
            return Get(id_detallerubro);
        }

        public bool InsertSeguimiento_DetalleRubro(Seguimiento_DetalleRubro seguimiento_DetalleRubro)
        {
            Add(seguimiento_DetalleRubro);
            return true;
        }

        public bool UpdateSeguimiento_DetalleRubro(Seguimiento_DetalleRubro seguimiento_DetalleRubro)
        {
            Update(seguimiento_DetalleRubro);
            return true;
        }
    }
}