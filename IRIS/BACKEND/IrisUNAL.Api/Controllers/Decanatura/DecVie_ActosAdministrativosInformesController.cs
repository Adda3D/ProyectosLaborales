using IrisUNAL.Api.Entities.Repositories.Decanatura;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DecVie_ActosAdministrativosInformesController : BaseController<DecVie_ActosAdministrativos>
    {
        private readonly DecVie_ActosAdministrativosInformesRepository _decVie_ActosAdministrativosInformesRepository;
        public DecVie_ActosAdministrativosInformesController(DecVie_ActosAdministrativosInformesRepository decVie_ActosAdministrativosInformesRepository)
        {
            _decVie_ActosAdministrativosInformesRepository = decVie_ActosAdministrativosInformesRepository;
        }
        readonly DecVie_ActosAdministrativosInformesRepository decVie_ActosAdministrativosInformesRepository = new DecVie_ActosAdministrativosInformesRepository();
        public DecVie_ActosAdministrativosInformesController()
        {
            _decVie_ActosAdministrativosInformesRepository = decVie_ActosAdministrativosInformesRepository;
        }

        [HttpGet]
        public IHttpActionResult GetDataTableInformeDecVie_ActosAdministrativos(int idtipoinforme, DateTime fechainicial, DateTime fechafinal)
        {
            DataTableAdapter<InformeTipoCantidadDTO> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = _decVie_ActosAdministrativosInformesRepository.GetDataTableInformeDecVie_ActosAdministrativos(idtipoinforme, fechainicial, fechafinal, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetInformeDecVie_ActosAdministrativos(int idtipoinforme, DateTime fechainicial, DateTime fechafinal)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _decVie_ActosAdministrativosInformesRepository.GetInformeDecVie_ActosAdministrativos(idtipoinforme, fechainicial, fechafinal);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }



    }
}
