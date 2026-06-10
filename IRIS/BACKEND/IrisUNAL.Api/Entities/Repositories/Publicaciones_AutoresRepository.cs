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
    public class Publicaciones_AutoresRepository : SuperType<Publicaciones_Autores>, IPublicaciones_AutoresRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_AutoresRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_AutoresRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_Autores(int id_autores)
        {
            Delete(id_autores);
            return true;
        }

        public IEnumerable<Publicaciones_Autores> GetAllPublicaciones_Autores()
        {
            return Get();
        }

        public Publicaciones_Autores GetPublicaciones_AutoresDetails(int id_autores)
        {
            return Get(id_autores);
        }
        public Publicaciones_Autores GetPublicaciones_AutoresByPublicacion(int id_crearpublicacion, int id_persona)
        {
            return Get(p => p.id_crearpublicacion == id_crearpublicacion  && p.id_persona == id_persona).FirstOrDefault();
        }

        public bool InsertPublicaciones_Autores(Publicaciones_Autores publicaciones_Autores)
        {
            Add(publicaciones_Autores);
            return true;
        }

        public bool UpdatePublicaciones_Autores(Publicaciones_Autores publicaciones_Autores)
        {
            Update(publicaciones_Autores);
            return true;
        }
        public DataTableAdapter<Publicaciones_Autores> GetDataTablePublicaciones_AutoresByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_Autores, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_Autores, int>> orderByFunc = null;

            Expression<Func<Publicaciones_Autores, object>> parameter1 = m => m.nompersona;
            Expression<Func<Publicaciones_Autores, object>>[] parameterArray = new Expression<Func<Publicaciones_Autores, object>>[] { parameter1 };

            bool isOrderDesc = false;

            //orderByFunc = CreateExpressionOrderBy<Publicaciones_Autores>(model.SortColumn);
            orderByFunc = CreateExpressionOrderByInt<Publicaciones_Autores>("id_autores");

            //FILTRA POR Publicacion
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearpublicacion == id_crearpublicacion && d.NombrePersona.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_Autores> result = new DataTableAdapter<Publicaciones_Autores>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public Publicaciones_Autores GetPublicaciones_AutoresDetailsPersona(int id_autores)
        {
            Expression<Func<Publicaciones_Autores, object>> parameter1 = m => m.nompersona;            
            Expression<Func<Publicaciones_Autores, object>>[] parameterArray = new Expression<Func<Publicaciones_Autores, object>>[] { parameter1 };

            return Get(e => e.id_autores == id_autores, parameterArray).FirstOrDefault();

        }

        public bool UpdatePublicaciones_AutoresLanzamiento(Publicaciones_Autores publicaciones_Autores)
        {
            var datosautor = Get(publicaciones_Autores.id_autores);

            datosautor.divulgacionfoto = publicaciones_Autores.divulgacionfoto;
            datosautor.divulgacionnombre = publicaciones_Autores.divulgacionnombre;
            datosautor.divulgacionperfil = publicaciones_Autores.divulgacionperfil;

            Update(datosautor);

            return true;
        }

        public bool UpdatePublicaciones_AutoresCierre(Publicaciones_Autores publicaciones_Autores)
        {
            var datosautor = Get(publicaciones_Autores.id_autores);

            datosautor.retroalimentacionevento = publicaciones_Autores.retroalimentacionevento;
            datosautor.retroalimentacionnotas = publicaciones_Autores.retroalimentacionnotas;            

            Update(datosautor);

            return true;

        }
    }
}