﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categorias.Application.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string DescripcionCorta { get; set; }

        public string DescripcionLarga { get; set; }


        public int CodigoEstado { get; set; }


        public int Orden { get; set; }

        public string Icono { get; set; }

        public string User { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string Codigo { get; set; }
    }
}
