using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class DecVie_RadicadorTecRepository : SuperType<DecVie_RadicadorTec>, IDecVie_RadicadorTecRepository
    {
        private ApplicationDbContext _context;

        public DecVie_RadicadorTecRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_RadicadorTecRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteDecVie_RadicadorTec(int id_decvieradicadortec)
        {
            Delete(id_decvieradicadortec);
            return true;
        }

        public IEnumerable<DecVie_RadicadorTec> GetAllDecVie_RadicadorTec()
        {
            return Get();
        }

        public DecVie_RadicadorTec GetDecVie_RadicadorTecDetails(int id_decvieradicadortec)
        {
            return Get(id_decvieradicadortec);
        }

        public DecVie_RadicadorTec GetDecVie_RadicadorTecNumero(string cd_numradicadortec)
        {
            return Get(c => c.numradicadortec == cd_numradicadortec).FirstOrDefault();
        }

        public bool InsertDecVie_RadicadorTec(DecVie_RadicadorTec decVie_RadicadorTec)
        {
            Add(decVie_RadicadorTec);
            return true;
        }

        public bool UpdateDecVie_RadicadorTec(DecVie_RadicadorTec decVie_RadicadorTec)
        {
            Update(decVie_RadicadorTec);
            return true;
        }

        public DataTableAdapter<DecVie_RadicadorTec> GetDataTableDecVie_RadicadorTec(DataTableRequest model)
        {
            var data = _context.decvie_radicadortec.Take(20).ToList(); // Trae los primeros 10 registros sin filtros ni orden

            return new DataTableAdapter<DecVie_RadicadorTec>
            {
                Draw = model.draw,
                RecordsTotal = data.Count, // Usa el conteo de los datos obtenidos
                RecordsFiltered = data.Count,
                Data = data
            };
        }

        public DataTableAdapter<DecVie_RadicadorTecDTO> GetDataTableDecVie_RadicadorTecPrueba(DataTableRequest model)
        {
            return GetDataTableDecVie_RadicadorTecPrueba(model, null); // Llama al otro con idfuncionario = null
        }


        public DataTableAdapter<DecVie_RadicadorTecDTO> GetDataTableDecVie_RadicadorTecPrueba(DataTableRequest model, int? idfuncionario)

        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

           // IQueryable<DecVie_RadicadorTec> query = _context.decvie_radicadortec;
            IQueryable<DecVie_RadicadorTec> query = _context.decvie_radicadortec.Include("ObjDependenciaDestino");
            // 🔽 Aplicar filtro por funcionario si se proporciona
            if (idfuncionario.HasValue)
            {
                query = query.Where(d => d.idfuncionario == idfuncionario.Value);
            }

            // Filtro de búsqueda por columnas específicas
            if (!string.IsNullOrEmpty(model.SearchValue))
            {
                query = query.Where(d =>
                    d.numradicadortec.ToLower().Contains(model.SearchValue.ToLower()) || // Radicado
                    d.asunto.ToLower().Contains(model.SearchValue.ToLower()) ||         // Asunto
                    d.tsersubserdocu.ToLower().Contains(model.SearchValue.ToLower())   // Solicitante
                );
                RowsFiltered = query.Count();
            }

            // Orden dinámico basado en la columna seleccionada
            if (!string.IsNullOrEmpty(model.SortColumn))
            {
                switch (model.SortColumn.ToLower())
                {
                    case "fecha":
                        query = model.SortColumnDir == "desc" ? query.OrderByDescending(d => d.fecha) : query.OrderBy(d => d.fecha);
                        break;
                    case "numradicadortec":
                        query = model.SortColumnDir == "desc" ? query.OrderByDescending(d => d.numradicadortec) : query.OrderBy(d => d.numradicadortec);
                        break;
                    case "asunto":
                        query = model.SortColumnDir == "desc" ? query.OrderByDescending(d => d.asunto) : query.OrderBy(d => d.asunto);
                        break;
                    default:
                        query = query.OrderByDescending(d => d.fecha); // Orden por defecto: más reciente primero
                        break;
                }
            }

            // Aplicar paginación
            query = query.Skip(model.Skip).Take(model.PageSize);

            var data = query.Select(d => new DecVie_RadicadorTecDTO
            {
                id_decvieradicadortec = d.id_decvieradicadortec,
                fecha = d.fecha,
                numradicadortec = d.numradicadortec,
                asunto = d.asunto,
                tsersubserdocu = d.tsersubserdocu,
                usuariocreacion = d.usuariocreacion,
                NombreDependencia = d.ObjDependenciaDestino != null ? d.ObjDependenciaDestino.nmdepend : "No asignada",
                id_decviemacroproceso = d.id_decviemacroproceso,
                // (agregar también fecha_vencimiento si aún no lo pusiste)
                fecha_vencimiento = d.fecha_vencimiento
            }).ToList();

            // Construir el resultado
            DataTableAdapter<DecVie_RadicadorTecDTO> result = new DataTableAdapter<DecVie_RadicadorTecDTO>
            {
                Data = data,
                Draw = model.draw,
                RecordsTotal = totalRows,
                RecordsFiltered = RowsFiltered
            };

            return result;
        }

        public DecVie_RadicadorTec GetRadicadorTecWithRelations(int id_decvieradicadortec)
        {
            return _context.decvie_radicadortec
                .Include("ObjDependencia")
                .Include("Objprefijo")
                .Include("ObjDependenciaDestino")
                .FirstOrDefault(d => d.id_decvieradicadortec == id_decvieradicadortec);
        }


        public DecVie_RadicadorTec InsertDecVie_RadicadorTec_Data(DecVie_RadicadorTec decVie_RadicadorTec)
        {
            return Add(decVie_RadicadorTec);
        }

        public DecVie_RadicadorTec UpdateDecVie_RadicadorTec_Data(DecVie_RadicadorTec decVie_RadicadorTec)
        {
            return Update(decVie_RadicadorTec);
        }
    }
}
