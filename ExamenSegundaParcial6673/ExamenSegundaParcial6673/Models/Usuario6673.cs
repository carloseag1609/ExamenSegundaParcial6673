using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ExamenSegundaParcial6673.Models
{
    public class Usuario6673
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public ObservableCollection<Cuenta6673> Cuentas { get; set; }
    }
}
