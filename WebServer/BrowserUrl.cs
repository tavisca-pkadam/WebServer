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
                return GenerateFilePathFromFileName(requestUrl);
                
            }
            return GenerateFilePathFromFileName("invalid");
        }

        public static bool Validate(string url)
        {
            return url.Split().Length.Equals(1);
        }

        public static string GenerateFilePathFromFileName(string fileName)
        {
            return ServerConfiguration.serverDirectory + fileName + ServerConfiguration.fileExtension;
        }
    }






}
