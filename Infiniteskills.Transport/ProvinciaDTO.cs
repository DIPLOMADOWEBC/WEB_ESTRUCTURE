﻿using System;
namespace Infiniteskills.Transport
{
    public class ProvinciaDTO
    {
        public int ProvinciaId { get; set; }
        public string Codigo { get; set; }
        public string DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DepartamentoDTO DepartamentoDTO { get; set; }
    }
}
