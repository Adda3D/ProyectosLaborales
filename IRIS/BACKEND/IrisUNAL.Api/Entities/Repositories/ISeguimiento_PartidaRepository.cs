using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimiento_PartidaRepository
    {
        IEnumerable<Seguimiento_Partida> GetAllSeguimiento_Partida();
        Seguimiento_Partida GetSeguimiento_PartidaDetails(int id_partida);
        IEnumerable<Seguimiento_Partida> GetSeguimiento_PartidaCodigo(string cd_codigointernopartida);
        bool InsertSeguimiento_Partida(Seguimiento_Partida seguimiento_Partida);
        bool UpdateSeguimiento_Partida(Seguimiento_Partida seguimiento_Partida);
        bool DeleteSeguimiento_Partida(int id_partida);
    }
}
