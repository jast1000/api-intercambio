using IntercambioAPI.Models.DTO;
using System;

namespace IntercambioAPI.Models.DTO
{
    public class UsuarioDTO
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public Nullable<int> tipoUsuario { get; set; }

        public UsuarioDTO() { }

        public UsuarioDTO(Usuarios u)
        {
            this.usuario = u.IdUsuario;
            this.password = u.Password;
            this.tipoUsuario = u.TipoUsuario;
        }
    }
}

namespace IntercambioAPI.Models
{
    public partial class Usuarios
    {
        public Usuarios(UsuarioDTO usuario)
        {
            this.IdUsuario = usuario.usuario;
            this.Password = usuario.password;
            this.TipoUsuario = usuario.tipoUsuario;
        }
    }
}

