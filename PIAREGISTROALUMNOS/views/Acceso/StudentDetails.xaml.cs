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
    public partial class StudentDetails : ContentPage
    {
        public StudentDetails(StudentModel student)
        {
            InitializeComponent();
            LabelNombre.Text = student.Nombre;
            LabelApellidos.Text = student.Apellidos;
            LabelMatricula.Text = student.Matricula;
            LabelCarrera.Text = student.Carrera;
            LabelCalificacion.Text = student.Calificacion;
        }
    }
}