using IrisUNAL.Api.Entities.Repositories;   
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
    public class DecVie_CertificadosTecController : BaseController<DecVie_CertificadosTec>
    {
        private readonly IDecVie_CertificadosTecRepository _decVie_CertificadosTecRepository;

        public DecVie_CertificadosTecController(IDecVie_CertificadosTecRepository decVie_CertificadosTecRepository)
        {
            _decVie_CertificadosTecRepository = decVie_CertificadosTecRepository;
        }

        readonly IDecVie_CertificadosTecRepository decVie_CertificadosTecRepository = new DecVie_CertificadosTecRepository();

        public DecVie_CertificadosTecController()
        {
            _decVie_CertificadosTecRepository = decVie_CertificadosTecRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllDecVie_CertificadosTec()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_CertificadosTecRepository.GetAllDecVie_CertificadosTec();

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

        [HttpGet]
        public IHttpActionResult GetDecVie_CertificadosTecDetails(int id_decviecertificadostec)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_CertificadosTecRepository.GetCertificadosTecWithRelations(id_decviecertificadostec);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "CertificadosTec inexistente";
                }

                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetDecVie_CertificadosTecNumero(string cd_numcertificadotec)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_CertificadosTecRepository.GetDecVie_CertificadosTecNumero(cd_numcertificadotec);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Certificado inexistente";
                }

                resultdb.Data = data;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }


        [HttpPost]
        public IHttpActionResult InsertDecVie_RadicadorTec([FromBody] DecVie_CertificadosTec certificadosTec)
        {
            var resultdb = new ResultObject();

            try
            {
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_CertificadosTecRepository.InsertDecVie_CertificadosTec(certificadosTec);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = created;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult InsertDecVie_CertificadosTec_Data([FromBody] DecVie_CertificadosTec decVie_CertificadosTec)
        {
            var resultdb = new ResultObject();

            try
            {
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_CertificadosTecRepository.InsertDecVie_CertificadosTec_Data(decVie_CertificadosTec);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = created;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpPost]
        public IHttpActionResult UpdateDecVie_CertificadosTec([FromBody] DecVie_CertificadosTec certificadosTec)
        {
            var resultdb = new ResultObject();

            try
            {
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var updated = decVie_CertificadosTecRepository.UpdateDecVie_CertificadosTec(certificadosTec);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = updated;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }


        [HttpPost]
        public IHttpActionResult UpdateDecVie_CertificadosTec_Data([FromBody] DecVie_CertificadosTec decVie_CertificadosTec)
        {
            var resultdb = new ResultObject();

            try
            {
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_CertificadosTecRepository.UpdateDecVie_CertificadosTec_Data(decVie_CertificadosTec);

                resultdb.Ok = true;
                resultdb.Message = "";
                resultdb.Data = created;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteDecVie_CertificadosTec(int id_decviecertificadostec)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_CertificadosTecRepository.DeleteDecVie_CertificadosTec(id_decviecertificadostec);

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

        [HttpGet]
        public IHttpActionResult GetDataTableDecVie_CertificadosTec()
        {
            DataTableAdapter<DecVie_CertificadosTec> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_CertificadosTecRepository.GetDataTableDecVie_CertificadosTec(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }
    }
}
