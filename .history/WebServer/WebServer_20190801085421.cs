using System;
using System.Collections.Generic;
using System.Net;

namespace WebServer
{
    public class WebServer
    {
        string rootUrl = "http://localhost:8189/";
        HttpListener httpListener;
        ServerListener serverListener;
        Action<HttpListenerContext> OnClientConnected;

        public WebServer()
        {
            httpListener = new HttpListener();
            httpListener.Prefixes.Add(ServerConfiguration.);
            OnClientConnected += BrowserRequest.Process;
            serverListener = new ServerListener(httpListener, OnClientConnected);
        }

        public void Start( )
        {
            this.serverListener.StartListening();
        }

    }

    public class HttpUrl
    {

    }


    public interface IBrowser
    {

    }






}
