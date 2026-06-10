using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_SerieDocumentalRepository
    {
        IEnumerable<DecVie_SerieDocumental> GetAllDecVie_SerieDocumental();
        DecVie_SerieDocumental GetDecVie_SerieDocumentalDetails(int id_seriedocumental);
        DecVie_SerieDocumental GetDecVie_SerieDocumentalNombre(string cd_nminstancia);
        bool InsertDecVie_SerieDocumental(DecVie_SerieDocumental decVie_SerieDocumental);
        bool UpdateDecVie_SerieDocumental(DecVie_SerieDocumental decVie_SerieDocumental);
        bool DeleteDecVie_SerieDocumental(int id_seriedocumental);
        DataTableAdapter<DecVie_SerieDocumental> GetDataTableDecVie_SerieDocumental(DataTableRequest model);
    }
}
