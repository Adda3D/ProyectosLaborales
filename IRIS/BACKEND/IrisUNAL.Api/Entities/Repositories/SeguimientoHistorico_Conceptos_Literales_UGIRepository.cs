using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class SeguimientoHistorico_Conceptos_Literales_UGIRepository : SuperType<SeguimientoHistorico_Conceptos_Literales_UGI>, ISeguimientoHistorico_Conceptos_Literales_UGIRepository
    {
        private ApplicationDbContext _context;

        public SeguimientoHistorico_Conceptos_Literales_UGIRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public SeguimientoHistorico_Conceptos_Literales_UGIRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimientoHistorico_Conceptos_Literales_UGI(int id_ejesemugi)
        {
            Delete(id_ejesemugi);
            return true;
        }

        public IEnumerable<SeguimientoHistorico_Conceptos_Literales_UGI> GetAllSeguimientoHistorico_Conceptos_Literales_UGI()
        {
            return Get();
        }

        public SeguimientoHistorico_Conceptos_Literales_UGI GetSeguimientoHistorico_Conceptos_Literales_UGIDetails(int id_ejesemugi)
        {
            return Get(id_ejesemugi);
        }

        public IEnumerable<SeguimientoHistorico_Conceptos_Literales_UGI> GetSeguimientoHistorico_Conceptos_Literales_UGIDetails(string cd_numeroresolucion)
        {
            return Get(c => c.numeroresolucion == cd_numeroresolucion);
        }

        public bool InsertSeguimientoHistorico_Conceptos_Literales_UGI(SeguimientoHistorico_Conceptos_Literales_UGI seguimientoHistorico_Conceptos_Literales_UGI)
        {
            Add(seguimientoHistorico_Conceptos_Literales_UGI);
            return true;
        }

        public bool UpdateSeguimientoHistorico_Conceptos_Literales_UGI(SeguimientoHistorico_Conceptos_Literales_UGI seguimientoHistorico_Conceptos_Literales_UGI)
        {
            Update(seguimientoHistorico_Conceptos_Literales_UGI);
            return true;

        }
    }
}