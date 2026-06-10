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
    public class Publicaciones_DivulgacionTipoMedioRepository : SuperType<Publicaciones_DivulgacionTipoMedio>, IPublicaciones_DivulgacionTipoMedioRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionTipoMedioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionTipoMedioRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionTipoMedio(int id_tipomedio)
        {
            Delete(id_tipomedio);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionTipoMedio> GetAllPublicaciones_DivulgacionTipoMedio()
        {
            return Get();
        }

        public Publicaciones_DivulgacionTipoMedio GetPublicaciones_DivulgacionTipoMedioDetails(int id_tipomedio)
        {
            return Get(id_tipomedio);
        }

        public Publicaciones_DivulgacionTipoMedio GetPublicaciones_DivulgacionTipoMedioNombre(string cd_nmtipomedio)
        {
            return Get(c => c.nmtipomedio == cd_nmtipomedio).FirstOrDefault();
        }

        public bool InsertPublicaciones_DivulgacionTipoMedio(Publicaciones_DivulgacionTipoMedio publicaciones_DivulgacionTipoMedio)
        {
            Add(publicaciones_DivulgacionTipoMedio);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionTipoMedio(Publicaciones_DivulgacionTipoMedio publicaciones_DivulgacionTipoMedio)
        {
            Update(publicaciones_DivulgacionTipoMedio);
            return true;
        }
        DataTableAdapter<Publicaciones_DivulgacionTipoMedio> IPublicaciones_DivulgacionTipoMedioRepository.GetDataTablePublicaciones_DivulgacionTipoMedio(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DivulgacionTipoMedio, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DivulgacionTipoMedio, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nmtipomedio.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_DivulgacionTipoMedio>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DivulgacionTipoMedio> result = new DataTableAdapter<Publicaciones_DivulgacionTipoMedio>();

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