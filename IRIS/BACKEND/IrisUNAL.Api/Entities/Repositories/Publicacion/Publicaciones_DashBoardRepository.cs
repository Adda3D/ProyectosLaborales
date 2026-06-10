using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Publicacion
{
    public class Publicaciones_DashBoardRepository : SuperType<Publicaciones_CrearPublicacion>
    {
        private ApplicationDbContext _context;
        public Publicaciones_DashBoardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Publicaciones_DashBoardRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable RegistrosPorAreaPublicado(string rango1, string rango2)
        {
            string qry = ("SELECT AA.NMAACAD, PC.ANOPUBLICACION, COUNT(PC.ID_CREARPUBLICACION) CANTIDAD FROM PUBLICACIONES_CREARPUBLICACION PC JOIN AREA_ACADEMICA AA ON PC.ID_AREAACAD = AA.ID_AREAACAD WHERE PC.ID_AREAACAD IS NOT NULL AND PC.ANOPUBLICACION between @rango1 and @rango2 GROUP BY PC.ID_AREAACAD, AA.NMAACAD, PC.ANOPUBLICACION");
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@rango1", rango1));
            parameterList.Add(new NpgsqlParameter("@rango2", rango2));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<CantidadPorAreaPublicada>(qry, Param).ToList();
            return datos;
        }

        public IEnumerable RegistrosPorFechaManuscritoPublicado()
        {
            var registros = _context.Database.SqlQuery<CantidadPublicada>("select anopublicacion, count(id_crearpublicacion) cantidad from publicaciones_crearpublicacion group by anopublicacion");

            return registros;
        }

        public IEnumerable RegistrosPublicacionesPorColeccion()
        {
            var registrosColeccion =
           _context.Database.SqlQuery<CantidadPorColeccion>("select co.nmcoleccion as colección, cp.anopublicacion as año, count(cp.id_coleccion) from publicaciones_crearpublicacion cp join publicaciones_coleccion co on cp.id_coleccion = co.id_coleccion where idestadomanuscrito = 7 group by co.nmcoleccion, cp.anopublicacion");
            return registrosColeccion;
        }
        public IEnumerable RegistrosPublicacionesPorEstado()
        {
            var registrosestado =
           _context.Database.SqlQuery<PublicacionesPorEstado>("select estadomanuscrito, count(id_crearpublicacion) cantidad from publicaciones_crearpublicacion pub join publicaciones_estadomanuscrito pe on pub.idestadomanuscrito = pe.idestadomanuscrito group by EstadoManuscrito");
            return registrosestado;
        }
        public IEnumerable EstadosPublicacionesManuscritosGetAll()
        {
            var manuscritosestados =
           _context.Database.SqlQuery<EstadosManuscritos>("select idestadomanuscrito, estadomanuscrito from publicaciones_estadomanuscrito");
            return manuscritosestados;
        }
        public IEnumerable ReportePresupuestalPublicacionesSemestre(string semestre)
        {
            var servicioeditorial =
            ("select SUM(pa.valorneto) AS CORRECCION, (select SUM(pa.valorneto) FROM PUBLICACION_aplicarpago pa join PUBLICACION_gasto ga on pa.id_publicaciongasto = ga.id_publicaciongasto where pa.id_semestre = 2 and ga.nombregasto like '%DIAGRAMACIÓN%') + (select SUM(pa.valorneto) FROM PUBLICACION_aplicarpago pa join PUBLICACION_gasto ga on pa.id_publicaciongasto = ga.id_publicaciongasto where pa.id_semestre = 2 AND ga.nombregasto like '%IMAGEN%') AS EDICIONDIAGRAMACION, (select SUM(pa.valorneto) FROM PUBLICACION_aplicarpago pa join PUBLICACION_gasto ga on pa.id_publicaciongasto = ga.id_publicaciongasto where pa.id_semestre = 2 and ga.nombregasto like '%DIGITALIZACIÓN%')+ (select SUM(pa.valorneto) FROM PUBLICACION_aplicarpago pa join PUBLICACION_gasto ga on pa.id_publicaciongasto = ga.id_publicaciongasto where pa.id_semestre = 2 and ga.nombregasto like '%COMBOS%') AS IMPRESIONDIGITALIZACION, (select SUM(pa.valorneto) AS TOTALSERVICIOEDITORIAL FROM PUBLICACION_aplicarpago pa where pa.id_semestre = 2), /*aquí va la misma variable en el semestre*/ (SELECT SUM(CS.VALORPROYECTADO) AS VALORPROYECTADO FROM UGI_CONCEPTOSEMESTRE CS JOIN UGI_LITERALSEMESTRE LT ON CS.ID_UGILITERALSEMESTRE = LT.ID_UGILITERALSEMESTRE JOIN LITERAL_UGI LU ON LT.ID_LITERAL = LU.ID_LITERAL join ugi_semestre us on lt.id_ugisemestre = us.id_ugisemestre WHERE NMLITERAL = 'H' and us.id_semestre = 2) /*aquí va una variable en el semestre*/ FROM PUBLICACION_aplicarpago pa join PUBLICACION_gasto ga on pa.id_publicaciongasto = ga.id_publicaciongasto where pa.id_semestre = 2 and ga.nombregasto like '%CORRECCIÓN%'");

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@semestre", semestre));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<ReportePresupuestalPublicaciones>(servicioeditorial, Param).ToList();

            return datos;
        }
        public IEnumerable EstadoEvaluaciones(int anio)
        {
            string qry = ("select co.nmconcepto, count(ec.id_crearpublicacion) from publicaciones_evalconcepto ec join publicaciones_concepto co on co.id_concepto = ec.id_concepto where date_part('year', ec.fecaceptado) = @anio group by co.id_concepto");
            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@anio", anio));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<EstadoEvaluacionesDTO>(qry, Param).ToList();
            return datos;
        }
    }
}