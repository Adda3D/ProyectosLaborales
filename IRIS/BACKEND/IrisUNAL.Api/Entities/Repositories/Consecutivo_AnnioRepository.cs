using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Consecutivo_AnnioRepository : SuperType<Consecutivo_Annio>, IConsecutivo_AnnioRepository
    {
        public string GetConsecutivo_Annio(int id_prefijoconsecutivo, DateTime fecha)
        {
            int consecutivoretorna = 0;
            var annioconsecutivo = fecha.Year.ToString();
            string prefijo = "";
            Consecutivo_Annio nuevoconsecutivo = new Consecutivo_Annio();

            var registroconsecutivo = Get(c => c.id_prefijoconsecutivo == id_prefijoconsecutivo && c.annio == annioconsecutivo).FirstOrDefault();

            if (registroconsecutivo == null)
            {
                nuevoconsecutivo.id_prefijoconsecutivo = id_prefijoconsecutivo;
                nuevoconsecutivo.annio = annioconsecutivo;
                nuevoconsecutivo.consecutivo = 1;
                consecutivoretorna = 1;

                Add(nuevoconsecutivo);
            }
            else
            {
                consecutivoretorna = registroconsecutivo.consecutivo + 1;
                registroconsecutivo.consecutivo = consecutivoretorna; ;

                Update(registroconsecutivo);
            }

            //TRAER EL PREFIJO DEL CONSECUTIVO
            using (Correspondencia_PrefijoConsecutivoRepository objprefijo = new Correspondencia_PrefijoConsecutivoRepository())
            {
                var datosprefijo = objprefijo.Get(id_prefijoconsecutivo);
                prefijo = datosprefijo.prefijo;
            }

            string sconsecutivoretorna = prefijo + consecutivoretorna.ToString().PadLeft(4, '0') + "/" + annioconsecutivo;

            return sconsecutivoretorna;
        }

        public bool InsertConsecutivo_Annio(Consecutivo_Annio consecutivo_Annio)
        {
            Add(consecutivo_Annio);
            return true;
        }

        public bool UpdateConsecutivo_Annio(Consecutivo_Annio consecutivo_Annio)
        {
            Update(consecutivo_Annio);
            return true;
        }

    }
}