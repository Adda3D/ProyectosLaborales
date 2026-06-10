using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ConceptoRepository
    {
        IEnumerable<Publicaciones_Concepto> GetAllPublicaciones_Concepto();
        Publicaciones_Concepto GetPublicaciones_ConceptoDetails(int id_concepto);
        Publicaciones_Concepto GetPublicaciones_ConceptoNombre(string cd_nmconcepto);
        bool InsertPublicaciones_Concepto(Publicaciones_Concepto publicaciones_Concepto);
        bool UpdatePublicaciones_Concepto(Publicaciones_Concepto publicaciones_Concepto);
        bool DeletePublicaciones_Concepto(int id_concepto);
        DataTableAdapter<Publicaciones_Concepto> GetDataTablePublicaciones_Concepto(DataTableRequest model);
    }
}
