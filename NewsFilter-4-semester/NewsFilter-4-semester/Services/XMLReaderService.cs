﻿using NewsFilter_4_semester.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static NewsFilter_4_semester.Models.Article;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Diagnostics;

namespace NewsFilter_4_semester.Services
{
    public static class XMLReaderService
    {


        public static List<Article> Trending()
        {
            Rss20FeedFormatter rssFormatter;
            using (var xmlReader = XmlReader.Create
                ("https://www.dr.dk/nyheder/service/feeds/senestenyt"))
            {
                rssFormatter = new Rss20FeedFormatter();
                rssFormatter.ReadFrom(xmlReader);

            }
            List<Article> articles = new();
            foreach (var syndicationItem in rssFormatter.Feed.Items)
            {
                Debug.WriteLine("Article: {0}",
                   syndicationItem.Title.Text);
                Debug.WriteLine("URL: {0}",
                   syndicationItem.Links[0].Uri);


                articles.Add(new Article
                {
                    Title = syndicationItem.Title.Text,
                    Link = syndicationItem.Links[0].Uri.ToString(),
                    PubDate = syndicationItem.PublishDate.Date.ToString()
                });
            }
            return articles;
        }
    }
}
