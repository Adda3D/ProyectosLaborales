using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimiento_RubroRepository
    {
        IEnumerable<Seguimiento_Rubro> GetAllSeguimiento_Rubro();
        Seguimiento_Rubro GetSeguimiento_RubroDetails(int id_rubro);
        IEnumerable<Seguimiento_Rubro> GetAllSeguimiento_RubroByPartida(int id_partida);
        IEnumerable<Seguimiento_Rubro> GetSeguimiento_RubroCodigo(string cd_codigointernorubro);
        bool InsertSeguimiento_Rubro(Seguimiento_Rubro seguimiento_Rubro);
        bool UpdateSeguimiento_Rubro(Seguimiento_Rubro seguimiento_Rubro);
        bool DeleteSeguimiento_Rubro(int id_rubro);
    }
}
