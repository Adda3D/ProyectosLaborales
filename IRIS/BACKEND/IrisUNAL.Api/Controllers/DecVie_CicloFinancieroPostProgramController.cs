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
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class DecVie_CicloFinancieroPostProgramController : BaseController<DecVie_CicloFinancieroPostProgram>
    {
        private readonly IDecVie_CicloFinancieroPostProgramRepository _decVie_CicloFinancieroPostProgramRepository;
        public DecVie_CicloFinancieroPostProgramController(IDecVie_CicloFinancieroPostProgramRepository decVie_CicloFinancieroPostProgramRepository)
        {
            _decVie_CicloFinancieroPostProgramRepository = decVie_CicloFinancieroPostProgramRepository;
        }
        readonly IDecVie_CicloFinancieroPostProgramRepository decVie_CicloFinancieroPostProgramRepository = new DecVie_CicloFinancieroPostProgramRepository();
        public DecVie_CicloFinancieroPostProgramController()
        {
            _decVie_CicloFinancieroPostProgramRepository = decVie_CicloFinancieroPostProgramRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllDecVie_CicloFinancieroPostProgram()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_CicloFinancieroPostProgramRepository.GetAllDecVie_CicloFinancieroPostProgram();

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
        public IHttpActionResult GetDecVie_CicloFinancieroPostProgramDetails(int id_postprogram)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = decVie_CicloFinancieroPostProgramRepository.GetDecVie_CicloFinancieroPostProgramDetails(id_postprogram);

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

        [HttpPost]
        public IHttpActionResult InsertDecVie_CicloFinancieroPostProgram([FromBody] DecVie_CicloFinancieroPostProgram decVie_CicloFinancieroPostProgram)
        {
            var resultdb = new ResultObject();

            try
            {
                //VALIDA BASADO EN LOS DATAANNOTATIONS DEL MODELO
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_CicloFinancieroPostProgramRepository.InsertDecVie_CicloFinancieroPostProgram(decVie_CicloFinancieroPostProgram);

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
        public IHttpActionResult UpdateDecVie_CicloFinancieroPostProgram([FromBody] DecVie_CicloFinancieroPostProgram decVie_CicloFinancieroPostProgram)
        {
            var resultdb = new ResultObject();

            try
            {
                //VALIDA BASADO EN LOS DATAANNOTATIONS DEL MODELO
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_CicloFinancieroPostProgramRepository.UpdateDecVie_CicloFinancieroPostProgram(decVie_CicloFinancieroPostProgram);

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
        public IHttpActionResult UpdateDecVie_CicloFinancieroPostProgramBogota([FromBody] DecVie_CicloFinancieroPostProgramBogotaDTO decVie_CicloFinancieroPostProgram)
        {
            var resultdb = new ResultObject();

            try
            {
                //VALIDA BASADO EN LOS DATAANNOTATIONS DEL MODELO
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_CicloFinancieroPostProgramRepository.UpdateDecVie_CicloFinancieroPostProgramBogota(decVie_CicloFinancieroPostProgram);

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
        public IHttpActionResult UpdateDecVie_CicloFinancieroPostProgramConvenio([FromBody] DecVie_CicloFinancieroPostProgramConvenioDTO decVie_CicloFinancieroPostProgram)
        {
            var resultdb = new ResultObject();

            try
            {
                //VALIDA BASADO EN LOS DATAANNOTATIONS DEL MODELO
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_CicloFinancieroPostProgramRepository.UpdateDecVie_CicloFinancieroPostProgramConvenio(decVie_CicloFinancieroPostProgram);

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
        public IHttpActionResult UpdateDecVie_CicloFinancieroPostProgramFacultad([FromBody] DecVie_CicloFinancieroPostProgramFacultadDTO decVie_CicloFinancieroPostProgram)
        {
            var resultdb = new ResultObject();

            try
            {
                //VALIDA BASADO EN LOS DATAANNOTATIONS DEL MODELO
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_CicloFinancieroPostProgramRepository.UpdateDecVie_CicloFinancieroPostProgramFacultad(decVie_CicloFinancieroPostProgram);

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
        public IHttpActionResult UpdateDecVie_CicloFinancieroPostProgramUAdministrativa([FromBody] DecVie_CicloFinancieroPostProgramUAdministrativaDTO decVie_CicloFinancieroPostProgram)
        {
            var resultdb = new ResultObject();

            try
            {
                //VALIDA BASADO EN LOS DATAANNOTATIONS DEL MODELO
                if (!ModelState.IsValid)
                {
                    resultdb.Ok = false;
                    resultdb.Message = Request.CreateResponse(ModelState).ToString();
                    resultdb.Data = null;
                }

                var created = decVie_CicloFinancieroPostProgramRepository.UpdateDecVie_CicloFinancieroPostProgramUAdministrativa(decVie_CicloFinancieroPostProgram);

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
        public IHttpActionResult DeleteDecVie_CicloFinancieroPostProgram(int id_postprogram)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = decVie_CicloFinancieroPostProgramRepository.DeleteDecVie_CicloFinancieroPostProgram(id_postprogram);

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
        public IHttpActionResult GetDataTableDecVie_CicloFinancieroPostProgram()
        {
            DataTableAdapter<DecVie_CicloFinancieroPostProgram> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_CicloFinancieroPostProgramRepository.GetDataTableDecVie_CicloFinancieroPostProgram(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }

        }
        [HttpGet]
        public IHttpActionResult GetDataTableDecVie_CicloFinancieroPostProgramByCiclo( int id_ciclofinanciero)
        {
            DataTableAdapter<DecVie_CicloFinancieroPostProgram> resultado = null;
            DataTableRequest model = new DataTableRequest();

            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);

                resultado = decVie_CicloFinancieroPostProgramRepository.GetDataTableDecVie_CicloFinancieroPostProgramByCiclo( id_ciclofinanciero, model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }

    }
}
