using System;
using System.Collections.Generic;

namespace Infiniteskills.Transport { 
    public class ProveedorDTO
    {

        public int ProveedorId { get; set; }
        public int? MonedaId { get; set; }
        public int PersonalId { get; set; }
        public string RazonSocial { get; set; }
        public string Nombres { get; set; }
        public int TipoProveedorId { get; set; }
        public int DocumentoIdentidadId { get; set; }
        public string NumeroDocumento { get; set; }
        public int DistritoId { get; set; }
        public string TipoCliente { get; set; }
        public int? FormaVentaId { get; set; }
        public int? TipoPrecioId { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string CorreoUno { get; set; }
        public string CorreoDos { get; set; }
        public string PaginaWeb { get; set; }
        public string NombreDireccion { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string EditAction { get; set; }
        public virtual DistritoDTO DistritoDTO { get; set; }
        public virtual DocumentoIdentidadDTO DocumentoIdentidadDTO { get; set; }
        public virtual TipoProveedorDTO TipoProveedorDTO { get; set; }
        public virtual FormaVentaDTO FormaVentaDTO { get; set; }
        public virtual PersonalDTO PersonalDTO { get; set; }
        public virtual MonedaDTO MonedaDTO { get; set; }
        public virtual TipoPrecioDTO TipoPrecioDTO { get; set; }
        public virtual DireccionProveedorDTO DireccionDTO { get; set; }

        //Direccion
        public  List<DireccionProveedorDTO> DireccionDTOList { get; set; }
        public  List<ContactoDTO> ContactoDTOList { get; set; }
 
    }
}
