using CrawlerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerService.Interfaces
{
    public interface IParser
    {
        List<Menu> ExtractMenu(string html);
        List<News> ExtractNews(string html);
    }

    //public class Parser : IParser
    //{
    //    public List<Menu> ExtractMenu(string html)
    //    {

    //        throw new NotImplementedException();
    //    }

    //    public List<News> ExtractNews(string html)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
