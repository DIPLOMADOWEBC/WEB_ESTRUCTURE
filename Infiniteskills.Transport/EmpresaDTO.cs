using System;
using System.Collections.Generic;
using System.Text;

namespace Infiniteskills.Transport
{
    public class EmpresaDTO
    {
        public int EmpresaId { get; set; }
        public string RazonSocial { get; set; }
        public string NumeroRuc { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Igv { get; set; }
        public decimal Renta { get; set; }
        public byte[] Logo { get; set; }
        public string RutaXml { get; set; }
        public string RutaPdf { get; set; }
        public string RutaCrd { get; set; }
        public string RutaFirma { get; set; }
        public string ContrasenaFirma { get; set; }
        public string UsuarioCorreo { get; set; }
        public string AliasCorreo { get; set; }
        public string Correo { get; set; }
        public string ContrasenaCorreo { get; set; }
        public string ServerSmtp { get; set; }
        public string PuertoSmtp { get; set; }
        public bool SeguridadSsl { get; set; }
        public string UsuarioSunat { get; set; }
        public string ContrasenaSunat { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string EditAction { get; set; }
    }
}
