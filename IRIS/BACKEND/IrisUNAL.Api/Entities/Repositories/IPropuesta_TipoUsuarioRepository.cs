using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_TipoUsuarioRepository
    {
        IEnumerable<Propuesta_TipoUsuario> GetAllPropuesta_TipoUsuario();
        Propuesta_TipoUsuario GetPropuesta_TipoUsuarioDetails(int id_propuestatipousuario);
        IEnumerable<Propuesta_TipoUsuario> GetPropuesta_TipoUsuarioNombre(string cd_nmpropuestatipousuario);
        bool InsertPropuesta_TipoUsuario(Propuesta_TipoUsuario propuesta_TipoUsuario);
        bool UpdatePropuesta_TipoUsuario(Propuesta_TipoUsuario propuesta_TipoUsuario);
        bool DeletePropuesta_TipoUsuario(int id_propuestatipousuario);
        DataTableAdapter<Propuesta_TipoUsuario> GetDataTablePropuesta_TipoUsuario(DataTableRequest model);
    }
}
