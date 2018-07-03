using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlerService.Models;
using HtmlAgilityPack;

namespace CrawlerService.Interfaces
{
    public interface IVnExpressParser : IParser
    {
        
    }
    
    public class VxExpressParser : IVnExpressParser
    {
        private readonly ICrawler _crawler;
        public VxExpressParser(ICrawler crawler)
        {
            _crawler = crawler;
        }
        public List<Menu> ExtractMenu(string url)
        {
            var html = _crawler.Extract(url);
            
            var ListMenu = new List<Menu>();
            
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var MenuHtml = htmlDocument.DocumentNode.Descendants("nav")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("main_menu")).ToList();

            var MenuListItems = MenuHtml[0].Descendants("a")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("mnu_")).ToList();

            foreach (var MenuItem in MenuListItems)
            {
                var menu = new Menu
                {
                    Title = MenuItem.InnerText.Trim('\r', '\n', '\t', ' '),
                    
                    Url = MenuItem.Attributes["href"].Value
                };
                ListMenu.Add(menu);
            }

            return ListMenu;
        }

        public List<News> ExtractNews(string url)
        {
            var html = _crawler.Extract(url);
            var ListNews = new List<News>();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var NewsHtml = htmlDocument.DocumentNode.Descendants("section")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("sidebar_home_1")).ToList();

            var NewsListItems = NewsHtml[0].Descendants("article")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("list_news")).ToList();

            
            foreach (var NewsItem in NewsListItems.Take(10))
            {
                var news = new News
                {
                    Title = NewsItem.Descendants("h3")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("title_news")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t', ' '),

                    Description = NewsItem.Descendants("h4")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("description")).First(x => x.Attributes["class"] != null
                           && x.Attributes["class"].Value == "description").InnerText.Trim('\r', '\n', '\t', ' '),

                    Url = NewsItem.Descendants("a")
                    .First().Attributes["href"].Value
                };
                ListNews.Add(news);
            }
            return ListNews;
        }
    }
}
