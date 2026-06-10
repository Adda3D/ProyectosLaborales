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
    public class Tipo_DocumentoController : BaseController<Tipo_Documento>
    {
        private readonly ITipo_DocumentoRepository _tipo_DocumentoRepository;

        public Tipo_DocumentoController(ITipo_DocumentoRepository tipo_DocumentoRepository)
        {
            _tipo_DocumentoRepository = tipo_DocumentoRepository;
        }

        readonly ITipo_DocumentoRepository tipo_DocumentoRepository = new Tipo_DocumentoRepository();
        public Tipo_DocumentoController()
        {
            _tipo_DocumentoRepository = tipo_DocumentoRepository;
        }
        [HttpGet]
        public IHttpActionResult GetAllTipo_Documento()
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipo_DocumentoRepository.GetAllTipo_Documento();

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
        public IHttpActionResult GetTipo_DocumentoDetails(int id_tipodocumento)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipo_DocumentoRepository.GetTipo_DocumentoDetails(id_tipodocumento);

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
        public IHttpActionResult GetTipo_DocumentoCodigo(string cd_nmtipodoc)
        {
            var resultdb = new ResultObject();
            try
            {
                var data = _tipo_DocumentoRepository.GetTipo_DocumentoDetails(cd_nmtipodoc);

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
        public IHttpActionResult InsertTipo_Documento([FromBody] Tipo_Documento tipo_Documento)
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

                var created = _tipo_DocumentoRepository.InsertTipo_Documento(tipo_Documento);

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
        public IHttpActionResult UpdateTipo_Documento([FromBody] Tipo_Documento tipo_Documento)
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

                var created = _tipo_DocumentoRepository.UpdateTipo_Documento(tipo_Documento);

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
        public IHttpActionResult DeleteTipo_Documento(int id_tipodocumento)
        {
            var resultdb = new ResultObject();
            try
            {
                //***VALIDAR LAS REGLAS DE BORRADO

                var data = _tipo_DocumentoRepository.DeleteTipo_Documento(id_tipodocumento);

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
