using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_CostosEjecucionContractualRepository : SuperType<Publicaciones_CostosEjecucionContractual>, IPublicaciones_CostosEjecucionContractualRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_CostosEjecucionContractualRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_CostosEjecucionContractualRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_CostosEjecucionContractual(int id_ejecucion)
        {
            Delete(id_ejecucion);
            return true;
        }

        public IEnumerable<Publicaciones_CostosEjecucionContractual> GetAllPublicaciones_CostosEjecucionContractual()
        {
            return Get();
        }

        public Publicaciones_CostosEjecucionContractual GetPublicaciones_CostosEjecucionContractualDetails(int id_ejecucion)
        {
            return Get(id_ejecucion);
        }

        public IEnumerable<Publicaciones_CostosEjecucionContractual> GetPublicaciones_CostosEjecucionContractualOrden(string cd_orpa)
        {
            return Get(c => c.orpa == cd_orpa);
        }

        public bool InsertPublicaciones_CostosEjecucionContractual(Publicaciones_CostosEjecucionContractual publicaciones_CostosEjecucionContractual)
        {
            Add(publicaciones_CostosEjecucionContractual);
            return true;
        }

        public bool UpdatePublicaciones_CostosEjecucionContractual(Publicaciones_CostosEjecucionContractual publicaciones_CostosEjecucionContractual)
        {
            Update(publicaciones_CostosEjecucionContractual);
            return true;
        }
    }
}