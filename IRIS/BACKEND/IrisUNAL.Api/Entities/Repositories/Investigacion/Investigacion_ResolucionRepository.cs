using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models.Investigacion;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using IrisUNAL.Api.Models.UGI;
using System.Data.Entity;  // Asegura que Include sea el de Entity Framework
using System.Linq.Expressions;


namespace IrisUNAL.Api.Entities.Repositories.Investigacion
{
    public class Investigacion_ResolucionRepository : SuperType<Investigacion_Resolucion>
    {
        private ApplicationDbContext _context;

        public Investigacion_ResolucionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Investigacion_ResolucionRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteInvestigacion_Resolucion(int id_proyectoresolucion)
        {
            Delete(id_proyectoresolucion);
            return true;
        }

        public IEnumerable<Investigacion_Resolucion> GetAllInvestigacion_Resolucion()
        {
            return Get();
        }

        public Investigacion_Resolucion GetInvestigacion_ResolucionDetails(int id_proyectoresolucion)
        {
            return Get(id_proyectoresolucion);
        }

        public bool InsertInvestigacion_Resolucion(Investigacion_Resolucion _investigacion_resolucion)
        {
            Add(_investigacion_resolucion);
            return true;
        }

        public bool UpdateInvestigacion_Resolucion(Investigacion_Resolucion _investigacion_resolucion)
        {
            Update(_investigacion_resolucion);
            return true;
        }

        //public IEnumerable<Investigacion_Resolucion> GetAllInvestigacion_ResolucionByProyecto(int id_crearproyecto)
        //{
        //    return Get(c => c.id_crearproyecto == id_crearproyecto);
        //}

        public IEnumerable<Investigacion_Resolucion> GetAllInvestigacion_ResolucionByProyecto(int id_crearproyecto)
        {
            var resoluciones = _context.Investigacion_Resolucion
                                       .Include(r => r.UGI_Semestre) 
                                       .Where(c => c.id_crearproyecto == id_crearproyecto)
                                       .ToList();

            // Revisa manualmente los resultados
            foreach (var resolucion in resoluciones)
            {
                var numResolucion = resolucion.UGI_Semestre?.numresolucion;
                Console.WriteLine(numResolucion);
            }

            return resoluciones;
        }


        public IEnumerable<Investigacion_ResolucionDto> GetDataTableInvestigacion_ResolucionByProyecto(int id_crearproyecto)
        {
            try
            {
                // Cargar todos los datos con Include para asegurarte de que la relación con UGI_Semestre esté presente
                var data = _context.Investigacion_Resolucion
                          .Include(r => r.UGI_Semestre)  // Asegura que se incluya
                          .Where(r => r.id_crearproyecto == id_crearproyecto)
                          .Select(r => new Investigacion_ResolucionDto
                          {
                              id_proyectoresolucion = r.id_proyectoresolucion,
                              id_crearproyecto = r.id_crearproyecto,
                              // Accedemos a la propiedad numresolucion directamente desde UGI_Semestre
                              numresolucion = r.UGI_Semestre != null ? r.UGI_Semestre.numresolucion : "Sin relación",  // Evitar nulos
                              valor = r.valor,
                              fechacreacion = r.fechacreacion,
                              usuariocreacion = r.usuariocreacion,
                              fechaactualizacion = r.fechaactualizacion,
                              usuarioactualizacion = r.usuarioactualizacion,
                              activo = r.activo
                          })
                          .ToList();

                return data;
            }
            catch (Exception ex)
            {
                // Loguea la excepción para revisarla en los logs del servidor
                Console.WriteLine("Error al obtener datos: " + ex.Message);
                throw new Exception("Ocurrió un error al obtener los datos. Por favor, revisa los detalles en los logs del servidor.");
            }
        }


        public DataTableAdapter<Investigacion_ResolucionDto> GetDataTableInvestigacion_ResolucionByProyecto(int id_crearproyecto, DataTableRequest model)
        {
            var totalRows = 0;
            var RowsFiltered = totalRows;

            // Expresión de filtrado
            Expression<Func<Investigacion_Resolucion, bool>> srchByFunc = p => p.id_crearproyecto == id_crearproyecto;

            // Expresión por defecto para la ordenación
            Expression<Func<Investigacion_Resolucion, int>> defaultOrderByFunc = r => r.resolucion;

            // Obtiene el total de registros sin filtros
            totalRows = CountFiltered(srchByFunc);
            RowsFiltered = totalRows;

            // Si hay un valor de búsqueda, aplica el filtro adicional
            if (!string.IsNullOrEmpty(model.SearchValue))
            {
                srchByFunc = d => d.id_crearproyecto == id_crearproyecto && d.resolucion.ToString().Contains(model.SearchValue);
                RowsFiltered = CountFiltered(srchByFunc);
            }

            // Realiza la búsqueda utilizando la expresión por defecto para la ordenación
            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, defaultOrderByFunc, false)
               .AsQueryable() // Convierte a IQueryable para permitir el uso de Include
               .Include(r => r.UGI_Semestre)  // Incluir la relación
               .Select(r => new Investigacion_ResolucionDto
               {
                   id_proyectoresolucion = r.id_proyectoresolucion,
                   id_crearproyecto = r.id_crearproyecto,
                   numresolucion = r.UGI_Semestre != null ? r.UGI_Semestre.numresolucion : "Sin relación",
                   valor = r.valor,
                   fechacreacion = r.fechacreacion,
                   usuariocreacion = r.usuariocreacion,
                   fechaactualizacion = r.fechaactualizacion,
                   usuarioactualizacion = r.usuarioactualizacion,
                   activo = r.activo
               }).ToList();

            // Creamos y llenamos el DataTableAdapter con los datos resultantes
            DataTableAdapter<Investigacion_ResolucionDto> result = new DataTableAdapter<Investigacion_ResolucionDto>
            {
                Data = data,
                Draw = model.draw,
                RecordsTotal = totalRows,
                RecordsFiltered = RowsFiltered
            };

            return result;
        }

        public IEnumerable<Investigacion_Resolucion> GetResolucionesByProyecto(int id_crearproyecto)
        {
            // Consulta las resoluciones asociadas al proyecto
            return _context.Investigacion_Resolucion
                   .Where(r => r.id_crearproyecto == id_crearproyecto)
                   .Include(r => r.UGI_Semestre)  // Incluye la información del semestre
                   .ToList();
        }


    }
}
