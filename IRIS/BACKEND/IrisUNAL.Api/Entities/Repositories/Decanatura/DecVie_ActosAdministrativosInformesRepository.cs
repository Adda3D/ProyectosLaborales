using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Decanatura
{
    public class DecVie_ActosAdministrativosInformesRepository : SuperType<DecVie_ActosAdministrativos>
    {
        private ApplicationDbContext _context;

        public DecVie_ActosAdministrativosInformesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_ActosAdministrativosInformesRepository()
        {
            _context = new ApplicationDbContext();
        }

        private string GetQueryInformePorTipo(string camponombre, string campojoin, string tablajoin)
        {
            string qryInforme = "select " + camponombre + " tipo, count(da." + campojoin + ") cantidad from decvie_actosadministrativos da " +
                        "join " + tablajoin + " ta on da." + campojoin + " = ta." + campojoin +
                        " where fechaexpedicion >= @fechainicial and fechaexpedicion <= @fechafinal " +
                        "group by " + camponombre + " order by " + camponombre;

            return qryInforme;
        }

        private string GetQueryRegistrosInformeTipo(string campocontar)
        {
            string qryInforme = "select count(*) from " +
                "(select count(" + campocontar + ") from decvie_actosadministrativos " +
                "where fechaexpedicion >= @fechainicial and fechaexpedicion <= @fechafinal " +
                "group by " + campocontar + ") as r ";

            return qryInforme;
        }

        private string GetQueryInformePorMes()
        {
            string qryInforme = "select concat(yearp,'-',nombremes) tipo, cantidad from " +
                "(SELECT date_part('month',DATE_TRUNC('month', fechaexpedicion)) AS mesp, date_part('year', DATE_TRUNC('year', fechaexpedicion)) AS yearp, count(id_actoadministrativo) cantidad " +
                "  from decvie_actosadministrativos " +
                "  where fechaexpedicion >= @fechainicial and fechaexpedicion <= @fechafinal " +
                " group by DATE_TRUNC('month', fechaexpedicion),DATE_TRUNC('year', fechaexpedicion)) as rm " +
                " join meses m on rm.mesp = m.idmes " +
                " order by yearp,mesp ";

            return qryInforme;
        }

        private string GetQueryRegistrosInformePorMes()
        {
            string qryInforme = "select count(*) from " +
                "(SELECT date_part('month', DATE_TRUNC('month', fechaexpedicion)) AS mesp, date_part('year', DATE_TRUNC('year', fechaexpedicion)) AS yearp, count(id_actoadministrativo) cantidad " +
                " from decvie_actosadministrativos " +
                " where fechaexpedicion >= @fechainicial and fechaexpedicion <= @fechafinal " +
                " group by DATE_TRUNC('month', fechaexpedicion), DATE_TRUNC('year', fechaexpedicion)) as rm ";

            return qryInforme;
        }


        private int RegistrosPorTipoInforme(int idtipoinforme, DateTime fechainicial, DateTime fechafinal)
        {
            string qryInforme = "";

            switch (idtipoinforme)
            {
                case 1:
                    qryInforme = GetQueryRegistrosInformeTipo("id_tipoactoadministrativo");
                    break;
                case 2:
                    qryInforme = GetQueryRegistrosInformeTipo("id_estadoactoadministrativo");
                    break;
                case 3:
                    qryInforme = GetQueryRegistrosInformeTipo("id_decvietipologia");
                    break;
                case 4:
                    qryInforme = GetQueryRegistrosInformeTipo("id_depend");
                    break;
                case 5:
                    qryInforme = GetQueryRegistrosInformeTipo("id_decviemacroproceso");
                    break;
                case 6:
                    qryInforme = GetQueryRegistrosInformePorMes();
                    break;

            }

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@fechainicial", fechainicial));
            parameterList.Add(new NpgsqlParameter("@fechafinal", fechafinal));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var registros = _context.Database.SqlQuery<int>(qryInforme, Param).FirstOrDefault();

            return registros;
        }

        public IEnumerable<InformeTipoCantidadDTO> GetInformeDecVie_ActosAdministrativos(int idtipoinforme, DateTime fechainicial, DateTime fechafinal)
        {
            string qryInforme = "";

            switch (idtipoinforme)
            {
                case 1:
                    qryInforme = GetQueryInformePorTipo("nmidtipoactoadministrativo", "id_tipoactoadministrativo", "decvie_actosadministrativostipo");
                    break;
                case 2:
                    qryInforme = GetQueryInformePorTipo("nmestadoactoadministrativo", "id_estadoactoadministrativo", "decvie_actosadministrativosestado");
                    break;
                case 3:
                    qryInforme = GetQueryInformePorTipo("nmdecvietipologia", "id_decvietipologia", "decvie_tipologia");
                    break;
                case 4:
                    qryInforme = GetQueryInformePorTipo("nmdepend", "id_depend", "dependencia");
                    break;
                case 5:
                    qryInforme = GetQueryInformePorTipo("nmdecviemacroproceso", "id_decviemacroproceso", "decvie_macroproceso");
                    break;
                case 6:
                    qryInforme = GetQueryInformePorMes();
                    break;
            }

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@fechainicial", fechainicial));
            parameterList.Add(new NpgsqlParameter("@fechafinal", fechafinal));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<InformeTipoCantidadDTO>(qryInforme, Param);

            return datos;
        }

        public DataTableAdapter<InformeTipoCantidadDTO> GetDataTableInformeDecVie_ActosAdministrativos(int idtipoinforme, DateTime fechainicial, DateTime fechafinal, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;
            string qryInforme = "";

            switch (idtipoinforme)
            {
                case 1:
                    qryInforme = GetQueryInformePorTipo("nmidtipoactoadministrativo", "id_tipoactoadministrativo", "decvie_actosadministrativostipo");                    
                    break;
                case 2:
                    qryInforme = GetQueryInformePorTipo("nmestadoactoadministrativo", "id_estadoactoadministrativo", "decvie_actosadministrativosestado");                    
                    break;
                case 3:
                    qryInforme = GetQueryInformePorTipo("nmdecvietipologia", "id_decvietipologia", "decvie_tipologia");
                    break;
                case 4:
                    qryInforme = GetQueryInformePorTipo("nmdepend", "id_depend", "dependencia");
                    break;
                case 5:
                    qryInforme = GetQueryInformePorTipo("nmdecviemacroproceso", "id_decviemacroproceso", "decvie_macroproceso");
                    break;
                case 6:
                    qryInforme = GetQueryInformePorMes();
                    break;
            }

            qryInforme = qryInforme + " LIMIT " + model.PageSize + " OFFSET " + model.Skip;
            totalRows = RegistrosPorTipoInforme(idtipoinforme, fechainicial, fechafinal);
            RowsFiltered = totalRows;

            List<NpgsqlParameter> parameterList = new List<NpgsqlParameter>();
            parameterList.Add(new NpgsqlParameter("@fechainicial", fechainicial));
            parameterList.Add(new NpgsqlParameter("@fechafinal", fechafinal));
            NpgsqlParameter[] Param = parameterList.ToArray();

            var datos = _context.Database.SqlQuery<InformeTipoCantidadDTO>(qryInforme, Param).ToList();

            //model.Skip, model.PageSize

            DataTableAdapter<InformeTipoCantidadDTO> result = new DataTableAdapter<InformeTipoCantidadDTO>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = datos;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;

        }
    }
}