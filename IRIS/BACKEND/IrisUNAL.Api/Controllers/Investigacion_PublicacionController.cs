using IrisUNAL.Api.Entities.Repositories;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IrisUNAL.Api.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class Investigacion_PublicacionController : BaseController<Investigacion_Publicacion>
    {
        private readonly IInvestigacion_PublicacionRepository _investigacion_PublicacionRepository;
        public Investigacion_PublicacionController(IInvestigacion_PublicacionRepository investigacion_PublicacionRepository)
        {
            _investigacion_PublicacionRepository = investigacion_PublicacionRepository;
        }
        readonly IInvestigacion_PublicacionRepository investigacion_PublicacionRepository = new Investigacion_PublicacionRepository();
        public Investigacion_PublicacionController()
        {
            _investigacion_PublicacionRepository = investigacion_PublicacionRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllInvestigacion_Publicacion()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_PublicacionRepository.GetAllInvestigacion_Publicacion();

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
        public IHttpActionResult GetInvestigacion_PublicacionDetails(int id_invpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_PublicacionRepository.GetInvestigacion_PublicacionDetails(id_invpublicacion);

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
        public IHttpActionResult GetInvestigacion_PublicacionCodigo(string cd_codigohermes)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _investigacion_PublicacionRepository.GetInvestigacion_PublicacionCodigo(cd_codigohermes);

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
        public IHttpActionResult InsertInvestigacion_Publicacion([FromBody] Investigacion_Publicacion investigacion_Publicacion)
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

                var created = _investigacion_PublicacionRepository.InsertInvestigacion_Publicacion(investigacion_Publicacion);

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
        public IHttpActionResult UpdateInvestigacion_Publicacion([FromBody] Investigacion_Publicacion investigacion_Publicacion)
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

                var created = _investigacion_PublicacionRepository.UpdateInvestigacion_Publicacion(investigacion_Publicacion);

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
        public IHttpActionResult DeleteInvestigacion_Publicacion(int id_invpublicacion)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _investigacion_PublicacionRepository.DeleteInvestigacion_Publicacion(id_invpublicacion);

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
