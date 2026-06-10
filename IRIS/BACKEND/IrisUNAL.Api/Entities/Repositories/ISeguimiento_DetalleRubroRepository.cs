using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface ISeguimiento_DetalleRubroRepository
    {
        IEnumerable<Seguimiento_DetalleRubro> GetAllSeguimiento_DetalleRubro();
        Seguimiento_DetalleRubro GetSeguimiento_DetalleRubroDetails(int id_detallerubro);
        IEnumerable<Seguimiento_DetalleRubro> GetSeguimiento_DetalleRubroCodigo(string cd_codigointernorubro);
        bool InsertSeguimiento_DetalleRubro(Seguimiento_DetalleRubro seguimiento_DetalleRubro);
        bool UpdateSeguimiento_DetalleRubro(Seguimiento_DetalleRubro seguimiento_DetalleRubro);
        bool DeleteSeguimiento_DetalleRubro(int id_detallerubro);
    }
}
