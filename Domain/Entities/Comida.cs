using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Comida
    {
        public Comida()
        {
            Ingredientes = new HashSet<Ingrediente>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? ImagenUrl { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaFinVigencia { get; set; }

        public virtual ICollection<Ingrediente> Ingredientes { get; set; }
    }
}
