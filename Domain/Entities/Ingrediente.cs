using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            Comida = new HashSet<Comida>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? ImagenUrl { get; set; }
        public DateTime? FechaFinVigencia { get; set; }

        public virtual ICollection<Comida> Comida { get; set; }
    }
}