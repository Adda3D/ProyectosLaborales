using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_ControlFinancieroTipoOperativoRepository : SuperType<DecVie_ControlFinancieroTipoOperativo>, IDecVie_ControlFinancieroTipoOperativoRepository
    {
        private ApplicationDbContext _context;

        public DecVie_ControlFinancieroTipoOperativoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_ControlFinancieroTipoOperativoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_ControlFinancieroTipoOperativo(int id_tipooperativo)
        {
            Delete(id_tipooperativo);
            return true;
        }

        public IEnumerable<DecVie_ControlFinancieroTipoOperativo> GetAllDecVie_ControlFinancieroTipoOperativo()
        {
            return Get();
        }

        public DecVie_ControlFinancieroTipoOperativo GetDecVie_ControlFinancieroTipoOperativoDetails(int id_tipooperativo)
        {
            return Get(id_tipooperativo);
        }

        public DecVie_ControlFinancieroTipoOperativo GetDecVie_ControlFinancieroTipoOperativoNombre(string cd_nmtipooperativo)
        {
            return Get(c => c.nmtipooperativo == cd_nmtipooperativo).FirstOrDefault();
        }

        public bool InsertDecVie_ControlFinancieroTipoOperativo(DecVie_ControlFinancieroTipoOperativo decVie_ControlFinancieroTipoOperativo)
        {
            Add(decVie_ControlFinancieroTipoOperativo);
            return true;
        }

        public bool UpdateDecVie_ControlFinancieroTipoOperativo(DecVie_ControlFinancieroTipoOperativo decVie_ControlFinancieroTipoOperativo)
        {
            Update(decVie_ControlFinancieroTipoOperativo);
            return true;
        }
        DataTableAdapter<DecVie_ControlFinancieroTipoOperativo> IDecVie_ControlFinancieroTipoOperativoRepository.GetDataTableDecVie_ControlFinancieroTipoOperativo(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<DecVie_ControlFinancieroTipoOperativo, bool>> srchByFunc = null;
            Expression<Func<DecVie_ControlFinancieroTipoOperativo, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipooperativo.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<DecVie_ControlFinancieroTipoOperativo>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<DecVie_ControlFinancieroTipoOperativo> result = new DataTableAdapter<DecVie_ControlFinancieroTipoOperativo>();

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