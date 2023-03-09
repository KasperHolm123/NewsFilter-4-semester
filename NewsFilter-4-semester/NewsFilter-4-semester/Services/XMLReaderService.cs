using NewsFilter_4_semester.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static NewsFilter_4_semester.Models.Article;
using System.ServiceModel.Syndication;

namespace NewsFilter_4_semester.Services
{
    public static class XMLReaderService
    {


        public static Rss Trending()
        {
            Rss articles = new();
            XmlSerializer serializer = new XmlSerializer(typeof(Rss));
            using (StringReader reader = new StringReader("https://www.dr.dk/nyheder/service/feeds/senestenyt"))
            {
                articles = (Rss)serializer.Deserialize(reader);
            }

            return articles;
        }
    }
}
