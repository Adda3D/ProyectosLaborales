using IrisUNAL.Api.Common.Supertype;
using IrisUNAL.Api.Data;
using IrisUNAL.Api.Models;
using IrisUNAL.Api.Models.TableModel;
using IrisUNAL.Api.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;

namespace IrisUNAL.Api.Entities.Repositories
{
    public class UsuarioRepository : SuperType<Usuario>, IUsuarioRepository
    {
        private ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UsuarioRepository()
        {
            _context = new ApplicationDbContext();
        }
        public bool DeleteUsuario(int id_usuario)
        {
            Delete(id_usuario);

            return true;
        }

        public bool DesactivarUsuario(int idusuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAllUsuario()
        {
            return Get();
        }

        public Usuario GetUsuarioDetails(int id_usuario)
        {
            return Get(id_usuario);
        }

        public Usuario GetUsuarioDetails(string correo)
        {
            return Get(c => c.correoinstitucional == correo).FirstOrDefault();
        }

        public bool InsertUsuario(Usuario usuario)
        {
            Add(usuario);

            return true;
        }

        public bool UpdateUsuario(Usuario usuario)
        {
            Update(usuario);

            return true;
        }


        public DatosUsuario UsuarioLogin(UsuarioLogin login)
        {
            DatosUsuario _datosusuario = new DatosUsuario();
            var usuario = GetUsuarioDetails(login.Usuario);

            if (usuario == null)
            {
                throw new Exception("Usuario Inexistente en IRIS");
            }

            if (!usuario.activo)
            {
                throw new Exception("Usuario Inactivo en IRIS");
            }
            if (ConfigurationManager.AppSettings["ValidarLDAP"] == "1")
            {
                ValidarUsuarioLDAP(login);
            }
            
            _datosusuario.idrol = usuario.idrol;
            _datosusuario.id_depend = usuario.id_depend;
            _datosusuario.id_usuario = usuario.id_usuario;
            _datosusuario.correoinstitucional = usuario.correoinstitucional;
            _datosusuario.nombrecompleto = usuario.nombrecompleto;

            using (var menurp = new MenuRepository())
            {
                var menu_usuario = menurp.GetMenuByRol(usuario.idrol);
                _datosusuario.menuusuario = menu_usuario;
            }

            return _datosusuario;
        }

        public bool ValidarUsuarioLDAP(UsuarioLogin login)
        {
            string sUsuario = login.Usuario;
            int posarroba = sUsuario.IndexOf('@');

            if (posarroba > -1)
            {
                sUsuario = sUsuario.Substring(0, posarroba);
            }

            string LDAPUsuario = "uid=" + sUsuario + ", ou=people,o=unal.edu.co";
            string sDominio = ConfigurationManager.AppSettings["dominioLDAP"];

            try
            {                
                using (LdapConnection ldapConnection = new LdapConnection(sDominio) { Timeout = TimeSpan.FromSeconds(5) })
                {
                    var networkCredential = new NetworkCredential(LDAPUsuario, login.Clave);
                    ldapConnection.SessionOptions.SecureSocketLayer = true;
                    ldapConnection.Credential = networkCredential;
                    ldapConnection.SessionOptions.VerifyServerCertificate += delegate { return true; }; // = new VerifyServerCertificateCallback(ServerCallback);
                    ldapConnection.SessionOptions.ProtocolVersion = 3;
                    ldapConnection.AuthType = AuthType.Basic;
                    ldapConnection.Bind(networkCredential);

                    return true;
                }
            }
            catch (Exception exc)
            {                
                if (exc.InnerException is LdapException)
                {
                    throw new Exception($"Error validando usuario LDAP {Environment.NewLine} Usuario {LDAPUsuario} Dominio {sDominio} {Environment.NewLine} {exc.Message} {Environment.NewLine}  Código Error {Environment.NewLine} {(exc as LdapException).ErrorCode}");                    
                }
                else
                {
                    throw new Exception($"Error Inesperado validando usuario LDAP {Environment.NewLine} Usuario {LDAPUsuario} Dominio {sDominio} {Environment.NewLine} {exc.Message}");
                }
            }

        }

        public DataTableAdapter<Usuario> GetDataTableUsuario(DataTableRequest model)
        {
            var totalRows = Count();
            var RowsFiltered = totalRows;

            Expression<Func<Usuario, bool>> srchByFunc = null;
            Expression<Func<Usuario, string>> orderByFunc = null;            

            Expression<Func<Usuario, object>> parameter1 = p => p.ObjDependencia;
            Expression<Func<Usuario, object>> parameter2 = p => p.ObjRol;
            Expression<Func<Usuario, object>>[] parameterArray = new Expression<Func<Usuario, object>>[] { parameter1, parameter2 };

            bool isOrderDesc = false;

            if (model.SearchValue != null && model.SearchValue != "")
            {
                srchByFunc = u => u.nombrecompleto.ToLower().Contains(model.SearchValue.ToLower()) || u.correoinstitucional.ToLower().Contains(model.SearchValue.ToLower());
                RowsFiltered = CountFiltered(srchByFunc);
            }

            isOrderDesc = model.SortColumnDir == "asc" ? false : true;

            orderByFunc = CreateExpressionOrderBy<Usuario>(model.SortColumn);

            var data = GetExpressions(model.Skip, model.PageSize, srchByFunc, orderByFunc, isOrderDesc, parameterArray).ToList();                            

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Usuario> result = new DataTableAdapter<Usuario>();

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