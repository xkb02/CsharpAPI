using csharpa1.Database;
using CsharpAPI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAPI.Library.Services
{

    public class CourseManager
    {
        //creates a list of all the courses created in the program
        //public List<Course> courses = new List<Course>();
        public List<Assignment> assignments = new List<Assignment>();

        //new additions for maui proj
        private static CourseManager? _instance;

        public List<Course> courses
        {
            get
            {
                return FakeDatabase.Courses;
            }
        }
        public static CourseManager Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseManager();
                }

                return _instance;
            }
        }


        public void AddCourse(Course course)
        {
            //if this thing has an id of zero, set it to whatever the next id should be. in fake database he has Courses.Select(c=>c.id).Max()+1
            FakeDatabase.Courses.Add(course);
        }
        public void AddAssignment(Assignment asgn)
        {
            assignments.Add(asgn);
        }

        public void CreateCourse()
        {
            string? nme;
            string? code;
            string? desc;

            Console.WriteLine("Create a Course - Enter the course name: ");
            nme = Console.ReadLine();
            Console.WriteLine("Enter the course code: ");
            code = Console.ReadLine();
            Console.WriteLine("Enter the course description: ");
            desc = Console.ReadLine();

            Course? newCourse = new Course(code, nme, desc);

            Console.WriteLine("Course "+ newCourse.Name + " created.");

            AddCourse(newCourse);


        }

        public void CourseSearch()
        {
            bool flag = false;
            Console.WriteLine("Course Search - Please select an option 1..x ");
            Console.WriteLine("1) Search by Name");
            Console.WriteLine("2) Search by Code");
            Console.WriteLine("3) Search by Description");
            Console.WriteLine("x) Exit to main menu");
            string? choice = Console.ReadLine();
            while (!flag)
            {

                if (choice != "1" && choice != "2" && choice != "3" && choice != "x")
                {
                    Console.WriteLine("Invalid choice entered, try again");
                    choice = Console.ReadLine();
                }
                else { flag = true; }
            }

            if (choice == "1")
            {
                Console.WriteLine("Enter Course name: ");
                var name = Console.ReadLine();
                bool found = false;
                foreach (var course in FakeDatabase.Courses)
                {
                    if (course.Name == name)
                    {
                        found = true;
                        Console.WriteLine("Course Found!");
                        Console.WriteLine(course);
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Course not found");

                }
            }

            if (choice == "2")
            {
                Console.WriteLine("Enter course code: ");
                var code = Console.ReadLine();
                bool found = false;
                foreach (var course in FakeDatabase.Courses)
                {
                    if (course.Code == code)
                    {
                        found = true;
                        Console.WriteLine("Course Found!");
                        Console.WriteLine(course);
                    }

                }
                if (!found)
                {
                    Console.WriteLine("Course not found");

                }
            }

            if (choice == "3")
            {
                Console.WriteLine("Enter course description: ");
                var desc = Console.ReadLine();
                bool found = false;
                foreach (var course in FakeDatabase.Courses)
                {
                    if (course.Description == desc)
                    {
                        found = true;
                        Console.WriteLine("Course Found!");
                        Console.WriteLine(course);
                    }
                    if (!found)
                    {
                        Console.WriteLine("Course not found.");

                    }
                }

                if (choice == "x")
                {
                    Console.WriteLine("Exiting to main menu. ");
                }
            }
        }
        public void CourseUpdate()
        {
            Console.WriteLine("Update a Course's Information, Enter the code of the course you wish to update: ");
            var code = Console.ReadLine();
            bool found = false;
            foreach (var course in FakeDatabase.Courses)
            {
                if (course.Code == code)
                {
                    found = true;
                    Console.WriteLine("Enter the new course name: ");
                    course.Name = Console.ReadLine();
                    Console.WriteLine("Enter the new course code: ");
                    course.Code = Console.ReadLine();    
                    Console.WriteLine("Enter the new course description: ");
                    course.Description = Console.ReadLine();
                    Console.WriteLine("Course " + course.Name + " updated.");
                }
            }
            if (!found)
            {
                Console.WriteLine("Course not found.");

            }
        }
        public void DisplayCourses()
        {
            Console.WriteLine("List of Courses: ");
            foreach (var course in courses)
            {
                Console.WriteLine(course.Name + " | Code: " +course.Code);
            }
        }
        
        
        //function to display the roster of a given course
        public void DisplayCourseRoster()
        {
            string? code;
            Console.WriteLine("Type the course code: ");
            code = Console.ReadLine();
            bool found = false;
            foreach(Course course in courses)
            {
                if (course.Code == code)
                {
                    found = true;
                    course.DisplayRoster();
                    break;
                }
               
            }
            if (!found) { Console.WriteLine("Course code not found."); }

        }

        public Course GetById(int id)
        {
            return FakeDatabase.Courses.FirstOrDefault(p => p.Id == id);
        }
        public void AssignmentAdder()
        {
            string? code;
            Console.WriteLine("Assignnment Adder - Type the course code you wish to add this assignment to: ");
            code = Console.ReadLine();
            bool flag = false;
            foreach (Course course in courses)
            {
                if (course.Code == code)
                {
                    flag = true;
                    Console.WriteLine("Enter the name of the Assigment you are adding to " + course.Name);
                    string? tempName = Console.ReadLine();
                    Console.WriteLine("Enter the description of the Assigment you are adding to " + course.Name);
                    string? tempDesc = Console.ReadLine();
                    Console.WriteLine("Enter the total available points of the Assigment you are adding to " + course.Name);
                    string? tempPoints = Console.ReadLine();
                    Console.WriteLine("Enter the due date of the Assigment you are adding to " + course.Name);
                    string? tempDueDate = Console.ReadLine();
                    Assignment? newAsgn = new Assignment(tempName, tempDesc, tempPoints, tempDueDate);
                    AddAssignment(newAsgn);
                }
                
            }

            if (!flag) { Console.WriteLine("Course code not found."); }

        }
    }
    }

