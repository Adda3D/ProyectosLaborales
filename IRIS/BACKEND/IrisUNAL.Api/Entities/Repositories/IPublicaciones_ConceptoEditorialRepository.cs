using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_ConceptoEditorialRepository
    {
        IEnumerable<Publicaciones_ConceptoEditorial> GetAllPublicaciones_ConceptoEditorial();
        Publicaciones_ConceptoEditorial GetPublicaciones_ConceptoEditorialDetails(int id_conceptoeditorial);
        Publicaciones_ConceptoEditorial GetPublicaciones_ConceptoEditorialByPublicacion(int id_crearpublicacion);
        bool InsertPublicaciones_ConceptoEditorial(Publicaciones_ConceptoEditorial publicaciones_ConceptoEditorial);
        bool UpdatePublicaciones_ConceptoEditorial(Publicaciones_ConceptoEditorial publicaciones_ConceptoEditorial);
        bool DeletePublicaciones_ConceptoEditorial(int id_conceptoeditorial);
    }
}
