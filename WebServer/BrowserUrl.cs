using System.Net;

namespace WebServer
{
    public class BrowserUrl : IBrowser
    {

        public static string Parse(HttpListenerRequest request)
        {
            string requestUrl = request.RawUrl;
            if (Validate(requestUrl))
            {
                string filePath = ServerConfiguration.serverDirectory + requestUrl + ServerConfiguration.fileExtension;
                return filePath;
            }
            return ServerConfiguration.serverDirectory + "invalid" + ServerConfiguration.fileExtension;

        }

        public static bool Validate(string url)
        {
            return url.Split().Length.Equals(1);
        }
    }






}
