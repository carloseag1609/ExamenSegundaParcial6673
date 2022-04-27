using ExamenSegundaParcial6673.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExamenSegundaParcial6673.ViewModel
{
    internal class UsuarioViewModel6673 : BaseViewModel6673
    {
        #region Propiedades
        public Usuario6673 usuario;
        public Usuario6673 Usuario
        {
            get { return this.usuario; }
            set { this.Usuario = value; OnPropertyChanged(); }
        }
        #endregion

        #region Comandos
        public ICommand cmdRegistrarUsuario { get; set; }
        #endregion

        public UsuarioViewModel6673()
        {
            cmdRegistrarUsuario = new Command<Usuario6673>(async (usuario) => await PCmdRegistrarUsuario(usuario));
        }

        public async Task PCmdRegistrarUsuario(Usuario6673 _usuario)
        {
            usuario = _usuario;
        } 


    }
}
