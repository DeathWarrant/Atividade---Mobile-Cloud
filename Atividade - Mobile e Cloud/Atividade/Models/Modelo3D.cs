using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atividade.Models
{
    public class Modelo3D
    {
        public int Modelo3DID { get; set; }
        public string Nome { get; set; }
        public string Historia { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public int NumeroDePoligonos { get; set; }

        // --------------------------------------//
        public int TipoModelo3DID { get; set; }
        public virtual TipoModelo3D _TipoModelo3D { get; set; }
    }
}