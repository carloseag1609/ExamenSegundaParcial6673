using ExamenSegundaParcial6673.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenSegundaParcial6673.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarCuenta6673 : ContentPage
    {
        public AgregarCuenta6673(UsuarioViewModel6673 vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}