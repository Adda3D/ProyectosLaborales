using IrisUNAL.Api.Entities.Repositories.Publicacion;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.Publicacion;
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

namespace IrisUNAL.Api.Controllers.Publicacion
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PublicacionesExcelController : BaseController<PublicacionesExcel>
    {
        private readonly PublicacionesExcelRepository _publicacionesExcelRepository;
        public PublicacionesExcelController(PublicacionesExcelRepository publicacionesExcelRepository)
        {
            _publicacionesExcelRepository = publicacionesExcelRepository;
        }
        readonly PublicacionesExcelRepository publicacionesExcelRepository = new PublicacionesExcelRepository();
        public PublicacionesExcelController()
        {
            _publicacionesExcelRepository = publicacionesExcelRepository;
        }
        [HttpGet]

        public IHttpActionResult ExcelPublicaciones(string id_kardex, int id_bodega)
        {
            var resultdb = new ResultObject();
            try
            {
                var archivoresultado = _publicacionesExcelRepository.ExcelPublicaciones(id_kardex, id_bodega);

                resultdb.Ok = true;
                resultdb.Message = "";

                if (archivoresultado == null)
                {
                    resultdb.Ok = false;
                    resultdb.Message = "Error creando Archivo Excel";
                }

                resultdb.Data = archivoresultado;

                return Return(resultdb);
            }
            catch (Exception ex)
            {
                return Return(resultdb, ex);
            }

        }
    }
}