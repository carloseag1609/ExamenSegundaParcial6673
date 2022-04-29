using ExamenSegundaParcial6673.Models;
using ExamenSegundaParcial6673.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExamenSegundaParcial6673.ViewModel
{
    public class UsuarioViewModel6673 : BaseViewModel6673
    {
        #region Propiedades
        public ObservableCollection<Cuenta6673> Cuentas { get; set; }
        public Cuenta6673 cuenta { get; set; }
        public Cuenta6673 Cuenta {  get { return cuenta; } set { cuenta = value; OnPropertyChanged(); } }
        public int nuevaCantidad = 0;
        public int NuevaCantidad { get { return nuevaCantidad; } set { nuevaCantidad = value; OnPropertyChanged(); } }
        public int nuevoSaldo;
        public int NuevoSaldo { get { return nuevoSaldo; } set { nuevoSaldo = value; OnPropertyChanged(); } }
        public string cuentaNombre;
        public string CuentaNombre { get { return cuentaNombre; } set { cuentaNombre = value; OnPropertyChanged(); } }
        public int cuentaSaldo;
        public int CuentaSaldo { get { return cuentaSaldo; } set { cuentaSaldo = value; OnPropertyChanged(); } }
        public bool esAbono;
        public bool EsAbono { get { return esAbono; } set { esAbono = value; OnPropertyChanged(); } }
        public string nombre = "Carlos";
        public string Nombre { get { return nombre; } set { nombre = value; OnPropertyChanged(); } }
        public string apellidoPaterno = "Aguirre";
        public string ApellidoPaterno { get { return apellidoPaterno; } set { apellidoPaterno = value; OnPropertyChanged(); } }
        public string apellidoMaterno = "Garcia";
        public string ApellidoMaterno { get { return apellidoMaterno; } set { apellidoMaterno = value; OnPropertyChanged(); } }
        public string telefono = "3121348172";
        public string Telefono { get { return telefono; } set { telefono = value; OnPropertyChanged(); } }
        public Usuario6673 usuario { get; set; }
        public Usuario6673 Usuario { get { return usuario; } set { usuario = value; OnPropertyChanged(); } }
        #endregion

        #region Comandos
        public ICommand cmdRegistrarUsuario { get; set; }
        public ICommand cmdCuentaDetalle { get; set; }
        public ICommand cmdIrAbonar { get; set; }
        public ICommand cmdIrRetirar { get; set; }
        public ICommand cmdIrAgregarCuenta { get; set; }
        public ICommand cmdAgregarCuenta { get; set; }
        public ICommand cmdAbonarCuenta { get; set; }
        public ICommand cmdRetirarCuenta { get; set; }
        #endregion

        public UsuarioViewModel6673()
        {
            Cuentas = new ObservableCollection<Cuenta6673>();
            Cuentas.Add(new Cuenta6673()
            {
                NumeroCuenta = 1,
                Nombre = "Cuenta uno",
                Saldo = 100,
                Transacciones = new ObservableCollection<Models.Transaccion6673>()
            });
            Cuentas.Add(new Cuenta6673()
            {
                NumeroCuenta = 2,
                Nombre = "Cuenta dos",
                Saldo = 200,
                Transacciones = new ObservableCollection<Models.Transaccion6673>()
            });
            cmdRegistrarUsuario = new Command(async () => await PCmdRegistrarUsuario());
            cmdCuentaDetalle = new Command<Cuenta6673>(async (cuenta) => await PCmdCuentaDetalle(cuenta));
            cmdIrAbonar = new Command(async () => await PCmdIrAbonar());
            cmdIrRetirar = new Command(async () => await PCmdIrRetirar());
            cmdIrAgregarCuenta= new Command(async () => await PCmdIrAgregarCuenta());
            cmdAgregarCuenta= new Command(async () => await PCmdAgregarCuenta());
            cmdAbonarCuenta = new Command(async () => await PCmdAbonarCuenta());
            cmdRetirarCuenta = new Command(async () => await PCmdRetirarCuenta());

        }

        public async Task PCmdRegistrarUsuario()
        {
            Usuario = new Usuario6673()
            {
                Nombre = nombre,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = ApellidoMaterno,
                Telefono = telefono,
                Cuentas = Cuentas
            };
            OnPropertyChanged();
            await Application.Current.MainPage.Navigation.PushAsync(new Cuentas6673(this));
        }

        public async Task PCmdCuentaDetalle(Cuenta6673 _cuenta)
        {
            cuenta = _cuenta;
            OnPropertyChanged();
            await Application.Current.MainPage.Navigation.PushAsync(new CuentaDetalle6673(this));
        }

        public async Task PCmdIrAbonar()
        {
            esAbono = true;
            OnPropertyChanged();
            await Application.Current.MainPage.Navigation.PushAsync(new Views.Abonar6673(this));
        }

        public async Task PCmdIrRetirar()
        {
            esAbono = false;
            OnPropertyChanged();
            await Application.Current.MainPage.Navigation.PushAsync(new Views.Retirar6673(this));
        }

        public async Task PCmdIrAgregarCuenta()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Views.AgregarCuenta6673(this));
        }

        public async Task PCmdAgregarCuenta()
        {
            Cuentas.Add(new Cuenta6673()
            {
                Nombre = cuentaNombre,
                Saldo = cuentaSaldo,
                NumeroCuenta = Cuentas.Count + 1,
                Transacciones = new ObservableCollection<Transaccion6673>()
            });
            OnPropertyChanged();
            await Application.Current.MainPage.Navigation.PushAsync(new Cuentas6673(this));
        }

        public async Task PCmdAbonarCuenta()
        {
            int indice = -1;
            Cuenta6673 tmpCuenta = Cuentas.FirstOrDefault((item) => item.NumeroCuenta == Cuenta.NumeroCuenta);
            if (tmpCuenta != null)
            {
                indice = Cuentas.IndexOf(tmpCuenta);
                Cuentas[indice].Transacciones.Add(new Transaccion6673()
                {
                    Cantidad = NuevaCantidad,
                    Fecha = DateTime.Now,
                    Tipo = "Abono"
                });
                Cuentas[indice].Saldo += NuevaCantidad;
                NuevaCantidad = 0;
                OnPropertyChanged();
            }
            await Application.Current.MainPage.Navigation.PushAsync(new CuentaDetalle6673(this));

        }
        public async Task PCmdRetirarCuenta()
        {
            int indice = -1;
            Cuenta6673 tmpCuenta = Cuentas.FirstOrDefault((item) => item.NumeroCuenta == Cuenta.NumeroCuenta);
            if (tmpCuenta != null)
            {
                indice = Cuentas.IndexOf(tmpCuenta);
                Cuentas[indice].Transacciones.Add(new Transaccion6673()
                {
                    Cantidad = NuevaCantidad,
                    Fecha = DateTime.Now,
                    Tipo = "Retiro"
                });
                if(NuevaCantidad < Cuentas[indice].Saldo)
                {
                    Cuentas[indice].Saldo -= NuevaCantidad;
                    NuevaCantidad = 0;
                }
                OnPropertyChanged();
            }
            await Application.Current.MainPage.Navigation.PushAsync(new CuentaDetalle6673(this));
        }
    }
}
