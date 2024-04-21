using System.Text.Json;
using LMS.Library.Models;

namespace LMS.API.Database
{
    public class Filebase
    {
        private string _root;
        private string _personRoot;
        private static Filebase? _instance;

        public static Filebase Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = @"C:\temp";
            _personRoot = $"{_root}\\Persons";
        }

        private int LastPersonId => People.Any() ? People.Select(p => p.Id).Max() : 0;

        public Person AddOrUpdate(Person p)
        {
            // Set up a new Id if one doesn't already exist
            if (p.Id <= 0)
            {
                p.Id = LastPersonId + 1;
            }

            var path = $"{_personRoot}\\{p.Id}.json";

            // If the item has been previously persisted
            if (File.Exists(path))
            {
                // Blow it up (delete it)
                File.Delete(path);
            }

            // Write the file
            File.WriteAllText(path, JsonSerializer.Serialize(p));

            // Return the item, which now has an id
            return p;
        }

        public List<Person> People
        {
            get
            {
                var root = new DirectoryInfo(_personRoot);
                var _people = new List<Person>();

                foreach (var personFile in root.GetFiles())
                {
                    var person = JsonSerializer.Deserialize<Person>(File.ReadAllText(personFile.FullName));
                    if (person != null)
                    {
                        _people.Add(person);
                    }
                }

                return _people;
            }
        }

        public bool Delete(int id)
        {
            var path = $"{_personRoot}\\{id}.json";

            // If the item has been previously persisted
            if (File.Exists(path))
            {
                // Blow it up (delete it)
                File.Delete(path);
            }

            return true;
        }
    }
}