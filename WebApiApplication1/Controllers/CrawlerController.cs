using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using CrawlerService.Interfaces;
using CrawlerService.Models;

namespace WebApiApplication1.Controllers
{
    public class CrawlerController : ApiController
    {
        private readonly IVnExpressParser _parser;
        
        public CrawlerController(IVnExpressParser parser)
        {
            _parser = parser;
        }
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public IEnumerable<Menu> ExtractMenu()
        {
            var url = "https://vnexpress.net/";
            return _parser.ExtractMenu(url);
        }
        
        [HttpGet]
        public IEnumerable<News> ExtractNews()
        {
            var url = "https://vnexpress.net/";
            return _parser.ExtractNews(url);
        }
    }
}