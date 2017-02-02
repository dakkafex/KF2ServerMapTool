using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.ComponentModel;

namespace KF2Tool
{
    class MapData
    {
        public List<Map> MapList { get; set; }

        static private JObject GetBananaJson(int Page)
        {
            //turns Gamebanana's Json dump into usefull data in the form of a Json object...black magic
            var response = WebRequest.Create("http://gamebanana.com/maps/games/5306?vl[page]=" + Page + "&mid=SubmissionsList&api=SubmissionsListModule").GetResponse();
            var strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject o = JObject.Parse(strResponse);

            return o;
        }


        private List<Map> MapCollection()
        {
            JObject MapBanana = GetBananaJson(1);

            //counts the pages on the site and the amount of maps on the given page to avoid outofbound issues
            int PageCount = (int)MapBanana["_aPageNavigation"]["_nPagesInList"];
            int MapPerPage = MapBanana["_aCellValues"].Count();

            List<Map> maps = new List<Map>();

            for (int i = 1; i <= PageCount; i++)
            {
                MapBanana = GetBananaJson(i);
                for (int j = 0; j < MapPerPage; j++)
                {
                    maps.Add(new Map
                    {
                        Author = (string)MapBanana["_aCellValues"][j]["_aOwner"]["_sUsername"],
                        MapName = (string)MapBanana["_aCellValues"][j]["_sName"],
                        MapArticle = (string)MapBanana["_aCellValues"][j]["_sArticle"],
                        PreviewImage = (string)MapBanana["_aCellValues"][j]["_sFirstThumbnailImageUrl"],
                        MapId = (int)MapBanana["_aCellValues"][j]["_idItemRow"]
                    });
                }
            }
            return maps;
        }
        //stores all the map data in a usable list so it doesnt re-build the entire thing with every little mouseclick -.-
        public MapData()
        {
            MapList = MapCollection();
        }
    }
}
