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
    public class Publicaciones_DivulgacionActividadInvitadosRepository : SuperType<Publicaciones_DivulgacionActividadInvitados>, IPublicaciones_DivulgacionActividadInvitadosRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DivulgacionActividadInvitadosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DivulgacionActividadInvitadosRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DivulgacionActividadInvitados(int id_invitdos)
        {
            Delete(id_invitdos);
            return true;
        }

        public IEnumerable<Publicaciones_DivulgacionActividadInvitados> GetAllPublicaciones_DivulgacionActividadInvitados()
        {
            return Get();
        }

        public Publicaciones_DivulgacionActividadInvitados GetPublicaciones_DivulgacionActividadInvitadosDetails(int id_invitados)
        {
            return Get(id_invitados);
        }

        public bool InsertPublicaciones_DivulgacionActividadInvitados(Publicaciones_DivulgacionActividadInvitados publicaciones_DivulgacionActividadInvitados)
        {
            Add(publicaciones_DivulgacionActividadInvitados);
            return true;
        }

        public bool UpdatePublicaciones_DivulgacionActividadInvitados(Publicaciones_DivulgacionActividadInvitados publicaciones_DivulgacionActividadInvitados)
        {            
            var datosinvitado = Get(publicaciones_DivulgacionActividadInvitados.id_invitados);

            //*** MUY CHAMBON ESTO
            datosinvitado.id_invitados = publicaciones_DivulgacionActividadInvitados.id_invitados;
            datosinvitado.id_crearpublicacion = publicaciones_DivulgacionActividadInvitados.id_crearpublicacion;
            datosinvitado.nombrecompleto = publicaciones_DivulgacionActividadInvitados.nombrecompleto;
            datosinvitado.institucion = publicaciones_DivulgacionActividadInvitados.institucion;
            datosinvitado.nalointer = publicaciones_DivulgacionActividadInvitados.nalointer;
            datosinvitado.perfil = publicaciones_DivulgacionActividadInvitados.perfil;
            datosinvitado.telefono = publicaciones_DivulgacionActividadInvitados.telefono;
            datosinvitado.email = publicaciones_DivulgacionActividadInvitados.email;
            datosinvitado.divulgacionfoto = publicaciones_DivulgacionActividadInvitados.divulgacionfoto;
            datosinvitado.divulgacionnombre = publicaciones_DivulgacionActividadInvitados.divulgacionnombre;
            datosinvitado.divulgacionperfil = publicaciones_DivulgacionActividadInvitados.divulgacionperfil;

            //Update(publicaciones_DivulgacionActividadInvitados);
            Update(datosinvitado);
            return true;
        }

        public DataTableAdapter<Publicaciones_DivulgacionActividadInvitados> GetDataTablePublicaciones_DivulgacionActividadInvitadosByPublicacion(int id_crearpublicacion, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Publicaciones_DivulgacionActividadInvitados, bool>> srchByFunc = null;
            Expression<Func<Publicaciones_DivulgacionActividadInvitados, string>> orderByFunc = null;
            //Expression<Func<Publicaciones_DivulgacionActividadInvitados, DateTime>> orderByDateFunc = null;            

            bool isOrderDesc = false;

            orderByFunc = CreateExpressionOrderBy<Publicaciones_DivulgacionActividadInvitados>(model.SortColumn);

            //FILTRA POR LA PUBLICACION
            srchByFunc = p => p.id_crearpublicacion == id_crearpublicacion;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_crearpublicacion == id_crearpublicacion;
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = Get(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Publicaciones_DivulgacionActividadInvitados> result = new DataTableAdapter<Publicaciones_DivulgacionActividadInvitados>();

            //Llenamos con información nuestro DataTableAdapter
            result.Data = data;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = RowsFiltered;
            //Regresamos el objeto result
            return result;
        }

        public bool UpdatePublicaciones_DivulgacionActividadInvitadosCierre(Publicaciones_DivulgacionActividadInvitados publicaciones_DivulgacionActividadInvitados)
        {
            var datosinvitado = Get(publicaciones_DivulgacionActividadInvitados.id_invitados);

            datosinvitado.agradecimientoevento = publicaciones_DivulgacionActividadInvitados.agradecimientoevento;
            datosinvitado.agradecimientonotas = publicaciones_DivulgacionActividadInvitados.agradecimientonotas;

            Update(datosinvitado);

            return true;

        }
    }
}