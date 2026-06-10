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
    public interface IPublicaciones_CrearPublicacionRepository
    {
        IEnumerable<Publicaciones_CrearPublicacion> GetAllPublicaciones_CrearPublicacion();
        Publicaciones_CrearPublicacion GetPublicaciones_CrearPublicacionDetails(int id_crearpublicacion);
        Publicaciones_CrearPublicacion GetPublicaciones_CrearPublicacionCodigo(string cd_id_kardex);
        int? GetPublicaciones_CrearPublicacionEvaluacionInicial(int id_crearpublicacion);
        bool InsertPublicaciones_CrearPublicacion(Publicaciones_CrearPublicacion publicaciones_CrearPublicacion);
        bool UpdatePublicaciones_CrearPublicacionEvaluacion(int id_crearpublicacion, int id_evaluacioninicial);
        bool UpdatePublicaciones_CrearPublicacion(Publicaciones_CrearPublicacion publicaciones_CrearPublicacion);
        bool DeletePublicaciones_CrearPublicacion(int id_crearpublicacion);
        DataTableAdapter<Publicaciones_CrearPublicacion> GetDataTablePublicaciones(DataTableRequest model);
        PublicacionTotalAportesDTO GetPublicaciones_CrearPublicacionAportes(int id_crearpublicacion);
        bool UpdatePublicaciones_CrearPublicacionAportes(PublicacionTotalAportesDTO proyecto_aportes);
        string ExcelFinancieroPublicaciones_CrearPublicacion(int id_crearpublicacion);

    }
}
