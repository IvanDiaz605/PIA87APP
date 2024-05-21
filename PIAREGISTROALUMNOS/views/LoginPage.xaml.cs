using PIAREGISTROALUMNOS.views.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PIAREGISTROALUMNOS.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string username = Txtusuario.Text;
            string contrasena = Txtcontraseña.Text;

            if (IsvalidDato(username, contrasena))
            {
                await DisplayAlert("BIEN", "INICIO EXITOSO", "OK");

                await Navigation.PushAsync(new ListaEstudiantes());
            }
            else
            {
                await DisplayAlert("ERROR", "DATOS INCORRECTOS", "OK");
            }
        }

        private bool IsvalidDato(string username, string password)
        {
            return username == "Admin" && password == "1234";
        }
    }
}