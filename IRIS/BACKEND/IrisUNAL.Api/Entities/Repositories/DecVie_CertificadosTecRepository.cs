using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.DTO;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IrisUNAL.Api.Entities.Repositories { 
    public class DecVie_CertificadosTecRepository : SuperType<DecVie_CertificadosTec>, IDecVie_CertificadosTecRepository
    {
        private ApplicationDbContext _context;

        public DecVie_CertificadosTecRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DecVie_CertificadosTecRepository()
        {
            _context = new ApplicationDbContext();
        }

        public bool DeleteDecVie_CertificadosTec(int id_decviecertificadostec)
        {
            Delete(id_decviecertificadostec);
            return true;
        }

        public IEnumerable<DecVie_CertificadosTec> GetAllDecVie_CertificadosTec()
        {
            return Get();
        }

        public DecVie_CertificadosTec GetDecVie_CertificadosTecDetails(int id_decviecertificadostec)
        {
            return Get(id_decviecertificadostec);
        }

        public DecVie_CertificadosTec GetCertificadosTecWithRelations(int id_decviecertificadostec)
        {
            return _context.decvie_certificadostec
                .Include("ObjDependencia")
                .Include("Objprefijo")
                .Include("ObjDependenciaDestino")
                .FirstOrDefault(d => d.id_decviecertificadostec == id_decviecertificadostec);
        }

        public bool InsertDecVie_CertificadosTec(DecVie_CertificadosTec certificadosTec)
        {
            Add(certificadosTec);
            return true;
        }

        public bool UpdateDecVie_CertificadosTec(DecVie_CertificadosTec certificadosTec)
        {
            Update(certificadosTec);
            return true;
        }

        public DataTableAdapter<DecVie_CertificadosTec> GetDataTableDecVie_CertificadosTec(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            IQueryable<DecVie_CertificadosTec> query = _context.decvie_certificadostec;

            // Apply search filter
            if (!string.IsNullOrEmpty(model.SearchValue))
            {
                query = query.Where(d =>
                    d.numcertificadotec.ToLower().Contains(model.SearchValue.ToLower()) ||
                    d.asunto.ToLower().Contains(model.SearchValue.ToLower()) ||
                    d.tsersubserdocu.ToLower().Contains(model.SearchValue.ToLower())
                );
                RowsFiltered = query.Count();
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(model.SortColumn))
            {
                switch (model.SortColumn.ToLower())
                {
                    case "fecha":
                        query = model.SortColumnDir == "desc" ? query.OrderByDescending(d => d.fecha) : query.OrderBy(d => d.fecha);
                        break;
                    case "numcertificadotec":
                        query = model.SortColumnDir == "desc" ? query.OrderByDescending(d => d.numcertificadotec) : query.OrderBy(d => d.numcertificadotec);
                        break;
                    case "asunto":
                        query = model.SortColumnDir == "desc" ? query.OrderByDescending(d => d.asunto) : query.OrderBy(d => d.asunto);
                        break;
                    default:
                        query = query.OrderBy(d => d.id_decviecertificadostec);
                        break;
                }
            }

            // Apply pagination
            query = query.Skip(model.Skip).Take(model.PageSize);

            // Fetch data
            var data = query.ToList();

            // Create the result
            return new DataTableAdapter<DecVie_CertificadosTec>
            {
                Data = data,
                Draw = model.draw,
                RecordsTotal = totalRows,
                RecordsFiltered = RowsFiltered
            };
        }


        public DecVie_CertificadosTec GetDecVie_CertificadosTecNumero(string cd_numcertificado)
        {
            return _context.decvie_certificadostec
                .FirstOrDefault(d => d.numcertificadotec == cd_numcertificado);
        }



        public DecVie_CertificadosTec InsertDecVie_CertificadosTec_Data(DecVie_CertificadosTec certificadosTec)
        {
            return Add(certificadosTec);
        }

        public DecVie_CertificadosTec UpdateDecVie_CertificadosTec_Data(DecVie_CertificadosTec certificadosTec)
        {
            return Update(certificadosTec);
        }
    }
}
