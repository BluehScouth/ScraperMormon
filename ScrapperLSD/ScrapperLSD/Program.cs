using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScrapperLSD
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = new List<string>();
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");
            books.Add("1-ne/1");


            foreach (var book in books)
            {
                System.Net.WebClient client = new System.Net.WebClient();
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-GB; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12");
                client.Headers.Add("Accept", "*/*");
                client.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
                client.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
                client.Encoding = System.Text.Encoding.UTF8;
                String webData = client.DownloadString(string.Format("https://www.lds.org/scriptures/bofm/{0}?lang=spa", book));

                string pattern = @"<p(.*?)>(.*?)</p>";
                pattern = @"\<p[^\>]+class=""verse""[^\>]*\>(.)</p>";
                pattern = @"<p[^>]*?>(.*)</p>";
                pattern = @"\<p[^\>]+class=""verse""[^\>]*\>(.*)";
                Regex rx = new Regex(pattern,
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
                MatchCollection matches = rx.Matches(webData);

                foreach (var ma in matches)
                {
                    Regex regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);
                    string resultText = regex.Replace(Convert.ToString(ma), " ").Trim();
                    Console.WriteLine(resultText);
                    Console.WriteLine();
                }


            }

            Console.ReadLine();
        }
    }
}

       


