using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Models
{
    public interface IRolMenuOpcionesRepository
    {
        IEnumerable<RolMenuOpciones> GetAllRolMenuOpciones();
        RolMenuOpciones GetRolMenuOpcionesDetails(int idrolmenuopciones);        
        bool InsertRolMenuOpciones(RolMenuOpciones rolMenuOpciones);
        bool UpdateRolMenuOpciones(RolMenuOpciones rolMenuOpciones);
        bool DeleteRolMenuOpciones(int idrolmenuopciones);
    }
}
