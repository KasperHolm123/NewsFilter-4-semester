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
        // using System.Xml.Serialization;
        // XmlSerializer serializer = new XmlSerializer(typeof(Rss));
        // using (StringReader reader = new StringReader(xml))
        // {
        //    var test = (Rss)serializer.Deserialize(reader);
        // }

        [XmlRoot(ElementName = "link")]
        public class Link
        {

            [XmlAttribute(AttributeName = "href")]
            public string Href { get; set; }

            [XmlAttribute(AttributeName = "rel")]
            public string Rel { get; set; }

            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
        }

        [XmlRoot(ElementName = "guid")]
        public class Guid
        {

            [XmlAttribute(AttributeName = "isPermaLink")]
            public bool IsPermaLink { get; set; }

            [XmlText]
            public string Text { get; set; }
        }

        [XmlRoot(ElementName = "item")]
        public class Item
        {

            [XmlElement(ElementName = "title")]
            public string Title { get; set; }

            [XmlElement(ElementName = "link")]
            public string Link { get; set; }

            [XmlElement(ElementName = "guid")]
            public Guid Guid { get; set; }

            [XmlElement(ElementName = "pubDate")]
            public DateTime PubDate { get; set; }
        }

        [XmlRoot(ElementName = "channel")]
        public class Channel
        {

            [XmlElement(ElementName = "title")]
            public string Title { get; set; }

            [XmlElement(ElementName = "description")]
            public string Description { get; set; }

            [XmlElement(ElementName = "link")]
            public List<string> Link { get; set; }

            [XmlElement(ElementName = "generator")]
            public string Generator { get; set; }

            [XmlElement(ElementName = "lastBuildDate")]
            public DateTime LastBuildDate { get; set; }

            [XmlElement(ElementName = "language")]
            public string Language { get; set; }

            [XmlElement(ElementName = "docs")]
            public string Docs { get; set; }

            [XmlElement(ElementName = "item")]
            public List<Item> Item { get; set; }
        }

        [XmlRoot(ElementName = "rss")]
        public class Rss
        {

            [XmlElement(ElementName = "channel")]
            public Channel Channel { get; set; }

            [XmlAttribute(AttributeName = "dc")]
            public string Dc { get; set; }

            [XmlAttribute(AttributeName = "content")]
            public string Content { get; set; }

            [XmlAttribute(AttributeName = "atom")]
            public string Atom { get; set; }

            [XmlAttribute(AttributeName = "version")]
            public double Version { get; set; }

            [XmlText]
            public string Text { get; set; }
        }


    }
}
