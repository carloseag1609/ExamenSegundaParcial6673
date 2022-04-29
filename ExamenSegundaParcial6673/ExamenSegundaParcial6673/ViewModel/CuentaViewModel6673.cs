using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExamenSegundaParcial6673.Models;
using Xamarin.Forms;

namespace ExamenSegundaParcial6673.ViewModel
{
    public class CuentaViewModel6673 : BaseViewModel6673
    {
        #region Propiedades
        public ObservableCollection<Cuenta6673> Cuentas { get; set; }

        public Cuenta6673 cuenta;
        public Cuenta6673 Cuenta
        {
            get { return this.cuenta; }
            set { this.cuenta = value; OnPropertyChanged(); }
        }
        #endregion

        #region Comandos
        public ICommand cmdAgregarCuenta { get; set; }
        public ICommand cmdDepositoCuenta { get; set; }
        public ICommand cmdRetiroCuenta { get; set; }
        #endregion

        public CuentaViewModel6673()
        {
            Cuentas = new ObservableCollection<Cuenta6673>();
            Cuentas.Add(new Cuenta6673()
            {
                NumeroCuenta = 1,
                Nombre = "Ahorro",
                Saldo = 0
            });
            Cuentas.Add(new Cuenta6673() 
            {
                NumeroCuenta = 2,
                Nombre = "Gasto Diario",
                Saldo = 350
            });

            cmdAgregarCuenta = new Command(async () => await PCmdAgregarCuenta());
            cmdDepositoCuenta = new Command<int>(async (valor) => await PCmdDepositoCuenta(valor));
        }

        public async Task PCmdAgregarCuenta()
        {
            Cuentas.Add(cuenta);
            OnPropertyChanged();
        }

        public async Task PCmdDepositoCuenta(int valor)
        {
            int indice = -1;
            Cuenta6673 tmpCuenta = Cuentas.FirstOrDefault((item) => item.NumeroCuenta == Cuenta.NumeroCuenta);
            if (tmpCuenta != null)
            {
                indice = Cuentas.IndexOf(tmpCuenta);
                Cuentas[indice].Saldo = valor;
            }
            OnPropertyChanged();
        }
    }
}
