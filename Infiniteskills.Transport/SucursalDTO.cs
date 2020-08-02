using System;
using System.Collections.Generic;
using System.Text;

namespace Infiniteskills.Transport
{
    public class SucursalDTO
    {
        public int SucursalId { get; set; }
        public int EmpresaId { get; set; }
        public int DistritoId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Capacidad { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public virtual EmpresaDTO EmpresaDTO { get; set; }
        public virtual DistritoDTO DistritoDTO { get; set; }
        public string EditAction { get; set; }
    }
}
