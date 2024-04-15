using System;
using System.Collections.Specialized;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace CsharpAPI.Library.Models
{
    public class Course
    {
        //private fields
        private string? code;
        private int id;
        private string? name;
        private string? description;
        private string? prefix;
        private List<Person>? roster;
        private List<Module>? modules;
        private List<Assignment>? assignments;


        


        //parameterized constructor
        public Course(string? cCode, string? cName, string? cDescription)
            {
                code = cCode;
                name = cName;
                description = cDescription; 
                roster = new List<Person>();
                modules = new List<Module>();
                assignments = new List<Assignment>();
            Id = ++LastId;
        }
        public static int LastId = 0;
        public Course()
        {
            Id = ++LastId;
        }
        //public properties
        
        public List <Person>? Roster
        {
            get { return roster; }
            set { roster = value; }
        }

        public List <Module>? Modules
        {
            get { return modules; }
            set { modules = value; }
        }

        public List<Assignment>? Assignments
        {
            get { return assignments; }
            set { assignments = value; }
        }
        
        public  string? Code 
        {
            get { return code; }
            set { code = value; }
        }

        public string? Name   // property
        {
            get { return name; }   // get method
            set { name = value; }  // set method
        }

        public string? Description
        {
            get { return description; }
            set { description = value; }
        }

        public string? Prefix
        {
            get { return prefix; }
            set { prefix = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //functions

        public void AddStudent(Person person)
        {
            Console.WriteLine("Adding student " + person.Name);
            roster.Add(person);

        }
        
        public void RmStudent(Person person)
        {
            Console.WriteLine("Removing student " + person.Name);
            roster.Remove(person);

        }
        public void DisplayRoster()
        {
            Console.WriteLine("Printing course roster");
                 
            foreach(var person in roster)
            {
                Console.WriteLine(person);
            }
            
        }

       // public void UpdateInfo(string)
        public override string ToString()
        {
            return prefix + " - " + Name;
        }

        
    }
}
