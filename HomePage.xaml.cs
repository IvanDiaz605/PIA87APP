using PIAREGISTROALUMNOS.views.Acceso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PIAREGISTROALUMNOS.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            LblUsuario.Text = Preferences.Get("username", "default");
        }

        private void BtnAlumnoList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaEstudiantes());
        }
    }

}