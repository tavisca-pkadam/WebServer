using System;
using System.Collections.Generic;
using System.Text;
using  System.Net;

namespace WebServer
{
    public class WebServer
    {
        string rootUrl = "http://localhost:8189/";
        HttpListener httpListener;

        public WebServer()
        {
            httpListener = new HttpListener();
        }
        
    }

    public class ServerListener
    {
        HttpListener httpListener;

        public ServerListener(HttpListener httpListener)
        {
            this.httpListener = httpListener;
        }
    }

    public class WebPage
    {
        
    }

    public class HttpUrl
    {

    }


    public interface IBrowser
    {

    }

    public class BrowserUrl:IBrowser
    {

    }
    public class BrowserRequest:IBrowser
    {

    }

    public class BrowserResponse:IBrowser
    {
        public void Send(string message)
        {
            
        }
    }






}
