using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppParserVNExpress
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMenu();
            //GetHtmlAsync();
            Console.ReadLine();
        }

        private static async void GetHtmlAsync()
        {
            var url = "https://vnexpress.net/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            //var NewsHtml = htmlDocument.DocumentNode.SelectNodes("//section/article")
            //    .Where(node => node.GetAttributeValue("class", "")
            //    .Equals("list_news")).ToList();

            var NewsHtml = htmlDocument.DocumentNode.Descendants("section")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("sidebar_home_1")).ToList();

            var NewsListItems = NewsHtml[0].Descendants("article")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("list_news")).ToList();

            foreach (var NewsItem in NewsListItems.Take(10))
            {
                var Title = NewsItem.Descendants("h3")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Equals("title_news")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t',' ');

                var Desc = NewsItem.Descendants("h4")
                    .Where(node => node.GetAttributeValue("class","")
                    .Equals("description")).First(x => x.Attributes["class"] != null
                           && x.Attributes["class"].Value == "description").InnerText.Trim('\r', '\n', '\t', ' ');

                var NewsLink = NewsItem.Descendants("a")
                    .First().Attributes["href"].Value;

                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Decription: {Desc}");
                Console.WriteLine($"Link: {NewsLink}");
                Console.WriteLine();
            }

            
        }

        private static async void GetMenu()
        {
            var url = "https://vnexpress.net/";
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

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
                var Title = MenuItem.InnerText.Trim('\r', '\n', '\t', ' ');

                var NewsLink = MenuItem.Attributes["href"].Value;

                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Link: {NewsLink}");
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }
}
