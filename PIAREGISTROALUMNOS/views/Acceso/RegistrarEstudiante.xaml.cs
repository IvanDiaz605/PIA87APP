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
    public partial class RegistrarEstudiante : ContentPage
    {
        StudentReository repository = new StudentReository();
        public RegistrarEstudiante()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string nombre = TxtNombre.Text;
            string apellidos = TxtApellidos.Text;
            string Matricula = TxtMatricula.Text;
            string carrera = TxtCarrera.Text;
            string califiacion = Txtcalificacion.Text;



            if (string.IsNullOrEmpty(nombre))
            {
                await DisplayAlert("ADVERTNECIA", "Por favor ingrese el nombre", "Cancelar");
            }
            if (string.IsNullOrEmpty(apellidos))
            {
                await DisplayAlert("ADVERTENCIA", "Por favor ingrese los apellidos", "Cancelar");
            }
            if (string.IsNullOrEmpty(carrera))
            {
                await DisplayAlert("ADVERTENCIA", "Por favor ingresar la carrera que cruza", "Cancelar");
            }
            if (string.IsNullOrEmpty(Matricula))
            {
                await DisplayAlert("ADVERTENCIA", "Por favor ingresa su matricula", "Cancelar");
            }
            if (string.IsNullOrEmpty(califiacion))
            {
                await DisplayAlert("ADVERTENCIA", "Por favor ingresa la calificacion del alumno", "Cancelar");
            }

            StudentModel student = new StudentModel();
            student.Nombre = nombre;
            student.Apellidos = apellidos;
            student.Carrera = carrera;
            student.Matricula = Matricula;
            student.Calificacion = califiacion;

            var isSaved = await repository.Save(student);
            if (isSaved)
            {
                await DisplayAlert("AVISO", "El alumno ha sido registrado.", "Ok");
                Clear();
            }
            else
            {
                await DisplayAlert("ERROR", "El alumno no se pudo registrar.", "Ok");
            }
        }

        public void Clear()
        {
            TxtNombre.Text = string.Empty;
            TxtApellidos.Text = string.Empty;
            TxtMatricula.Text = string.Empty;
            TxtCarrera.Text = string.Empty;
            Txtcalificacion.Text = string.Empty;

        }
    }
}