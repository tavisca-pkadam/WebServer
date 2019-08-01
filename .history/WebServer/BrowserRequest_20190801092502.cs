using System;
using System.Net;

namespace WebServer
{
    public class BrowserRequest : IBrowser
    {
        HttpListenerContext context;
        public static void Process(HttpListenerContext context)
        {
            string responseText;
            try
            {
                string filePath = ParseUrl(context.Request);
                responseText = System.IO.File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                responseText = "Resource Not Found ";
            }
            

            BrowserResponse.Send(responseText, context.Response);
        }

        public static string ParseUrl(HttpListenerRequest request)
        {
            string requestUrl = request.RawUrl;
            if(ValidateUrl(requestUrl))
            {
                string filePath = ServerConfiguration.serverDirectory + requestUrl + Ser;
                return filePath;
            }
            return 
            
        }

        public static bool ValidateUrl(string url)
        {
            return url.Split().Length.Equals(1);
        }
    }






}
