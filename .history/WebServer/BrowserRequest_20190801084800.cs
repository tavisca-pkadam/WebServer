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
            string filePath = @"C:\Users\pakadam\Documents\server\" + requestUrl + ".txt";
            return filePath;
        }
    }






}
