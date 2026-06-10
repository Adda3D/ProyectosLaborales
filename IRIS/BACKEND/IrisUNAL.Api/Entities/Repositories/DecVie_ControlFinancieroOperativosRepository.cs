using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_ControlFinancieroOperativosRepository : SuperType<DecVie_ControlFinancieroOperativos>, IDecVie_ControlFinancieroOperativosRepository
    {
        private ApplicationDbContext _context;

        public DecVie_ControlFinancieroOperativosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_ControlFinancieroOperativosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_ControlFinancieroOperativos(int id_operativos)
        {
            Delete(id_operativos);
            return true;
        }

        public IEnumerable<DecVie_ControlFinancieroOperativos> GetAllDecVie_ControlFinancieroOperativos()
        {
            return Get();
        }

        public DecVie_ControlFinancieroOperativos GetDecVie_ControlFinancieroOperativosDetails(int id_operativos)
        {
            return Get(id_operativos);
        }

        public bool InsertDecVie_ControlFinancieroOperativos(DecVie_ControlFinancieroOperativos decVie_ControlFinancieroOperativos)
        {
            Add(decVie_ControlFinancieroOperativos);
            return true;
        }

        public bool UpdateDecVie_ControlFinancieroOperativos(DecVie_ControlFinancieroOperativos decVie_ControlFinancieroOperativos)
        {
            Update(decVie_ControlFinancieroOperativos);
            return true;
        }
    }
}