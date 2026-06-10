using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisUNAL.Api.Entities.Repositories
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAllUsuario();
        Usuario GetUsuarioDetails(int idusuario);
        Usuario GetUsuarioDetails(string correo);
        DataTableAdapter<Usuario> GetDataTableUsuario(DataTableRequest model);
        bool InsertUsuario(Usuario usuario);
        bool UpdateUsuario(Usuario usuario);
        bool DeleteUsuario(int idusuario);
        bool DesactivarUsuario(int idusuario);
        DatosUsuario UsuarioLogin(UsuarioLogin login);
        bool ValidarUsuarioLDAP(UsuarioLogin login);        
    }
}
