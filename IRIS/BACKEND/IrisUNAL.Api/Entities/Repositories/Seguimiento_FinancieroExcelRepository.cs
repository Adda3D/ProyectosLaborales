using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Seguimiento_FinancieroExcelRepository : SuperType<Seguimiento_FinancieroExcel>, ISeguimiento_FinancieroExcelRepository
    {
        private ApplicationDbContext _context;

        public Seguimiento_FinancieroExcelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Seguimiento_FinancieroExcelRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteSeguimiento_FinancieroExcel(int id_financieroexcel)
        {
            Delete(id_financieroexcel);
            return true;
        }

        public IEnumerable<Seguimiento_FinancieroExcel> GetAllSeguimiento_FinancieroExcel()
        {
            return Get();
        }

        public IEnumerable<Seguimiento_FinancieroExcel> GetSeguimiento_FinancieroExcelCodigo(string cd_codigoquipu)
        {
            return Get(c => c.codigoquipu == cd_codigoquipu);
        }

        public Seguimiento_FinancieroExcel GetSeguimiento_FinancieroExcelDetails(int id_financieroexcel)
        {
            return Get(id_financieroexcel);
        }

        public bool InsertSeguimiento_FinancieroExcel(Seguimiento_FinancieroExcel seguimiento_FinancieroExcel)
        {
            Add(seguimiento_FinancieroExcel);
            return true;
        }

        public bool UpdateSeguimiento_FinancieroExcel(Seguimiento_FinancieroExcel seguimiento_FinancieroExcel)
        {
            Update(seguimiento_FinancieroExcel);
            return true;
        }
    }
}