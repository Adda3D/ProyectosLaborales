using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ITipo_DocumentoRepository
    {
        IEnumerable<Tipo_Documento> GetAllTipo_Documento();
        Tipo_Documento GetTipo_DocumentoDetails(int id_tipodocumento);
        IEnumerable<Tipo_Documento> GetTipo_DocumentoDetails(string cd_nmtipodoc);
        bool InsertTipo_Documento(Tipo_Documento tipo_Documento);
        bool UpdateTipo_Documento(Tipo_Documento tipo_Documento);
        bool DeleteTipo_Documento(int id_tipodocumento);
    }
}
