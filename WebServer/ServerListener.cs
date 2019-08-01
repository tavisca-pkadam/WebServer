using System;
using System.Net;
using System.Threading;

namespace WebServer
{
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

          
            while (isListening)
            {
                var context = this.httpListener.GetContext();
                this.OnClientConnected(context);
            }
        }
    }






}
