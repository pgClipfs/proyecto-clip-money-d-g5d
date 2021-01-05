using System;
using System.Collections.Generic;

#nullable disable

namespace ClipMoney.Entities
{
    public partial class MovimientosXusuario
    {
        public int Id { get; set; }
        public int IdMovimiento { get; set; }
        public decimal Monto { get; set; }
        public int IdCuenta { get; set; }
        public int IdCuentaDestino { get; set; }

        public virtual Cuentum IdCuentaDestinoNavigation { get; set; }
        public virtual Cuentum IdCuentaNavigation { get; set; }
        public virtual Movimiento IdMovimientoNavigation { get; set; }
    }
}
