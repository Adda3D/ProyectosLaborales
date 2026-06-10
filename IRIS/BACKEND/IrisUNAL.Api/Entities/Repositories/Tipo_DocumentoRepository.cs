using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Tipo_DocumentoRepository : SuperType<Tipo_Documento>, ITipo_DocumentoRepository
    {
        private ApplicationDbContext _context;

        public Tipo_DocumentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tipo_DocumentoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteTipo_Documento(int id_tipodocumento)
        {
            Delete(id_tipodocumento);

            return true;
        }

        public IEnumerable<Tipo_Documento> GetAllTipo_Documento()
        {
            return Get();
        }

        public Tipo_Documento GetTipo_DocumentoDetails(int id_tipodocumento)
        {
            return Get(id_tipodocumento);
        }

        public IEnumerable<Tipo_Documento> GetTipo_DocumentoDetails(string cd_nmtipodoc)
        {
            return Get(c => c.nmtipodoc == cd_nmtipodoc);            
        }

        public bool InsertTipo_Documento(Tipo_Documento tipo_Documento)
        {
            Add(tipo_Documento);

            return true;
        }

        public bool UpdateTipo_Documento(Tipo_Documento tipo_Documento)
        {
            Update(tipo_Documento);
            return true;            
        }
    }
}