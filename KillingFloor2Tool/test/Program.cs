using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace test
{
    class Program
    {

        static void Main(string[] args)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                //client.DownloadFile("http://stackoverflow.com/questions/599275/how-can-i-download-html-source-in-c-sharp", @"C:\users\jacky\documents\localfile.html");

                // Or you can get the file content without saving it:.
                string htmlCode = client.DownloadString("http://kf2.gamebanana.com/maps/188863");
                //...
               // string s = Regex.Match(htmlCode, @"<a class='Screenshot' href='(.+)'> ",RegexOptions.Singleline).Groups[1];
                Console.WriteLine(htmlCode);
            }
        }
    }
}
