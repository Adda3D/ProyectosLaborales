using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IInvestigacion_CrearGrupoRepository
    {
        IEnumerable<Investigacion_CrearGrupo> GetAllInvestigacion_CrearGrupo();
        Investigacion_CrearGrupo GetInvestigacion_CrearGrupoDetails(int id_creargrupo);
        Investigacion_CrearGrupo GetInvestigacion_CrearGrupoCodigo(string codigohermes);
        bool InsertInvestigacion_CrearGrupo(Investigacion_CrearGrupo investigacion_CrearGrupo);
        bool UpdateInvestigacion_CrearGrupo(Investigacion_CrearGrupo investigacion_CrearGrupo);
        bool DeleteInvestigacion_CrearGrupo(int id_creargrupo);
        DataTableAdapter<Investigacion_CrearGrupo> GetDataTableInvestigacion_CrearGrupo(DataTableRequest model);
    }
}
