using ExamenSegundaParcial6673.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenSegundaParcial6673
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new RegistroUsuario6673());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
