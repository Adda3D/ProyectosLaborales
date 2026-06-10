using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EvalGeneradaRepository
    {
        IEnumerable<Publicaciones_EvalGenerada> GetAllPublicaciones_EvalGenerada();
        Publicaciones_EvalGenerada GetPublicaciones_EvalGeneradaDetails(int id_evalgenerada);
        Publicaciones_EvalGenerada GetPublicaciones_EvalGeneradaNombre(string cd_conevalgenerada);
        bool InsertPublicaciones_EvalGenerada(Publicaciones_EvalGenerada publicaciones_EvalGenerada);
        bool UpdatePublicaciones_EvalGenerada(Publicaciones_EvalGenerada publicaciones_EvalGenerada);
        bool DeletePublicaciones_EvalGenerada(int id_evalgenerada);
        DataTableAdapter<Publicaciones_EvalGenerada> GetDataTablePublicaciones_EvalGenerada(DataTableRequest model);
    }
}
