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
    public class Publicaciones_EstadoConceptoRepository : SuperType<Publicaciones_EstadoConcepto>, IPublicaciones_EstadoConceptoRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_EstadoConceptoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_EstadoConceptoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_EstadoConcepto(int id_estadoconcepto)
        {
            Delete(id_estadoconcepto);
            return true;
        }

        public IEnumerable<Publicaciones_EstadoConcepto> GetAllPublicaciones_EstadoConcepto()
        {
            return Get();
        }

        public Publicaciones_EstadoConcepto GetPublicaciones_EstadoConceptoDetails(int id_estadoconcepto)
        {
            return Get(id_estadoconcepto);
        }

        public Publicaciones_EstadoConcepto GetPublicaciones_EstadoConceptoNombre(string cd_nmestadoconcepto)
        {
            return Get(c => c.nmestadoconcepto == cd_nmestadoconcepto).FirstOrDefault();
        }

        public bool InsertPublicaciones_EstadoConcepto(Publicaciones_EstadoConcepto publicaciones_EstadoConcepto)
        {
            Add(publicaciones_EstadoConcepto);
            return true;
        }

        public bool UpdatePublicaciones_EstadoConcepto(Publicaciones_EstadoConcepto publicaciones_EstadoConcepto)
        {
            Update(publicaciones_EstadoConcepto);
            return true;
        }
        DataTableAdapter<Publicaciones_EstadoConcepto> IPublicaciones_EstadoConceptoRepository.GetDataTablePublicaciones_EstadoConcepto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_EstadoConcepto, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_EstadoConcepto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmestadoconcepto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_EstadoConcepto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_EstadoConcepto> result = new DataTableAdapter<Publicaciones_EstadoConcepto>();

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