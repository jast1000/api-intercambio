using IntercambioAPI.Models.DTO;
using System;

namespace IntercambioAPI.Models.DTO
{
    public class PerfilUsuarioDTO
    {
        public string idParticipante { get; set; }
        public string nombres { get; set; }
        public Nullable<int> edad { get; set; }
        public string sexo { get; set; }
        public string grado { get; set; }
        public string grupo { get; set; }
        public string area { get; set; }
        public string gustos { get; set; }
        public string opcionesIntercambio { get; set; }
        public string usuario { get; set; }

        public PerfilUsuarioDTO() { }

        public PerfilUsuarioDTO(Participantes participante)
        {
            this.idParticipante = participante.IdPart;
            this.nombres = participante.Nombre;
            this.edad = participante.Edad;
            this.sexo = participante.Sexo;
            this.grado = participante.Grado;
            this.grupo = participante.Grupo;
            this.area = participante.Area;
            this.gustos = participante.Gustos;
            this.opcionesIntercambio = participante.OpcionesIntercambio;
            this.usuario = participante.IdUsuario;
        }
    }
}

namespace IntercambioAPI.Models
{
    partial class Participantes
    {
        public Participantes(PerfilUsuarioDTO perfil)
        {
            this.IdPart = perfil.idParticipante;
            this.Nombre = perfil.nombres;
            this.Edad = perfil.edad;
            this.Sexo = perfil.sexo;
            this.Grado = perfil.grado;
            this.Grupo = perfil.grupo;
            this.Area = perfil.area;
            this.Gustos = perfil.gustos;
            this.OpcionesIntercambio = perfil.opcionesIntercambio;
            this.IdUsuario = perfil.usuario;
        }
    }
}