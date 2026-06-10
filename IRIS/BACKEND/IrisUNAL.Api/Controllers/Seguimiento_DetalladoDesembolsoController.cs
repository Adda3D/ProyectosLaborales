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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Seguimiento_DetalladoDesembolsoController : BaseController<Seguimiento_DetalladoDesembolso>
    {
        private readonly ISeguimiento_DetalladoDesembolsoRepository _seguimiento_DetalladoDesembolsoRepository;

        public Seguimiento_DetalladoDesembolsoController(ISeguimiento_DetalladoDesembolsoRepository seguimiento_DetalladoDesembolso)
        {
            _seguimiento_DetalladoDesembolsoRepository = seguimiento_DetalladoDesembolso;
        }

        readonly ISeguimiento_DetalladoDesembolsoRepository seguimiento_DetalladoDesembolso = new Seguimiento_DetalladoDesembolsoRepository();
        public Seguimiento_DetalladoDesembolsoController()
        {
            _seguimiento_DetalladoDesembolsoRepository = seguimiento_DetalladoDesembolso;
        }
        [HttpGet]
        public IHttpActionResult GetAllSeguimiento_DetalladoDesembolso()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_DetalladoDesembolsoRepository.GetAllSeguimiento_DetalladoDesembolso();

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
        public IHttpActionResult GetSeguimiento_DetalladoDesembolsoDetails(int id_detdesembolso)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_DetalladoDesembolsoRepository.GetSeguimiento_DetalladoDesembolsoDetails(id_detdesembolso);

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
        public IHttpActionResult GetSeguimiento_DetalladoDesembolsoCodigo(string cd_codigoquipu)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _seguimiento_DetalladoDesembolsoRepository.GetSeguimiento_DetalladoDesembolsoCodigo(cd_codigoquipu);

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
        public IHttpActionResult InsertSeguimiento_DetalladoDesembolso([FromBody] Seguimiento_DetalladoDesembolso seguimiento_DetalladoDesembolso)
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

                var created = _seguimiento_DetalladoDesembolsoRepository.InsertSeguimiento_DetalladoDesembolso(seguimiento_DetalladoDesembolso);

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
        public IHttpActionResult UpdateSeguimiento_DetalladoDesembolso([FromBody] Seguimiento_DetalladoDesembolso seguimiento_DetalladoDesembolso)
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

                var created = _seguimiento_DetalladoDesembolsoRepository.UpdateSeguimiento_DetalladoDesembolso(seguimiento_DetalladoDesembolso);

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
        public IHttpActionResult DeleteSeguimiento_DetalladoDesembolso(int id_detdesembolso)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _seguimiento_DetalladoDesembolsoRepository.DeleteSeguimiento_DetalladoDesembolso(id_detdesembolso);

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
