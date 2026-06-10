using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ImpresionEncuadernacionRepository
    {
        IEnumerable<Publicaciones_ImpresionEncuadernacion> GetAllPublicaciones_ImpresionEncuadernacion();
        Publicaciones_ImpresionEncuadernacion GetPublicaciones_ImpresionEncuadernacionDetails(int id_encuadernacion);
        Publicaciones_ImpresionEncuadernacion GetPublicaciones_ImpresionEncuadernacionNombre(string cd_nmencuadernacion);
        bool InsertPublicaciones_ImpresionEncuadernacion(Publicaciones_ImpresionEncuadernacion publicaciones_ImpresionEncuadernacion);
        bool UpdatePublicaciones_ImpresionEncuadernacion(Publicaciones_ImpresionEncuadernacion publicaciones_ImpresionEncuadernacion);
        bool DeletePublicaciones_ImpresionEncuadernacion(int id_encuadernacion);
        DataTableAdapter<Publicaciones_ImpresionEncuadernacion> GetDataTablePublicaciones_ImpresionEncuadernacion(DataTableRequest model);
    }
}
