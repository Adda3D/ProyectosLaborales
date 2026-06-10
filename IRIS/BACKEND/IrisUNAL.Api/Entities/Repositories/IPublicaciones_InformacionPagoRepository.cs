using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_InformacionPagoRepository
    {
        IEnumerable<Publicaciones_InformacionPago> GetAllPublicaciones_InformacionPago();
        Publicaciones_InformacionPago GetPublicaciones_InformacionPagoDetails(int id_informacionpago);
        Publicaciones_InformacionPago GetPublicaciones_InformacionPagoByEvaluador(int id_evaluadores);
        bool InsertPublicaciones_InformacionPago(Publicaciones_InformacionPago publicaciones_InformacionPago);
        bool UpdatePublicaciones_InformacionPago(Publicaciones_InformacionPago publicaciones_InformacionPago);
        bool DeletePublicaciones_InformacionPago(int id_informacionpago);
    }
}
