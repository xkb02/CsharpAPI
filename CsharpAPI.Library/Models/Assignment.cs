using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CsharpAPI.Library.Models
{
    public class Assignment
    {
        private string? name;
        private string? description;
        private string? totalavailablepoints;
        private string? dueDate;
        public Assignment(string? aName, string? aDescription, string? aTotalavailablepoints, string? aDueDate ) 
        {
            name = aName;
            description = aName;
            totalavailablepoints = aTotalavailablepoints;
            dueDate = aDueDate;
        }

        public string? Name
        {
            get { return name; }
            set { name = value; }
        }

        public string? Description
        {
            get { return description; }
            set { name = value; }
        }

        public string? Totalavailablepoints
        {
            get { return totalavailablepoints; }
            set { totalavailablepoints = value; }
        }
        public string? DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

    }
}
