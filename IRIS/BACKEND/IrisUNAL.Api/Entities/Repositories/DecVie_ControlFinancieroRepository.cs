using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_ControlFinancieroRepository : SuperType<DecVie_ControlFinanciero>, IDecVie_ControlFinancieroRepository
    {
        private ApplicationDbContext _context;

        public DecVie_ControlFinancieroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_ControlFinancieroRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_ControlFinanciero(int id_controlfinanciero)
        {
            Delete(id_controlfinanciero);
            return true;
        }

        public IEnumerable<DecVie_ControlFinanciero> GetAllDecVie_ControlFinanciero()
        {
            return Get();
        }

        public DecVie_ControlFinanciero GetDecVie_ControlFinancieroDetails(int id_controlfinanciero)
        {
            return Get(id_controlfinanciero);
        }

        public IEnumerable<DecVie_ControlFinanciero> GetDecVie_ControlFinancieroNombre(string cd_nmpresupuesto)
        {
            return Get(c => c.nmpresupuesto == cd_nmpresupuesto);
        }

        public bool InsertDecVie_ControlFinanciero(DecVie_ControlFinanciero decVie_ControlFinanciero)
        {
            Add(decVie_ControlFinanciero);
            return true;
        }

        public bool UpdateDecVie_ControlFinanciero(DecVie_ControlFinanciero decVie_ControlFinanciero)
        {
            Update(decVie_ControlFinanciero);
            return true;
        }
    }
}