using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Diagnostics.Metrics;

namespace Scrape
{ 
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://books.toscrape.com/");
            int counter = 0;

            HtmlAgilityPack.HtmlNode unorderedList = doc.DocumentNode.SelectSingleNode("//ul[@class='nav nav-list']");
            HtmlNodeCollection childNodes = unorderedList.ChildNodes;
            

            //for loop to recursively to go through the specified part of the DOM-tree
            while (counter < childNodes.Count) 
            {

                if (CheckIfValid(childNodes[counter].Name))
                {
                    //var c = childNodes[counter].ChildNodes[0];

                    HtmlNode d = childNodes[counter];

                    for (int children = 0; children < childNodes[counter].ChildNodes.Count; children++)
                    {
                        string name = childNodes[counter].ChildNodes[children].Name;
                        if(CheckIfValid(name))
                            Console.WriteLine(name.ToString());

                    }
                    
                    
                }      


                counter ++;
            
            }

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param string "text"></param>
        /// <returns>true/false</returns>
        static bool CheckIfValid(String text)
        {
            return (!text.Equals("Text")
                && !text.Equals("#Text")
                && !text.Equals("#text"));
        }

        //static bool ScrapeRecursively

    }
}
