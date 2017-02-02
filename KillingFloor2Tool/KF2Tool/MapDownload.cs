using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KF2Tool
{
    class MapDownload
    {
        static private JObject GetBananaJson(int MapId)
        {
            //Grabs the direct DL link from the JSON file
            var response = WebRequest.Create("http://gamebanana.com/maps/download/" + MapId + "?api=MirrorDownloadModule").GetResponse();
            var strResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject o = JObject.Parse(strResponse);

            return o;
        }
        
        public void AddMap(int MapId)
        {
            string DownloadUri = (string)GetBananaJson(MapId)["_sOfficialDirectDownloadUrl"];

            
        }
    }
}
