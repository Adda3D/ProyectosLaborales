using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_DepositoDistribucionParamRepository
    {
        IEnumerable<Publicaciones_DepositoDistribucionParam> GetAllPublicaciones_DepositoDistribucionParam();
        Publicaciones_DepositoDistribucionParam GetPublicaciones_DepositoDistribucionParamDetails(int id_distparam);
        IEnumerable<Publicaciones_DepositoDistribucionParam> GetPublicaciones_DepositoDistribucionParamConsecutivo(string cd_consecutivo);
        bool InsertPublicaciones_DepositoDistribucionParam(Publicaciones_DepositoDistribucionParam publicaciones_DepositoDistribucionParam);
        bool UpdatePublicaciones_DepositoDistribucionParam(Publicaciones_DepositoDistribucionParam publicaciones_DepositoDistribucionParam);
        bool DeletePublicaciones_DepositoDistribucionParam(int id_distparam);
    }
}
