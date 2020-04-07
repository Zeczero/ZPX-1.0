using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace ZPXX_1._0.Offsets
{
   public class SelfUpdating
    {
        public static void GetOffsetsFromFile()
        {
            string json = File.ReadAllText($@"{Assembly.GetExecutingAssembly().Location}\csgo.json");
             Cheat.Main.RootObject = JsonConvert.DeserializeObject<RootObject>(json);
        }
        public static bool UpdateOffsets()
        {
            WebClient web = new WebClient();
            byte[] rawData = web.DownloadData("https://raw.githubusercontent.com/frk1/hazedumper/master/csgo.json");
            string webData = Encoding.UTF8.GetString(rawData);
            File.WriteAllText($@"{Assembly.GetExecutingAssembly().Location}\csgo.json", webData);
            GetOffsetsFromFile();
            return true;
        }

    }
}
