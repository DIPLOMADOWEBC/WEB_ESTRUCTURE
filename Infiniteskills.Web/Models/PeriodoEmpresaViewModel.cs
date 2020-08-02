using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infiniteskills.Web.Models
{
    public class PeriodoEmpresaViewModel
    {
        public PeriodoEmpresaViewModel()
        {
            empresaList = new List<SelectListItem>();
            sucursalList = new List<SelectListItem>();
            almacenList = new List<SelectListItem>();
            periodoList = new List<SelectListItem>();
        }
        [Required(ErrorMessage = "Seleccione empresa")]
        public int EmpresaId { get; set; }
        public string NombreEmpresa { get; set; }

        [Required(ErrorMessage = "Seleccione sucursal")]
        public int SucursalId { get; set; }
        public string NombreSucursal { get; set; }
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Seleccione Almacen")]
        public int AlmacenId { get; set; }

        [Required(ErrorMessage = "Seleccione periodo")]
        public int PeriodoId { get; set; }
        public string NombreAlmacen { get; set; }

        public List<SelectListItem> empresaList { get; set; }
        public List<SelectListItem> sucursalList { get; set; }
        public List<SelectListItem> almacenList { get; set; }

        public List<SelectListItem> periodoList { get; set; }
    }
}