using CrawlerService.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerService.Interfaces
{
    public interface ICrawler
    {
        string Extract(string url);
    }

    public class Crawler : ICrawler
    {
        public string ExtractAsync(string url)
        {
            var httpClient = new HttpClient();
            var html =  httpClient.GetStringAsync(url);
            return html.Result;
        }

        public string Extract(string url)
        {
            var html = ExtractAsync(url);
            return html;
        }
    }

}
