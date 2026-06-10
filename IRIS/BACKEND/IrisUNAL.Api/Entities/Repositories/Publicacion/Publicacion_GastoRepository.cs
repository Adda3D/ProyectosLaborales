using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Publicacion;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories.Publicacion
{
    public class Publicacion_GastoRepository : SuperType<Publicacion_Gasto>
    {
        private ApplicationDbContext _context;

        public Publicacion_GastoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicacion_GastoRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeletePublicacion_Gasto(int id_publicaciongasto)
        {
            Delete(id_publicaciongasto);
            return true;
        }

        public IEnumerable<Publicacion_Gasto> GetAllPublicacion_Gasto()
        {
            return Get();
        }

        public Publicacion_Gasto GetPublicacion_GastoDetails(int id_publicaciongasto)
        {
            return Get(id_publicaciongasto);
        }

        public bool InsertPublicacion_Gasto(Publicacion_Gasto _publicacion_gasto)
        {
            Add(_publicacion_gasto);
            return true;
        }

        public bool UpdatePublicacion_Gasto(Publicacion_Gasto _publicacion_gasto)
        {
            Update(_publicacion_gasto);
            return true;
        }

        public DataTableAdapter<Publicacion_Gasto> GetDataTablePublicacion_GastoByPublicacion(int id_crearpublicacion, int id_partida, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicacion_Gasto, bool>> srchByFunc = null;
            Expression<Func<Publicacion_Gasto, string>> orderByFunc = null;
            Expression<Func<Publicacion_Gasto, DateTime>> orderByDateFunc = null;

            Expression<Func<Publicacion_Gasto, object>> parameter1 = m => m.ObjPersona;
            Expression<Func<Publicacion_Gasto, object>> parameter2 = m => m.ObjConcepto;
            Expression<Func<Publicacion_Gasto, object>> parameter3 = m => m.ObjRubro;
            Expression<Func<Publicacion_Gasto, object>>[] parameterArray = new Expression<Func<Publicacion_Gasto, object>>[] { parameter1, parameter2, parameter3 };

            bool isOrderDesc = false;

            if (model.SortColumn.ToLower() == "fechainicio")
                orderByDateFunc = CreateExpressionOrderByDate<Publicacion_Gasto>("fechainicio");
            else
                orderByFunc = CreateExpressionOrderBy<Publicacion_Gasto>(model.SortColumn);


            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion && p.id_partida == id_partida;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearpublicacion == id_crearpublicacion && d.id_partida == id_partida && d.nombregasto.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //**** TOTAL PAGADO POR GASTO
            var valoraportado = (from ap in _context.publicacion_aplicarpago
                                 where ap.id_crearpublicacion == id_crearpublicacion
                                 group ap by ap.id_publicaciongasto into dt
                                 select new
                                 {
                                     valorpagado = dt.Sum(x => x.valorneto),
                                     idgasto = dt.Key
                                 }).ToList();

            foreach (var detgasto in data)
            {
                var objpago = valoraportado.Find(x => x.idgasto == detgasto.id_publicaciongasto);

                if (objpago != null)
                {
                    detgasto.TotalPagado = objpago.valorpagado;
                }
            }

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicacion_Gasto> result = new DataTableAdapter<Publicacion_Gasto>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public Publicacion_Gasto GetPublicacion_GastoRelaciones(int id_publicaciongasto)
        {
            Expression<Func<Publicacion_Gasto, object>> parameter1 = m => m.ObjPersona;
            Expression<Func<Publicacion_Gasto, object>> parameter2 = m => m.ObjConcepto;
            Expression<Func<Publicacion_Gasto, object>> parameter3 = m => m.ObjRubro;
            Expression<Func<Publicacion_Gasto, object>>[] parameterArray = new Expression<Func<Publicacion_Gasto, object>>[] { parameter1, parameter2, parameter3 };

            return Get(c => c.id_publicaciongasto == id_publicaciongasto, parameterArray).FirstOrDefault();
        }
    }
}