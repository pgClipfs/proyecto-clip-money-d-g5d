using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class Movimiento
    {
        public Movimiento()
        {
            MovimientosXusuarios = new HashSet<MovimientosXusuario>();
        }

        public int IdMovimiento { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<MovimientosXusuario> MovimientosXusuarios { get; set; }
    }
}
