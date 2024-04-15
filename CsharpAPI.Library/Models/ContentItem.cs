using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAPI.Library.Models
{
    public class ContentItem
    {
        private string? name;
        private string? description;
        private string? path;

        public ContentItem(string name, string? description, string? path)
        {
            this.name = name;
            this.description = description;
            this.path = path;
        }

        public string? Path
        {
            get { return path; }
            set { path = value; }
        }
        public string? Description
        {
            get { return description; }
            set { description = value; }
        }
        public string? Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
