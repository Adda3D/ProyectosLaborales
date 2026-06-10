using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPropuesta_AvalInternoRepository
    {
        IEnumerable<Propuesta_AvalInterno> GetAllPropuesta_AvalInterno();
        Propuesta_AvalInterno GetPropuesta_AvalInternoDetails(int id_avalinterno);
        IEnumerable<Propuesta_AvalInterno> GetPropuesta_AvalInternoDetails(string cd_avalinterno);
        bool InsertPropuesta_AvalInterno(Propuesta_AvalInterno propuesta_AvalInterno);
        bool UpdatePropuesta_AvalInterno(Propuesta_AvalInterno propuesta_AvalInterno);
        bool DeletePropuesta_AvalInterno(int id_avalinterno);
    }
}
