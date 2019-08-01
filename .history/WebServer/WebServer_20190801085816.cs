using System;
using System.Collections.Generic;
using System.Net;

namespace WebServer
{
    public class WebServer
    {
        HttpListener httpListener;
        ServerListener serverListener;
        Action<HttpListenerContext> OnClientConnected;

        public WebServer()
        {
            httpListener = new HttpListener();
            httpListener.Prefixes.Add(ServerConfiguration.rootUrl);
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
