using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NewsFilter_4_semester.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string PubDate { get; set; }
    }
}
