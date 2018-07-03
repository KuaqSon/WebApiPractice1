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
        public async void ExtractAsync(string url, string html)
        {
            var httpClient = new HttpClient();
            html = await httpClient.GetStringAsync(url);
            
        }

        string ICrawler.Extract(string url)
        {
            string html = "";
            ExtractAsync(url, html);
            return html;
        }
    }

}
