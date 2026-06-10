using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Propuesta_SuscripcionGarantiaRepository : SuperType<Propuesta_SuscripcionGarantia>, IPropuesta_SuscripcionGarantiaRepository
    {
        public bool DeletePropuesta_SuscripcionGarantia(int id_suscripciongarantia)
        {
            Delete(id_suscripciongarantia);
            return true;
        }

        public IEnumerable<Propuesta_SuscripcionGarantia> GetAllPropuesta_SuscripcionGarantia()
        {
            return Get();
        }

        public Propuesta_SuscripcionGarantia GetPropuesta_SuscripcionGarantiaByPropuesta(int id_propuesta)
        {
            return Get(c => c.id_propuesta == id_propuesta).FirstOrDefault();            
        }

        public Propuesta_SuscripcionGarantia GetPropuesta_SuscripcionGarantiaDetails(int id_suscripciongarantia)
        {
            return Get(id_suscripciongarantia);
        }

        public Propuesta_SuscripcionGarantia GetPropuesta_SuscripcionGarantiaPoliza(string cd_numeropoliza)
        {
            return Get(c=> c.numeropoliza==cd_numeropoliza).FirstOrDefault();
        }

        public bool InsertPropuesta_SuscripcionGarantia(Propuesta_SuscripcionGarantia propuesta_SuscripcionGarantia)
        {
            Add(propuesta_SuscripcionGarantia);
            return true;
        }

        public bool UpdatePropuesta_SuscripcionGarantia(Propuesta_SuscripcionGarantia propuesta_SuscripcionGarantia)
        {
            Update(propuesta_SuscripcionGarantia);
            return true;
        }
    }
}