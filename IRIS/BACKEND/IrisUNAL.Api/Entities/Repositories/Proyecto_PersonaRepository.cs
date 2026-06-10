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
    public class Proyecto_PersonaRepository : SuperType<Proyecto_Persona>, IProyecto_PersonaRepository
    {
        private ApplicationDbContext _context;

        public Proyecto_PersonaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyecto_PersonaRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteProyecto_Persona(int id_proyectopersona)
        {
            Delete(id_proyectopersona);
            return true;
        }

        public IEnumerable<Proyecto_Persona> GetAllProyecto_Persona()
        {
            return Get();
        }

        public Proyecto_Persona GetProyecto_PersonaDetails(int id_proyectopersona)
        {
            return Get(id_proyectopersona);
        }

        public Proyecto_Persona GetProyecto_PersonaByProyectoTipoPersona(int id_proyecto, int id_tipo, int id_persona)
        {
            return Get(p => p.id_asignacionproyecto == id_proyecto && p.id_tipoproyecto == id_tipo && p.id_persona == id_persona).FirstOrDefault();
        }

        public bool InsertProyecto_Persona(Proyecto_Persona proyecto_Persona)
        {
            Add(proyecto_Persona);
            return true;
        }

        public bool UpdateProyecto_Persona(Proyecto_Persona proyecto_Persona)
        {
            Update(proyecto_Persona);
            return true;
        }

        public DataTableAdapter<Proyecto_Persona> GetDataTableProyectos_PersonaByProyecto(int id_asignacionproyecto, int id_tipoproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            Expression<Func<Proyecto_Persona, bool>> srchByFunc = null;
            Expression<Func<Proyecto_Persona, int>> orderByFunc = null;

            Expression<Func<Proyecto_Persona, object>> parameter1 = m => m.persona;
            Expression<Func<Proyecto_Persona, object>>[] parameterArray = new Expression<Func<Proyecto_Persona, object>>[] { parameter1 };

            bool isOrderDesc = false;

            //orderByFunc = CreateExpressionOrderBy<Proyecto_Persona>(model.SortColumn);
            orderByFunc = CreateExpressionOrderByInt<Proyecto_Persona>("id_proyectopersona");

            //FILTRA POR EL PROYECTO
            srchByFunc = p => p.id_asignacionproyecto == id_asignacionproyecto && p.id_tipoproyecto == id_tipoproyecto;
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;
            
            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = d => d.id_asignacionproyecto == id_asignacionproyecto && d.nombrepersona.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }
            
            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Proyecto_Persona> result = new DataTableAdapter<Proyecto_Persona>();

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