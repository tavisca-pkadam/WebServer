using System.Net;
using System;

namespace WebServer
{
    public class WebPage
    {
        public string data;
        public const string htmlPrefix = "<html><body><h5><p>"  ;
        public const string htmlSuffix = "</p></h5></body></html>";

        public WebPage()
        {
            this.data = htmlPrefix + "Resoruce not Found" + htmlSuffix;
        }


        public WebPage(HttpListenerRequest request)
        {
           
            string filePath = BrowserUrl.Parse(request);
            string responseText = System.IO.File.ReadAllText(filePath);

            this.data  = htmlPrefix + responseText.Replace(@"\n", @"<br>") + htmlSuffix;
        }

    }






}
