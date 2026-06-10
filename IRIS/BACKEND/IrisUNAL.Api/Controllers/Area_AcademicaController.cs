using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Area_AcademicaController : BaseController<Area_Academica>
    {
        private readonly IArea_AcademicaRepository _area_AcademicaRepository;
        
        public Area_AcademicaController(IArea_AcademicaRepository area_AcademicaRepository)
        {
            _area_AcademicaRepository = area_AcademicaRepository;
        }

        readonly IArea_AcademicaRepository area_AcademicaRepository = new Area_AcademicaRepository();
        public Area_AcademicaController()
        {
            _area_AcademicaRepository = area_AcademicaRepository;
        }

        [HttpGet]
        public IHttpActionResult GetAllArea_Academica()
        {
            var resultdb = new ResultObject();
            try
            {               
                var data = _area_AcademicaRepository.GetAllArea_Academica();

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
        public IHttpActionResult GetArea_AcademicaDetails(int id_areaacad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _area_AcademicaRepository.GetArea_AcademicaDetails(id_areaacad);

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
        public IHttpActionResult GetArea_AcademicaCodigo(string cd_areaacad)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _area_AcademicaRepository.GetArea_AcademicaDetails(cd_areaacad);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (data.Count() == 0)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Área académica inexistente";
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
        public IHttpActionResult InsertArea_Academica([FromBody] Area_Academica area_Academica)
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

                var created = _area_AcademicaRepository.InsertArea_Academica(area_Academica);

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
        public IHttpActionResult UpdateArea_Academica([FromBody] Area_Academica area_Academica)
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

                var created = _area_AcademicaRepository.UpdateArea_Academica(area_Academica);

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
        public IHttpActionResult DeleteArea_Academica(int id_areaacad)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _area_AcademicaRepository.DeleteArea_Academica(id_areaacad);

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
        public IHttpActionResult GetDatataTableArea()
        {
            DataTableAdapter<Area_Academica> resultado = null;
            DataTableRequest model = new DataTableRequest();
                    
            try
            {
                NameValueCollection dtrequest = HttpUtility.ParseQueryString(Request.RequestUri.Query);

                model = NvcToDataTablesModel(dtrequest);
                
                resultado = _area_AcademicaRepository.GetDataTableArea(model);

                return Return(resultado);
            }
            catch (Exception ex)
            {
                return Return(resultado, ex);
            }
        }


    }
}

