using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_SuscripcionGarantiaRepository
    {
        IEnumerable<Propuesta_SuscripcionGarantia> GetAllPropuesta_SuscripcionGarantia();
        Propuesta_SuscripcionGarantia GetPropuesta_SuscripcionGarantiaDetails(int id_suscripciongarantia);
        Propuesta_SuscripcionGarantia GetPropuesta_SuscripcionGarantiaPoliza(string cd_numeropoliza);
        Propuesta_SuscripcionGarantia GetPropuesta_SuscripcionGarantiaByPropuesta(int id_propuesta);
        bool InsertPropuesta_SuscripcionGarantia(Propuesta_SuscripcionGarantia propuesta_SuscripcionGarantia);
        bool UpdatePropuesta_SuscripcionGarantia(Propuesta_SuscripcionGarantia propuesta_SuscripcionGarantia);
        bool DeletePropuesta_SuscripcionGarantia(int id_suscripciongarantia);

    }
}
