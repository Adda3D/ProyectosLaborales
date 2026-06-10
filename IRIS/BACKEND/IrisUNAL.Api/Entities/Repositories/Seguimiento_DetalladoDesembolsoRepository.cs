using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Seguimiento_DetalladoDesembolsoRepository : SuperType<Seguimiento_DetalladoDesembolso>, ISeguimiento_DetalladoDesembolsoRepository
    {
        private ApplicationDbContext _context;

        public Seguimiento_DetalladoDesembolsoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_DetalladoDesembolsoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimiento_DetalladoDesembolso(int id_detdesembolso)
        {
            Delete(id_detdesembolso);
            return true;
        }

        public IEnumerable<Seguimiento_DetalladoDesembolso> GetAllSeguimiento_DetalladoDesembolso()
        {
            return Get();
        }

        public IEnumerable<Seguimiento_DetalladoDesembolso> GetSeguimiento_DetalladoDesembolsoCodigo(string cd_codigohermes)
        {
            return Get(c => c.codigoquipu == cd_codigohermes);
        }

        public Seguimiento_DetalladoDesembolso GetSeguimiento_DetalladoDesembolsoDetails(int id_detdesembolso)
        {
            return Get(id_detdesembolso);
        }

        public bool InsertSeguimiento_DetalladoDesembolso(Seguimiento_DetalladoDesembolso seguimiento_DetalladoDesembolso)
        {
            Add(seguimiento_DetalladoDesembolso);
            return true;
        }

        public bool UpdateSeguimiento_DetalladoDesembolso(Seguimiento_DetalladoDesembolso seguimiento_DetalladoDesembolso)
        {
            Update(seguimiento_DetalladoDesembolso);
            return true;
        }
    }
}