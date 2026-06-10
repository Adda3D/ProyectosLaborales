using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Liquidacion_InformeFinalProyRepository : SuperType<Liquidacion_InformeFinalProy>, ILiquidacion_InformeFinalProyRepository
    {
        private ApplicationDbContext _context;

        public Liquidacion_InformeFinalProyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Liquidacion_InformeFinalProyRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteLiquidacion_InformeFinalProy(int id_informefinalproy)
        {
            Delete(id_informefinalproy);
                return true;
        }

        public IEnumerable<Liquidacion_InformeFinalProy> GetAllLiquidacion_InformeFinalProy()
        {
            return Get();
        }

        public Liquidacion_InformeFinalProy GetLiquidacion_InformeFinalProyDetails(int id_informefinalproy)
        {
            return Get(id_informefinalproy);
        }

        public IEnumerable<Liquidacion_InformeFinalProy> GetLiquidacion_InformeFinalProyNombre(string cd_nominformefinalproy)
        {
            return Get(c=>c.nominformefinalproy==cd_nominformefinalproy);
        }

        public bool InsertLiquidacion_InformeFinalProy(Liquidacion_InformeFinalProy liquidacion_InformeFinalProy)
        {
            Add(liquidacion_InformeFinalProy);
            return true;
        }

        public bool UpdateLiquidacion_InformeFinalProy(Liquidacion_InformeFinalProy liquidacion_InformeFinalProy)
        {
            Update(liquidacion_InformeFinalProy);
            return true;
        }
    }
}