using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PIAREGISTROALUMNOS.views.Acceso
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaEstudiantes : ContentPage
    {
        StudentReository studentRepository = new StudentReository();
        public ListaEstudiantes()
        {
            InitializeComponent();
            AlumnoListView.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }

        protected override async void OnAppearing()
        {
            var alumnos = await studentRepository.GetAll();
            AlumnoListView.ItemsSource = null;
            AlumnoListView.ItemsSource = alumnos;
            AlumnoListView.IsRefreshing = false;
        }

        private void AddToolBarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrarEstudiante());
        }

        private void AlumnoListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }
            var studnet = e.Item as StudentModel;
            Navigation.PushModalAsync(new StudentDetails(studnet));
            ((ListView)sender).SelectedItem = null;
        }

        private async void EliminarTapp_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayAlert("AVISO", "¿Quieres eliminar este registro", "Si", "No");
            if (response)
            {
                string id = ((TappedEventArgs)e).Parameter.ToString();
                bool isDelete = await studentRepository.Delete(id);
                if (isDelete)
                {
                    await DisplayAlert("AVISO", "Alumno eliminado existosamente.", "Ok");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("ERROR", "El alumno no se pudo eliminar.", "Ok");
                }
            }
        }

        private async void EditarTap_Tapped(object sender, EventArgs e)
        {
            string id = ((TappedEventArgs)e).Parameter.ToString();
            var student = await studentRepository.GetById(id);
            if (student == null)
            {
                await DisplayAlert("AVISO", "Datos no encontrados.", "Ok");
            }
            student.Id = id;
            await Navigation.PushModalAsync(new Editareliminar(student));
        }

        private async void TxtBuscar_SearchButtonPressed(object sender, EventArgs e)
        {
            string searchValue = TxtBuscar.Text;
            if (!String.IsNullOrEmpty(searchValue))
            {
                var alumnos = await studentRepository.GetAllByName(searchValue);
                AlumnoListView.ItemsSource = null;
                AlumnoListView.ItemsSource = alumnos;
            }
            else
            {
                OnAppearing();
            }
        }

        private async void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchValue = TxtBuscar.Text;
            if (!String.IsNullOrEmpty(searchValue))
            {
                var alumnos = await studentRepository.GetAllByName(searchValue);
                AlumnoListView.ItemsSource = null;
                AlumnoListView.ItemsSource = alumnos;
            }
            else
            {
                OnAppearing();
            }
        }
    }
}