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
    public class Publicaciones_DivulgacionMediosRepository : SuperType<Publicaciones_DivulgacionMedios>, IPublicaciones_DivulgacionMediosRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionMediosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionMediosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionMedios(int id_medio)
        {
            Delete(id_medio);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionMedios> GetAllPublicaciones_DivulgacionMedios()
        {
            return Get();
        }

        public Publicaciones_DivulgacionMedios GetPublicaciones_DivulgacionMediosDetails(int id_medio)
        {
            return Get(id_medio);
        }

        public Publicaciones_DivulgacionMedios GetPublicaciones_DivulgacionMediosNombre(string cd_nommedio)
        {
            return Get(c => c.nommedio == cd_nommedio).FirstOrDefault();
        }

        public bool InsertPublicaciones_DivulgacionMedios(Publicaciones_DivulgacionMedios publicaciones_DivulgacionMedios)
        {
            Add(publicaciones_DivulgacionMedios);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionMedios(Publicaciones_DivulgacionMedios publicaciones_DivulgacionMedios)
        {
            Update(publicaciones_DivulgacionMedios);
            return true;
        }
        DataTableAdapter<Publicaciones_DivulgacionMedios> IPublicaciones_DivulgacionMediosRepository.GetDataTablePublicaciones_DivulgacionMedios(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DivulgacionMedios, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DivulgacionMedios, string>> orderByFunc = null;
            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.nommedio.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            orderByFunc = CreateExpressionOrderBy<Publicaciones_DivulgacionMedios>(model.SortColumn);

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DivulgacionMedios> result = new DataTableAdapter<Publicaciones_DivulgacionMedios>();

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