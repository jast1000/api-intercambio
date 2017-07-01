using System;

namespace IntercambioAPI.Models.DTO
{
    public class EstadoAsistenciaDTO : IntercambioDTO
    {
        public Nullable<bool> confirmacion { get; set; }

        public EstadoAsistenciaDTO() { }

        public EstadoAsistenciaDTO(Reglas regla): base(regla)
        {
        }
    }
}