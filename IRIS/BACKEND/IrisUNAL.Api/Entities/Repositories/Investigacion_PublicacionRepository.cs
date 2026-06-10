using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Investigacion_PublicacionRepository : SuperType<Investigacion_Publicacion>, IInvestigacion_PublicacionRepository
    {
        private ApplicationDbContext _context;

        public Investigacion_PublicacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_PublicacionRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteInvestigacion_Publicacion(int id_invpublicacion)
        {
            Delete(id_invpublicacion);
            return true;
        }

        public IEnumerable<Investigacion_Publicacion> GetAllInvestigacion_Publicacion()
        {
            return Get();
        }

        public IEnumerable<Investigacion_Publicacion> GetInvestigacion_PublicacionCodigo(string cd_codigohermes)
        {
            return Get(c => c.codigohermes == cd_codigohermes);
        }

        public Investigacion_Publicacion GetInvestigacion_PublicacionDetails(int id_invpublicacion)
        {
            return Get(id_invpublicacion);
        }

        public bool InsertInvestigacion_Publicacion(Investigacion_Publicacion investigacion_Publicacion)
        {
            Add(investigacion_Publicacion);
            return true;
        }

        public bool UpdateInvestigacion_Publicacion(Investigacion_Publicacion investigacion_Publicacion)
        {
            Update(investigacion_Publicacion);
            return true;
        }
    }
}