using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Estado_TareaRepository : SuperType<Estado_Tarea>, IEstado_TareaRepository
    {
        private ApplicationDbContext _context;
        public Estado_TareaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Estado_TareaRepository()
        {
            _context = new ApplicationDbContext();
        }
        bool IEstado_TareaRepository.DeleteEstado_Tarea(int id_estadotarea)
        {
            Delete(id_estadotarea);

            return true;
        }

        IEnumerable<Estado_Tarea> IEstado_TareaRepository.GetAllEstado_Tarea()
        {
            return Get();
        }
        Estado_Tarea IEstado_TareaRepository.GetEstado_TareaDetails(int id_estadotarea)
        {
            return Get(id_estadotarea);
        }

        IEnumerable<Estado_Tarea> IEstado_TareaRepository.GetEstado_TareaDetails(string cd_nmestadotarea)
        {
            return Get(d => d.nmestadotarea == cd_nmestadotarea);
        }

        bool IEstado_TareaRepository.InsertEstado_Tarea(Estado_Tarea estado_Tarea)
        {
            Add(estado_Tarea);

            return true;
        }

        bool IEstado_TareaRepository.UpdateEstado_Tarea(Estado_Tarea estado_Tarea)
        {
            Update(estado_Tarea);

            return true;
        }
    }
}