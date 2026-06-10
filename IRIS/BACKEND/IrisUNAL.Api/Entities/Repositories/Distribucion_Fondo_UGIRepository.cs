using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Distribucion_Fondo_UGIRepository : SuperType<Distribucion_Fondo_UGI>, IDistribucion_Fondo_UGIRepository
    {
        private ApplicationDbContext _context;

        public Distribucion_Fondo_UGIRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Distribucion_Fondo_UGIRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDistribucion_Fondo_UGI(int id_fondougi)
        {
            Delete(id_fondougi);
            return true;
        }

        public IEnumerable<Distribucion_Fondo_UGI> GetAllDistribucion_Fondo_UGI()
        {
            return Get();
        }

        public Distribucion_Fondo_UGI GetDistribucion_Fondo_UGIDetails(int id_fondougi)
        {
            return Get(id_fondougi);
        }

        public IEnumerable<Distribucion_Fondo_UGI> GetDistribucion_Fondo_UGIDetails(string cd_numeroresolucion)
        {
            return Get(c=>c.numeroresolucion==cd_numeroresolucion);
        }

        public bool InsertDistribucion_Fondo_UGI(Distribucion_Fondo_UGI distribucion_Fondo_UGI)
        {
            Add(distribucion_Fondo_UGI);
            return true;
        }

        public bool UpdateDistribucion_Fondo_UGI(Distribucion_Fondo_UGI distribucion_Fondo_UGI)
        {
            Update(distribucion_Fondo_UGI);
            return true;
        }
    }
}