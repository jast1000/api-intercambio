using IntercambioAPI.Models.DTO;
using System;

namespace IntercambioAPI.Models.DTO
{
    public class IntercambioDTO
    {
        public int idRegla { get; set; }
        public string lugar { get; set; }
        public DateTime fecha { get; set; }
        public Nullable<double> monto { get; set; }
        public Nullable<short> estado { get; set; }

        public IntercambioDTO() { }

        public IntercambioDTO(Reglas regla) {
            this.idRegla = regla.IdRegla;
            this.lugar = regla.Lugar;
            this.fecha = regla.Fecha.Value;
            this.monto = regla.Monto;
        }
    }
}

namespace IntercambioAPI.Models
{
    partial class Reglas
    {
        public Reglas(IntercambioDTO intercambio)
        {
            this.IdRegla = intercambio.idRegla;
            this.Fecha = intercambio.fecha;
            this.Lugar = intercambio.lugar;
            this.Monto = intercambio.monto;
        }

        public Reglas() { }
    }
}