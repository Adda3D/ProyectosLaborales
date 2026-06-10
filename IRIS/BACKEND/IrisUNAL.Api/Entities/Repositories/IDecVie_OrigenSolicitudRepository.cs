using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_OrigenSolicitudRepository
    {
        IEnumerable<DecVie_OrigenSolicitud> GetAllDecVie_OrigenSolicitud();
        DecVie_OrigenSolicitud GetDecVie_OrigenSolicitudDetails(int id_origensolicitud);
        DecVie_OrigenSolicitud GetDecVie_OrigenSolicitudNombre(string cd_nmorigensolicitud);
        bool InsertDecVie_OrigenSolicitud(DecVie_OrigenSolicitud decVie_OrigenSolicitud);
        bool UpdateDecVie_OrigenSolicitud(DecVie_OrigenSolicitud decVie_OrigenSolicitud);
        bool DeleteDecVie_OrigenSolicitud(int id_origensolicitud);
        DataTableAdapter<DecVie_OrigenSolicitud> GetDataTableDecVie_OrigenSolicitud(DataTableRequest model);
    }
}
