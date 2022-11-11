using HtmlAgilityPack;
using System;
using System.Collections;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var webGet = new HtmlWeb();
            HtmlDocument document = webGet.Load("https://prodoctorov.ru/rostov-na-donu/top/poliklinika/");
            
            ArrayList pol = new ArrayList();
            ArrayList address = new ArrayList();

            document = webGet.Load("https://prodoctorov.ru/rostov-na-donu/top/poliklinika/?page=0" );
            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//div[@class='b-card__name']//a[@class='b-card__name-link b-link ui-text ui-text_h5 ui-text_color_primary-blue']"))
            {
                pol.Add(node.InnerText.Replace("\n", "").Trim());
            }
            foreach (HtmlNode node in document.DocumentNode.SelectNodes("//div[@class='b-card__address']"))
            {
                address.Add(node.InnerText.Replace("\n", "").Trim());
            }
            

            for (int i = 0; i < address.Count; i++)
            {
                Console.WriteLine(pol[i].ToString() + " расположена по адресу: " + address[i].ToString());
            }

        }
    }
}
