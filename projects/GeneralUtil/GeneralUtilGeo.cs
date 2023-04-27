using Newtonsoft.Json.Linq;
//
namespace GeneralUtil
{
   public static class GeneralUtilGeo
    {
        public static double getDistance(string origin, string destination)
        {
            System.Threading.Thread.Sleep(1000);
            int distance = 0;
            string key = "AIzaSyA0-Rd_lhGOuWBk7JmyQAiR_TOfqN9aHss";

            string url = "https://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&key=" + key;
            url = url.Replace(" ", "+");
            string content = fileGetContents(url);
            JObject o = JObject.Parse(content);
            try
            {
                distance = (int)o.SelectToken("routes[0].legs[0].distance.value");
                return ((double)distance)/1000.0;
            }
            catch
            {
                return ((double)distance) / 1000.0;
            }
        }

        public static string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("https:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);

                }
                else
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch { sContents = "unable to connect to server "; }
            return sContents;
        }

    }
}
