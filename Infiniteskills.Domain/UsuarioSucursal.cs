using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Domain
{
    public class UsuarioSucursal
    {
        public int EmpresaId { get; set; }
        public string NombreEmpresa { get; set; }
        public int SucursalId { get; set; }
        public string NombreSucursal { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombres { get; set; }
        public int AlmacenId { get; set; }
        public string NombreAlmacen { get; set; }
        public int PeriodoEmpresaId { get; set; }
        public int PeriodoNombre { get; set; }
        public int PeriodoId { get; set; }
    }
}
