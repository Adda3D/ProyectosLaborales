using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_CicloFinancieroPostProgramRepository : SuperType<DecVie_CicloFinancieroPostProgram>, IDecVie_CicloFinancieroPostProgramRepository
    {
        private ApplicationDbContext _context;

        public DecVie_CicloFinancieroPostProgramRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_CicloFinancieroPostProgramRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_CicloFinancieroPostProgram(int id_postprogram)
        {
            Delete(id_postprogram);
            return true;
        }

        public IEnumerable<DecVie_CicloFinancieroPostProgram> GetAllDecVie_CicloFinancieroPostProgram()
        {
            return Get();
        }

        public DecVie_CicloFinancieroPostProgram GetDecVie_CicloFinancieroPostProgramDetails(int id_postprogram)
        {
            return Get(id_postprogram);
        }        

        public bool InsertDecVie_CicloFinancieroPostProgram(DecVie_CicloFinancieroPostProgram decVie_CicloFinancieroPostProgram)
        {
            Add(decVie_CicloFinancieroPostProgram);
            return true;
        }

        public bool UpdateDecVie_CicloFinancieroPostProgram(DecVie_CicloFinancieroPostProgram decVie_CicloFinancieroPostProgram)
        {
            Update(decVie_CicloFinancieroPostProgram);
            return true;
        }

        public bool UpdateDecVie_CicloFinancieroPostProgramBogota(DecVie_CicloFinancieroPostProgramBogotaDTO decVie_CicloFinancieroPostProgrambogota)
        {
            var datos = Get(decVie_CicloFinancieroPostProgrambogota.id_postprogram);

            if (datos != null)
            {
                datos.costosemprog = decVie_CicloFinancieroPostProgrambogota.costosemprog;
                datos.cupos = decVie_CicloFinancieroPostProgrambogota.cupos;
                datos.inscritos = decVie_CicloFinancieroPostProgrambogota.inscritos;
                datos.admitidos = decVie_CicloFinancieroPostProgrambogota.admitidos;
                datos.matriculados = decVie_CicloFinancieroPostProgrambogota.matriculados;
                datos.aplazados = decVie_CicloFinancieroPostProgrambogota.aplazados;
                datos.numestudiantes = decVie_CicloFinancieroPostProgrambogota.numestudiantes;
                datos.porcentaje = decVie_CicloFinancieroPostProgrambogota.porcentaje;
                datos.valor = decVie_CicloFinancieroPostProgrambogota.valor;

                Update(datos);
            }

            return true;
        }

        public bool UpdateDecVie_CicloFinancieroPostProgramConvenio(DecVie_CicloFinancieroPostProgramConvenioDTO decVie_CicloFinancieroPostProgramConvenio)
        {
            var datos = Get(decVie_CicloFinancieroPostProgramConvenio.id_postprogram);

            if (datos != null)
            {
                datos.costosemconvenio = decVie_CicloFinancieroPostProgramConvenio.costosemconvenio;
                datos.cuposconvenio = decVie_CicloFinancieroPostProgramConvenio.cuposconvenio;
                datos.inscritosconvenio = decVie_CicloFinancieroPostProgramConvenio.inscritosconvenio;
                datos.admitidosconvenio = decVie_CicloFinancieroPostProgramConvenio.admitidosconvenio;
                datos.matriculadosconvenio = decVie_CicloFinancieroPostProgramConvenio.matriculadosconvenio;
                datos.aplazadosconvenio = decVie_CicloFinancieroPostProgramConvenio.aplazadosconvenio;
                datos.numestudiantesconvenio = decVie_CicloFinancieroPostProgramConvenio.numestudiantesconvenio;
                datos.porcentajeconvenio = decVie_CicloFinancieroPostProgramConvenio.porcentajeconvenio;
                datos.valorconvenio = decVie_CicloFinancieroPostProgramConvenio.valorconvenio;

                Update(datos);
            }

            return true;

        }

        public bool UpdateDecVie_CicloFinancieroPostProgramFacultad(DecVie_CicloFinancieroPostProgramFacultadDTO decVie_CicloFinancieroPostProgramFacultad)
        {
            var datos = Get(decVie_CicloFinancieroPostProgramFacultad.id_postprogram);

            if (datos != null)
            {
                datos.graduadosbogota = decVie_CicloFinancieroPostProgramFacultad.graduadosbogota;
                datos.graduadosconvenio = decVie_CicloFinancieroPostProgramFacultad.graduadosconvenio;
                               
                Update(datos);
            }

            return true;

        }

        public bool UpdateDecVie_CicloFinancieroPostProgramUAdministrativa(DecVie_CicloFinancieroPostProgramUAdministrativaDTO decVie_CicloFinancieroPostProgramUAdministrativa)
        {
            var datos = Get(decVie_CicloFinancieroPostProgramUAdministrativa.id_postprogram);

            if (datos != null)
            {
                datos.recaudobogota = decVie_CicloFinancieroPostProgramUAdministrativa.recaudobogota;
                datos.recaudoconvenio = decVie_CicloFinancieroPostProgramUAdministrativa.recaudoconvenio;
                datos.porcentajeugi = decVie_CicloFinancieroPostProgramUAdministrativa.porcentajeugi;
                datos.porcentajederadmtvos = decVie_CicloFinancieroPostProgramUAdministrativa.porcentajederadmtvos;
                datos.facultaddsps = decVie_CicloFinancieroPostProgramUAdministrativa.facultaddsps;
                datos.total = decVie_CicloFinancieroPostProgramUAdministrativa.total;
                datos.porcentajeugiconvenio = decVie_CicloFinancieroPostProgramUAdministrativa.porcentajeugiconvenio;
                datos.porcentajederadmtvosconvenio = decVie_CicloFinancieroPostProgramUAdministrativa.porcentajederadmtvosconvenio;
                datos.trasladoistconvenio = decVie_CicloFinancieroPostProgramUAdministrativa.trasladoistconvenio;
                datos.facultaddspsconvenio = decVie_CicloFinancieroPostProgramUAdministrativa.facultaddspsconvenio;                

                Update(datos);
            }

            return true;

        }

        public DataTableAdapter<DecVie_CicloFinancieroPostProgram> GetDataTableDecVie_CicloFinancieroPostProgram(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_CicloFinancieroPostProgram, bool>> srchByFunc = null;
            Expression<Func<DecVie_CicloFinancieroPostProgram, string>> orderByFunc = null;
            Expression<Func<DecVie_CicloFinancieroPostProgram, object>> parameter1 = p => p.Objprogramapostgrado;
            Expression<Func<DecVie_CicloFinancieroPostProgram, object>> parameter2 = p => p.Objciclofinanciero;
            
            Expression<Func<DecVie_CicloFinancieroPostProgram, object>>[] parameterArray = new Expression<Func<DecVie_CicloFinancieroPostProgram, object>>[] { parameter1, parameter2, };
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.facultaddsps.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_CicloFinancieroPostProgram>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_CicloFinancieroPostProgram> result = new DataTableAdapter<DecVie_CicloFinancieroPostProgram>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public DataTableAdapter<DecVie_CicloFinancieroPostProgram> GetDataTableDecVie_CicloFinancieroPostProgramByCiclo(int id_ciclofinanciero, DataTableRequest model)
        {
            var totalRows = 0; //Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_CicloFinancieroPostProgram, bool>> srchByFunc = null;
            Expression<Func<DecVie_CicloFinancieroPostProgram, int>> orderByFunc = null;
            Expression<Func<DecVie_CicloFinancieroPostProgram, object>> parameter1 = p => p.Objprogramapostgrado;
            Expression<Func<DecVie_CicloFinancieroPostProgram, object>> parameter2 = p => p.Objciclofinanciero.Objsemestre;

            Expression<Func<DecVie_CicloFinancieroPostProgram, object>>[] parameterArray = new Expression<Func<DecVie_CicloFinancieroPostProgram, object>>[] { parameter1, parameter2, };
            bool isOrderDesc = false;

            //FILTRA POR Ciclo Financiero
            srchByFunc = d => d.id_ciclofinanciero == id_ciclofinanciero;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_ciclofinanciero == id_ciclofinanciero && d.facultaddsps.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderByInt<DecVie_CicloFinancieroPostProgram>("id_postprogram");

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_CicloFinancieroPostProgram> result = new DataTableAdapter<DecVie_CicloFinancieroPostProgram>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

    }
}