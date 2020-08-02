using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Transport
{
    public class OrdenSaldoDTO
    {
        public int OrdenSaldoId { get; set; }

        public int AlmacenId { get; set; }
        public int BienServicioId { get; set; }
        public int PeriodoEmpresaId { get; set; }
        public int MesContableId { get; set; }
        public decimal CantidadAnterior { get; set; }
        public decimal ValorAnterio { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorUnitAnterior { get; set; }
        public decimal CantidadIngreso { get; set; }
        public decimal ValorIngreso { get; set; }
        public decimal CantidadSalida { get; set; }
        public decimal ValorSalida { get; set; }
        public decimal MontoSaldo { get; set; }
        public decimal CantidadReserva { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual BienServicioDTO BienServicioDTO { get; set; }
        public virtual PeriodoEmpresaDTO PeriodoEmpresaDTO { get; set; }
        public virtual AlmacenDTO AlmacenDTO { get; set; }
        public virtual MesContableDTO MesContableDTO { get; set; }
    }
}
