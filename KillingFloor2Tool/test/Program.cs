using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace test
{
    class Program
    {

        static public JObject GetBananaJson(int Page)
        {
            var response = WebRequest.Create("http://gamebanana.com/maps/games/5306?vl[page]=" + Page + "&mid=SubmissionsList&api=SubmissionsListModule").GetResponse();
            var strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject o = JObject.Parse(strResponse);

            return o;
        }

        static void Main(string[] args)
        {
            JObject bob = GetBananaJson(1);

            int PageCount = (int)bob["_aPageNavigation"]["_nPagesInList"];
            int MapPerPage = bob["_aCellValues"].Count();

            for (int i = 1; i <= PageCount; i++)
            {
                bob = GetBananaJson(i);
                for (int j = 0; j < MapPerPage; j++)
                {

                    string je = (string)bob["_aCellValues"][j]["_aOwner"]["_sUsername"];
                    Console.WriteLine(je);

                }
                Console.WriteLine();
            }



            Console.Read();
        }
    }
}

