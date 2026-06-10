using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EstadoConceptoRepository
    {
        IEnumerable<Publicaciones_EstadoConcepto> GetAllPublicaciones_EstadoConcepto();
        Publicaciones_EstadoConcepto GetPublicaciones_EstadoConceptoDetails(int id_estadoconcepto);
        Publicaciones_EstadoConcepto GetPublicaciones_EstadoConceptoNombre(string cd_nmestadoconcepto);
        bool InsertPublicaciones_EstadoConcepto(Publicaciones_EstadoConcepto publicaciones_EstadoConcepto);
        bool UpdatePublicaciones_EstadoConcepto(Publicaciones_EstadoConcepto publicaciones_EstadoConcepto);
        bool DeletePublicaciones_EstadoConcepto(int id_estadoconcepto);
        DataTableAdapter<Publicaciones_EstadoConcepto> GetDataTablePublicaciones_EstadoConcepto(DataTableRequest model);
    }
}
