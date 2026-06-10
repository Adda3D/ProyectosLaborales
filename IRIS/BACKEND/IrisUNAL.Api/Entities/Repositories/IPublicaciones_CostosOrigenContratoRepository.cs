using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_CostosOrigenContratoRepository
    {
        IEnumerable<Publicaciones_CostosOrigenContrato> GetAllPublicaciones_CostosOrigenContrato();
        Publicaciones_CostosOrigenContrato GetPublicaciones_CostosOrigenContratoDetails(int id_origencontrato);
        IEnumerable<Publicaciones_CostosOrigenContrato> GetPublicaciones_CostosOrigenContratoNombre(string cd_proyecto);
        bool InsertPublicaciones_CostosOrigenContrato(Publicaciones_CostosOrigenContrato publicaciones_CostosOrigenContrato);
        bool UpdatePublicaciones_CostosOrigenContrato(Publicaciones_CostosOrigenContrato publicaciones_CostosOrigenContrato);
        bool DeletePublicaciones_CostosOrigenContrato(int id_origencontrato);
    }
}
