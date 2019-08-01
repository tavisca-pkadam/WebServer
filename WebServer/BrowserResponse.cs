using System.Text;
using System.Net;

namespace WebServer
{
    public class BrowserResponse:IBrowser
    {
        public static void Send(WebPage webPage, HttpListenerResponse response)
        {
            byte[] buffer = EncodeWebData(webPage);

            response.ContentLength64 = buffer.Length;
            using (var outputStream = response.OutputStream)
            {
                outputStream.Write(buffer, 0, buffer.Length);
            }
        }

        private static byte[] EncodeWebData(WebPage webPage)
        {
            return Encoding.UTF8.GetBytes(webPage.data);
        }
    }






}
