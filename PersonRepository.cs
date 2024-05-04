using hchavezS5v2.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hchavezS5v2
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;

        public string statusMessage {  get; set; }

        public void Init()
        {
            if (conn is not null)
                return;
            conn=new(_dbPath);
            conn.CreateTable<Persona>();

        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        // En la clase PersonRepository

        public void AddNewPerson(string name)
        {
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido.");

                Persona person = new Persona { Name = name };
                int result = conn.Insert(person);
                statusMessage = $"Dato Agregado!! Resultado: {result}, Nombre: {name}";
            }
            catch (Exception ex)
            {
                statusMessage = $"Error: No se pudo insertar el dato. Nombre: {name}, Mensaje: {ex.Message}";
                throw; // Esto puede ser opcional, dependiendo de cómo manejes las excepciones
            }
        }


        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("error al mostrar datos. ", ex.Message);
                
                
            }
            return new List<Persona> ();
        }
        public void DeletePerson(Persona persona)
        {
            try
            {
                Init();
                int result = conn.Delete(persona);
                statusMessage = string.Format("Persona eliminada correctamente. ID: {0}, Nombre: {1}", persona.Id, persona.Name);
            }
            catch (Exception ex)
            {
                statusMessage = string.Format("Error al eliminar la persona. Nombre: {0}, Mensaje de error: {1}", persona.Name, ex.Message);
            }
        }

    }
}
