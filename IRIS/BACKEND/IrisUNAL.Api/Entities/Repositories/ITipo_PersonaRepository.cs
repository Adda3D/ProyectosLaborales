using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ITipo_PersonaRepository
    {
        IEnumerable<Tipo_Persona> GetAllTipo_Persona();
        Tipo_Persona GetTipo_PersonaDetails(int id_tipopersona);
        Tipo_Persona GetTipo_PersonaNombre(string cd_nmtipoper);
        bool InsertTipo_Persona(Tipo_Persona tipo_Persona);
        bool UpdateTipo_Persona(Tipo_Persona tipo_Persona);
        bool DeleteTipo_Persona(int id_tipopersona);
        DataTableAdapter<Tipo_Persona> GetDataTableTipo_Persona(DataTableRequest model);
    }
}
