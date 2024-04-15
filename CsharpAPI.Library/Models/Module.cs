using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAPI.Library.Models
{
    public class Module
    {
        private string? name;
        private string? description;
        private List<ContentItem>? content;
        
        public Module(string name, string? description, List<ContentItem>? content)
        {
            this.name = name;
            this.description = description;
            this.content = new List<ContentItem>();
        }

        public List<ContentItem> Content
        {
            get { return content; }
            set { content = value; }
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
