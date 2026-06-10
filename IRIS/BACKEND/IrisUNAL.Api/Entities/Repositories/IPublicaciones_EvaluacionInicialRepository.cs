using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IPublicaciones_EvaluacionInicialRepository
    {
        IEnumerable<Publicaciones_EvaluacionInicial> GetAllPublicaciones_EvaluacionInicial();
        Publicaciones_EvaluacionInicial GetPublicaciones_EvaluacionInicialDetails(int id_evaluacioninicial);
        Publicaciones_EvaluacionInicial GetPublicaciones_EvaluacionInicialNombre(string cd_nmevalinicial);
        bool InsertPublicaciones_EvaluacionInicial(Publicaciones_EvaluacionInicial publicaciones_EvaluacionInicial);
        bool UpdatePublicaciones_EvaluacionInicial(Publicaciones_EvaluacionInicial publicaciones_EvaluacionInicial);
        bool DeletePublicaciones_EvaluacionInicial(int id_evaluacioninicial);
        DataTableAdapter<Publicaciones_EvaluacionInicial> GetDataTablePublicaciones_EvaluacionInicial(DataTableRequest model);
    }
}
