﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntercambioAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class intercambioEntities : DbContext
    {
        public intercambioEntities()
            : base("name=intercambioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Asistencia> Asistencia { get; set; }
        public virtual DbSet<Participantes> Participantes { get; set; }
        public virtual DbSet<plantilla_correo> plantilla_correo { get; set; }
        public virtual DbSet<Reglas> Reglas { get; set; }
        public virtual DbSet<Sorteo> Sorteo { get; set; }
        public virtual DbSet<Sugerencias> Sugerencias { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
