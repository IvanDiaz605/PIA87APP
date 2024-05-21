using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIAREGISTROALUMNOS.views.Acceso
{
    class StudentReository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://xamarinfirebase-b9036-default-rtdb.firebaseio.com/");

        public async Task<bool> Save(StudentModel student)
        {
            var data = await firebaseClient.Child(nameof(StudentModel)).PostAsync(JsonConvert.SerializeObject(student));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<StudentModel>> GetAll()
        {
            return (await firebaseClient.Child(nameof(StudentModel)).OnceAsync<StudentModel>()).Select(item => new StudentModel
            {
                Nombre = item.Object.Nombre,
                Apellidos = item.Object.Apellidos,
                Matricula = item.Object.Matricula,
                Carrera = item.Object.Carrera,
                Calificacion = item.Object.Calificacion,
                Id = item.Key
            }).ToList();
        }

        public async Task<List<StudentModel>> GetAllByName(string name)
        {
            return (await firebaseClient.Child(nameof(StudentModel)).OnceAsync<StudentModel>()).Select(item => new StudentModel
            {
                Nombre = item.Object.Nombre,
                Apellidos = item.Object.Apellidos,
                Matricula = item.Object.Matricula,
                Carrera = item.Object.Carrera,
                Calificacion = item.Object.Calificacion,
                Id = item.Key
            }).Where(c => c.Nombre.ToLower().Contains(name.ToLower())).ToList();
        }

        public async Task<StudentModel> GetById(string id)
        {
            return (await firebaseClient.Child(nameof(StudentModel) + "/" + id).OnceSingleAsync<StudentModel>());
        }

        public async Task<bool> Update(StudentModel student)
        {
            await firebaseClient.Child(nameof(StudentModel) + "/" + student.Id).PutAsync(JsonConvert.SerializeObject(student));
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            await firebaseClient.Child(nameof(StudentModel) + "/" + id).DeleteAsync();
            return true;
        }
    }
}
