using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;

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

    public class ServerListener
    {
        HttpListener httpListener;
        public bool isListening;
        Action<HttpListenerContext> OnClientConnected;

        public ServerListener(HttpListener httpListener, Action<HttpListenerContext> OnClientConnected)
        {
            this.httpListener = httpListener;
            this.OnClientConnected = OnClientConnected;
        }

        public void StartListening()
        {
            isListening = true;
            this.httpListener.Start();

            var listenerThread = new Thread(_ =>
            {
                while (isListening)
                {
                    var context = this.httpListener.GetContext();
                    this.OnClientConnected(context);
                }
            });
            listenerThread.Start();
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

    public class BrowserUrl : IBrowser
    {
        HttpListenerContext context;

    }
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
