using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    public class KardexProducto
    {
        public int BienServicioId { get; set; }
        public string Codigo { get; set; }
        public string Color { get; set; }
        public string Descripcion { get; set; }
        public string Almacen { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Movimiento { get; set; }
        public string UnidadMedida { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal CantidadIngreso { get; set; }
        public decimal MontoIngreso { get; set; }
        public decimal CantidadSalida { get; set; }
        public decimal ValorSalida { get; set; }
        public decimal CantidadSaldo { get; set; }
        public decimal MontoSaldo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
