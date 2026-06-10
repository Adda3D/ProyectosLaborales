using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DivulgacionHerramientaRepository
    {
        IEnumerable<Publicaciones_DivulgacionHerramienta> GetAllPublicaciones_DivulgacionHerramienta();
        Publicaciones_DivulgacionHerramienta GetPublicaciones_DivulgacionHerramientaDetails(int id_herramienta);        
        bool InsertPublicaciones_DivulgacionHerramienta(Publicaciones_DivulgacionHerramienta publicaciones_DivulgacionHerramienta);
        bool UpdatePublicaciones_DivulgacionHerramienta(Publicaciones_DivulgacionHerramienta publicaciones_DivulgacionHerramienta);
        bool DeletePublicaciones_DivulgacionHerramienta(int id_herramienta);
        DataTableAdapter<Publicaciones_DivulgacionHerramienta> GetDataTablePublicaciones_DivulgacionHerramientaByPublicacionTipo(int id_crearpublicacion, int id_tipomedio, DataTableRequest model);
    }
}
