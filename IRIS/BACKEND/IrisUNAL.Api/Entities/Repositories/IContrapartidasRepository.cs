using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IContrapartidasRepository
    {
        IEnumerable<Contrapartidas> GetAllContrapartidas();
        Contrapartidas GetContrapartidasDetails(int id_contrapartidas);        
        bool InsertContrapartidas(Contrapartidas contrapartidas);
        bool UpdateContrapartidas(Contrapartidas contrapartidas);
        bool DeleteContrapartidas(int id_contrapartidas);
    }
}
