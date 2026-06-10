using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_ControlFinancieroTipoOperativoRepository
    {
        IEnumerable<DecVie_ControlFinancieroTipoOperativo> GetAllDecVie_ControlFinancieroTipoOperativo();
        DecVie_ControlFinancieroTipoOperativo GetDecVie_ControlFinancieroTipoOperativoDetails(int id_tipooperativo);
        DecVie_ControlFinancieroTipoOperativo GetDecVie_ControlFinancieroTipoOperativoNombre(string cd_nmtipooperativo);
        bool InsertDecVie_ControlFinancieroTipoOperativo(DecVie_ControlFinancieroTipoOperativo decVie_ControlFinancieroTipoOperativo);
        bool UpdateDecVie_ControlFinancieroTipoOperativo(DecVie_ControlFinancieroTipoOperativo decVie_ControlFinancieroTipoOperativo);
        bool DeleteDecVie_ControlFinancieroTipoOperativo(int id_tipooperativo);
        DataTableAdapter<DecVie_ControlFinancieroTipoOperativo> GetDataTableDecVie_ControlFinancieroTipoOperativo(DataTableRequest model);
    }
}
