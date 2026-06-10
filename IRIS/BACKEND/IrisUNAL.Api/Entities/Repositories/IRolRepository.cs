using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IRolRepository
    {
        IEnumerable<Rol> GetAllRol();
        Rol GetRolDetails(int id_rol);
        IEnumerable<Rol> GetRolNombre(string cd_nombre);
        bool InsertRol(Rol rol);
        bool UpdateRol(Rol rol);
        bool DeleteRol(int id_rol);
        DataTableAdapter<Rol> GetDataTableRol(DataTableRequest model);        
    }
}
