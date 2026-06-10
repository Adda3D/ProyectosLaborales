using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_EstadoSuscripcionContratoConvenioRepository
    {
        IEnumerable<Propuesta_EstadoSuscripcionContratoConvenio> GetAllPropuesta_EstadoSuscripcionContratoConvenio();
        Propuesta_EstadoSuscripcionContratoConvenio GetPropuesta_EstadoSuscripcionContratoConvenioDetails(int id_estadosuscripcioncontratoconvenio);
        IEnumerable<Propuesta_EstadoSuscripcionContratoConvenio> GetPropuesta_EstadoSuscripcionContratoConvenioDetails(string cd_nmestadosuscripcioncontratoconvenio);
        bool InsertPropuesta_EstadoSuscripcionContratoConvenio(Propuesta_EstadoSuscripcionContratoConvenio propuesta_EstadoSuscripcionContratoConvenio);
        bool UpdatePropuesta_EstadoSuscripcionContratoConvenio(Propuesta_EstadoSuscripcionContratoConvenio propuesta_EstadoSuscripcionContratoConvenio);
        bool DeletePropuesta_EstadoSuscripcionContratoConvenio(int id_estadosuscripcioncontratoconvenio);
    }
}
