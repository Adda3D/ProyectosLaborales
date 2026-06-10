using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_CicloFinancieroPostProgramRepository
    {
        IEnumerable<DecVie_CicloFinancieroPostProgram> GetAllDecVie_CicloFinancieroPostProgram();
        DecVie_CicloFinancieroPostProgram GetDecVie_CicloFinancieroPostProgramDetails(int id_postprogram);        
        bool InsertDecVie_CicloFinancieroPostProgram(DecVie_CicloFinancieroPostProgram decVie_CicloFinancieroPostProgram);
        bool UpdateDecVie_CicloFinancieroPostProgram(DecVie_CicloFinancieroPostProgram decVie_CicloFinancieroPostProgram);
        bool DeleteDecVie_CicloFinancieroPostProgram(int id_postprogram);
        DataTableAdapter<DecVie_CicloFinancieroPostProgram> GetDataTableDecVie_CicloFinancieroPostProgram(DataTableRequest model);
        DataTableAdapter<DecVie_CicloFinancieroPostProgram> GetDataTableDecVie_CicloFinancieroPostProgramByCiclo( int id_ciclofinanciero, DataTableRequest model);
        bool UpdateDecVie_CicloFinancieroPostProgramBogota(DecVie_CicloFinancieroPostProgramBogotaDTO decVie_CicloFinancieroPostProgrambogota);
        bool UpdateDecVie_CicloFinancieroPostProgramConvenio(DecVie_CicloFinancieroPostProgramConvenioDTO decVie_CicloFinancieroPostProgramConvenio);
        bool UpdateDecVie_CicloFinancieroPostProgramFacultad(DecVie_CicloFinancieroPostProgramFacultadDTO decVie_CicloFinancieroPostProgramFacultad);
        bool UpdateDecVie_CicloFinancieroPostProgramUAdministrativa(DecVie_CicloFinancieroPostProgramUAdministrativaDTO decVie_CicloFinancieroPostProgramUAdministrativa);        
    }
}
