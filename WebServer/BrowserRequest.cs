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
                WebPage webPage = new WebPage(context.Request);
                BrowserResponse.Send(webPage, context.Response);
            }
            catch (Exception e)
            {
                WebPage webPage = new WebPage();
                BrowserResponse.Send(webPage, context.Response);
            }


        }

        
    }






}
