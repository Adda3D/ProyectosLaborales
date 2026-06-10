using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_AlcanceSolicitudRepository
    {
        IEnumerable<DecVie_AlcanceSolicitud> GetAllDecVie_AlcanceSolicitud();
        DecVie_AlcanceSolicitud GetDecVie_AlcanceSolicitudDetails(int id_alcancesolicitud);
        DecVie_AlcanceSolicitud GetDecVie_AlcanceSolicitudNombre(string cd_nmalcancesolicitud);
        bool InsertDecVie_AlcanceSolicitud(DecVie_AlcanceSolicitud decVie_AlcanceSolicitud);
        bool UpdateDecVie_AlcanceSolicitud(DecVie_AlcanceSolicitud decVie_AlcanceSolicitud);
        bool DeleteDecVie_AlcanceSolicitud(int id_alcancesolicitud);
        DataTableAdapter<DecVie_AlcanceSolicitud> GetDataTableDecVie_AlcanceSolicitud(DataTableRequest model);
    }
}
