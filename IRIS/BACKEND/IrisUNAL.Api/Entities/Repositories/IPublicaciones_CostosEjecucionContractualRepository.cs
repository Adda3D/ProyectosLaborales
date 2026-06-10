using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_CostosEjecucionContractualRepository
    {
        IEnumerable<Publicaciones_CostosEjecucionContractual> GetAllPublicaciones_CostosEjecucionContractual();
        Publicaciones_CostosEjecucionContractual GetPublicaciones_CostosEjecucionContractualDetails(int id_ejecucion);
        IEnumerable<Publicaciones_CostosEjecucionContractual> GetPublicaciones_CostosEjecucionContractualOrden(string cd_orpa);
        bool InsertPublicaciones_CostosEjecucionContractual(Publicaciones_CostosEjecucionContractual publicaciones_CostosEjecucionContractual);
        bool UpdatePublicaciones_CostosEjecucionContractual(Publicaciones_CostosEjecucionContractual publicaciones_CostosEjecucionContractual);
        bool DeletePublicaciones_CostosEjecucionContractual(int id_ejecucion);
    }
}
