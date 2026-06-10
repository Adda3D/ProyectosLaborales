using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IDecVie_RadicadorTecRepository
    {
        IEnumerable<DecVie_RadicadorTec> GetAllDecVie_RadicadorTec();
        DecVie_RadicadorTec GetDecVie_RadicadorTecDetails(int id_decvieradicadortec);
        DecVie_RadicadorTec GetDecVie_RadicadorTecNumero(string cd_numradicadortec);
        bool InsertDecVie_RadicadorTec(DecVie_RadicadorTec decVie_RadicadorTec);
        DecVie_RadicadorTec InsertDecVie_RadicadorTec_Data(DecVie_RadicadorTec decVie_RadicadorTec);
        bool UpdateDecVie_RadicadorTec(DecVie_RadicadorTec decVie_RadicadorTec);
        DecVie_RadicadorTec UpdateDecVie_RadicadorTec_Data(DecVie_RadicadorTec decVie_RadicadorTec);
        bool DeleteDecVie_RadicadorTec(int id_decvieradicadortec);
        DataTableAdapter<DecVie_RadicadorTec> GetDataTableDecVie_RadicadorTec(DataTableRequest model);
        //DataTableAdapter<DecVie_RadicadorTecDTO> GetDataTableDecVie_RadicadorTecPrueba(DataTableRequest model);
        DataTableAdapter<DecVie_RadicadorTecDTO> GetDataTableDecVie_RadicadorTecPrueba(DataTableRequest model, int? filtroFuncionario);

        DecVie_RadicadorTec GetRadicadorTecWithRelations(int id_decvieradicadortec);


    }
} 