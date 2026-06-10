using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class Publicaciones_DepositoControlIngresoVentasRepository : SuperType<Publicaciones_DepositoControlIngresoVentas>, IPublicaciones_DepositoControlIngresoVentasRepository
    {
        private ApplicationDbContext _context;

        public Publicaciones_DepositoControlIngresoVentasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Publicaciones_DepositoControlIngresoVentasRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeletePublicaciones_DepositoControlIngresoVentas(int id_ingresoventas)
        {
            Delete(id_ingresoventas);
            return true;
        }

        public IEnumerable<Publicaciones_DepositoControlIngresoVentas> GetAllPublicaciones_DepositoControlIngresoVentas()
        {
            return Get();
        }

        public Publicaciones_DepositoControlIngresoVentas GetPublicaciones_DepositoControlIngresoVentasDetails(int id_ingresoventas)
        {
            return Get(id_ingresoventas);

        }

        public bool InsertPublicaciones_DepositoControlIngresoVentas(Publicaciones_DepositoControlIngresoVentas publicaciones_DepositoControlIngresoVentas)
        {
            Add(publicaciones_DepositoControlIngresoVentas);
            return true;
        }

        public bool UpdatePublicaciones_DepositoControlIngresoVentas(Publicaciones_DepositoControlIngresoVentas publicaciones_DepositoControlIngresoVentas)
        {
            Update(publicaciones_DepositoControlIngresoVentas);
            return true;
        }
    }
}