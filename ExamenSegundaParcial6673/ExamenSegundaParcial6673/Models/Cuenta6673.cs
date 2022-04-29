using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExamenSegundaParcial6673.Models
{
    public class Cuenta6673
    {
        public string Nombre { get; set; }
        public int NumeroCuenta { get; set; }
        public int Saldo { get; set; }
        public ObservableCollection<Transaccion6673> Transacciones { get; set; }
    }
}
