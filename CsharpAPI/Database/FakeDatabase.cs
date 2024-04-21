﻿using LMS.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Library.Database
{
    public static class FakeDatabase
    {
        private static List<Person> people = new List<Person>();
        private static List<Course> courses = new List<Course>();

        public static List<Person> People
        {
            get
            {
                return people;
            }
        }
        public static List<Course> Courses
        {
            get
            {
                //Courses.Select(c => c.id).Max() + 1;
                return courses;
            }
        }
    }
}
