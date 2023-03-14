using NewsFilter_4_semester.Models;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;

namespace NewsFilter_4_semester.Services
{
    public static class XMLReaderService
    {
        public static Task<List<Article>> GetArticles(string url)
        {
            Rss20FeedFormatter rssFormatter;
            using (var xmlReader = XmlReader.Create(url))
            {
                rssFormatter = new Rss20FeedFormatter();
                rssFormatter.ReadFrom(xmlReader);

            }
 
            List<Article> articles = new();
            foreach (var syndicationItem in rssFormatter.Feed.Items)
            {
 
                articles.Add(new Article
                {
                    Title = syndicationItem.Title.Text,
                    Link = syndicationItem.Links[0].Uri.ToString(),
                    PubDate = syndicationItem.PublishDate.DateTime
                });
            }
            // y before x to sort in descending order
            articles.Sort((x, y) => DateTime.Compare(y.PubDate, x.PubDate));
            return Task.FromResult(articles);
        }
    }
}
