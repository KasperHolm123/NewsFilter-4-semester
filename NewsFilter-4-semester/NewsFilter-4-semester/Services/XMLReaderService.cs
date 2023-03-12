using NewsFilter_4_semester.Models;
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
                    PubDate = syndicationItem.PublishDate.Date.ToString()
                });
            }
            return Task.FromResult(articles);
        }
    }
}
