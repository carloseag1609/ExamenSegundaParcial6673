using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenSegundaParcial6673.Models
{
    public class Transaccion6673
    {
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
