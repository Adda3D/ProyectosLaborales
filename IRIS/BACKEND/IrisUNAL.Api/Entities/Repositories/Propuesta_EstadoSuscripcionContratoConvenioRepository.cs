using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Propuesta_EstadoSuscripcionContratoConvenioRepository : SuperType<Propuesta_EstadoSuscripcionContratoConvenio>, IPropuesta_EstadoSuscripcionContratoConvenioRepository
    {
        private ApplicationDbContext _context;

        public Propuesta_EstadoSuscripcionContratoConvenioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Propuesta_EstadoSuscripcionContratoConvenioRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePropuesta_EstadoSuscripcionContratoConvenio(int id_estadosuscripcioncontratoconvenio)
        {
            Delete(id_estadosuscripcioncontratoconvenio);
            return true;
        }

        public IEnumerable<Propuesta_EstadoSuscripcionContratoConvenio> GetAllPropuesta_EstadoSuscripcionContratoConvenio()
        {
            return Get();
        }

        public Propuesta_EstadoSuscripcionContratoConvenio GetPropuesta_EstadoSuscripcionContratoConvenioDetails(int id_estadosuscripcioncontratoconvenio)
        {
            return Get(id_estadosuscripcioncontratoconvenio);
        }

        public IEnumerable<Propuesta_EstadoSuscripcionContratoConvenio> GetPropuesta_EstadoSuscripcionContratoConvenioDetails(string cd_nmestadosuscripcioncontratoconvenio)
        {
            return Get(c=>c.nmestadosuscripcioncontratoconvenio==cd_nmestadosuscripcioncontratoconvenio);
        }

        public bool InsertPropuesta_EstadoSuscripcionContratoConvenio(Propuesta_EstadoSuscripcionContratoConvenio propuesta_EstadoSuscripcionContratoConvenio)
        {
            Add(propuesta_EstadoSuscripcionContratoConvenio);
            return true;
        }

        public bool UpdatePropuesta_EstadoSuscripcionContratoConvenio(Propuesta_EstadoSuscripcionContratoConvenio propuesta_EstadoSuscripcionContratoConvenio)
        {
            Update(propuesta_EstadoSuscripcionContratoConvenio);
            return true;
        }
    }
}