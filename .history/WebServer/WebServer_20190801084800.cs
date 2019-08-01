using System;
using System.Collections.Generic;
using System.Text;
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
            httpListener.Prefixes.Add("http://localhost:8186/");
            OnClientConnected += BrowserRequest.Process;
            serverListener = new ServerListener(httpListener, OnClientConnected);
        }

        public void Start( )
        {
            this.serverListener.StartListening();
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

    public class BrowserResponse : IBrowser
    {
        public static void Send(string message, HttpListenerResponse response)
        {
            string responseString = "<html><body><h1>"+ message +"</h1></body></html>";
 
            var buffer = Encoding.UTF8.GetBytes(responseString);
 
            response.ContentLength64 = buffer.Length;
            using(var outputStream = response.OutputStream)
            {
                outputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }






}
