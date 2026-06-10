using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Investigacion_LineaRepository : SuperType<Investigacion_Linea>, IInvestigacion_LineaRepository
    {
        private ApplicationDbContext _context;

        public Investigacion_LineaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_LineaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteInvestigacion_Linea(int id_linea)
        {
            Delete(id_linea);
            return true;
        }

        public IEnumerable<Investigacion_Linea> GetAllInvestigacion_Linea()
        {
            return Get();
        }

        public IEnumerable<Investigacion_Linea> GetInvestigacion_LineaCodigo(string cd_codigohermes)
        {
            return Get(c => c.codigohermes == cd_codigohermes);
        }

        public Investigacion_Linea GetInvestigacion_LineaDetails(int id_linea)
        {
            return Get(id_linea);
        }

        public bool InsertInvestigacion_Linea(Investigacion_Linea investigacion_Linea)
        {
            Add(investigacion_Linea);
            return true;
        }

        public bool UpdateInvestigacion_Linea(Investigacion_Linea investigacion_Linea)
        {
            Update(investigacion_Linea);
            return true;
        }
    }
}