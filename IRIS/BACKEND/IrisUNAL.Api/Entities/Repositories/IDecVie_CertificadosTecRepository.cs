using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System.Collections.Generic;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_CertificadosTecRepository
    {
        IEnumerable<DecVie_CertificadosTec> GetAllDecVie_CertificadosTec();
        DecVie_CertificadosTec GetDecVie_CertificadosTecDetails(int id_decviecertificadostec);
        DecVie_CertificadosTec GetDecVie_CertificadosTecNumero(string cd_numcertificadotec);
        bool InsertDecVie_CertificadosTec(DecVie_CertificadosTec certificadosTec);
        DecVie_CertificadosTec InsertDecVie_CertificadosTec_Data(DecVie_CertificadosTec certificadosTec);
        bool UpdateDecVie_CertificadosTec(DecVie_CertificadosTec certificadosTec);        
        DecVie_CertificadosTec UpdateDecVie_CertificadosTec_Data(DecVie_CertificadosTec certificadosTec);
        bool DeleteDecVie_CertificadosTec(int id_decviecertificadostec);
        DataTableAdapter<DecVie_CertificadosTec> GetDataTableDecVie_CertificadosTec(DataTableRequest model);
        DecVie_CertificadosTec GetCertificadosTecWithRelations(int id_decviecertificadostec);
    }
}
