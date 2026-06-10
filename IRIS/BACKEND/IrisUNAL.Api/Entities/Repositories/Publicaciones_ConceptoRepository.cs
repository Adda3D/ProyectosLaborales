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
    public class Publicaciones_ConceptoRepository : SuperType<Publicaciones_Concepto>, IPublicaciones_ConceptoRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_ConceptoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_ConceptoRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Concepto(int id_concepto)
        {
            Delete(id_concepto);
            return true;
        }

        public IEnumerable<Publicaciones_Concepto> GetAllPublicaciones_Concepto()
        {
            return Get();
        }

        public Publicaciones_Concepto GetPublicaciones_ConceptoDetails(int id_concepto)
        {
            return Get(id_concepto);
        }

        public Publicaciones_Concepto GetPublicaciones_ConceptoNombre(string cd_nmconcepto)
        {
            return Get(c => c.nmconcepto == cd_nmconcepto).FirstOrDefault();
        }

        public bool InsertPublicaciones_Concepto(Publicaciones_Concepto publicaciones_Concepto)
        {
            Add(publicaciones_Concepto);
            return true;
        }

        public bool UpdatePublicaciones_Concepto(Publicaciones_Concepto publicaciones_Concepto)
        {
            Update(publicaciones_Concepto);
            return true;
        }
        DataTableAdapter<Publicaciones_Concepto> IPublicaciones_ConceptoRepository.GetDataTablePublicaciones_Concepto(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_Concepto, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_Concepto, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmconcepto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_Concepto>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_Concepto> result = new DataTableAdapter<Publicaciones_Concepto>();

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