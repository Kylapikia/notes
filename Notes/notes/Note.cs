using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace notes
{
    class Note
    {
        private string heading;
        private string content;
        public List<string> code;

        public string Heading()
        {
            return heading;
        }

        public string Content()
        {
            return content;
        }

        public Note(string heading, string content)
        {
            this.heading = heading;
            this.content = content;
        }

        public override string ToString()
        {
            return content;
        }
    }
}
