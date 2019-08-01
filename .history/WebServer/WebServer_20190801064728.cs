using System;
using System.Collections.Generic;
using System.Text;
using  System.Net;
using System.Threading;

namespace WebServer
{
    public class WebServer
    {
        string rootUrl = "http://localhost:8189/";
        HttpListener httpListener;
        ServerListener serverListener;
        Action<HttpListenerContext> On;
        public WebServer()
        {
            httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:8186/");
            serverListener = new ServerListener(httpListener);


        }
        
    }

    public class ServerListener
    {
        HttpListener httpListener;
        public bool isListening;
\
        public ServerListener(HttpListener httpListener)
        {
            this.httpListener = httpListener;
        }

        public void StartListening( )
        {
            isListening = true;
            var listenerThread = new Thread( _ => {
                while(isListening)
                {
                    var context = this.httpListener.GetContext();
                    
                }
            });
            throw new NotImplementedException();
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
         HttpListenerContext context;

    }
    public class BrowserRequest:IBrowser
    {
         HttpListenerContext context;
    }

    public class BrowserResponse:IBrowser
    {
        public void Send(string message)
        {
            
        }
    }






}
