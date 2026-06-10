using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_ControlFinancieroGastosRepository : SuperType<DecVie_ControlFinancieroGastos>, IDecVie_ControlFinancieroGastosRepository
    {
        private ApplicationDbContext _context;

        public DecVie_ControlFinancieroGastosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_ControlFinancieroGastosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_ControlFinancieroGastos(int id_gastos)
        {
            Delete(id_gastos);
            return true;
        }

        public IEnumerable<DecVie_ControlFinancieroGastos> GetAllDecVie_ControlFinancieroGastos()
        {
            return Get();
        }

        public DecVie_ControlFinancieroGastos GetDecVie_ControlFinancieroGastosDetails(int id_gastos)
        {
            return Get(id_gastos);
        }

        public bool InsertDecVie_ControlFinancieroGastos(DecVie_ControlFinancieroGastos decVie_ControlFinancieroGastos)
        {
            Add(decVie_ControlFinancieroGastos);
            return true;
        }

        public bool UpdateDecVie_ControlFinancieroGastos(DecVie_ControlFinancieroGastos decVie_ControlFinancieroGastos)
        {
            Update(decVie_ControlFinancieroGastos);
            return true;
        }
    }
}