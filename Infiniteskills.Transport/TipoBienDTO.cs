﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Transport
{
    public class TipoBienDTO
    {
        public int TipoBienId { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
