using System;
using System.Net;
using System.Text;

namespace FusionAlliance.DotNetExtensions.Common.Net
{
    public static class WebResponseExtensions
    {
        public static byte[] ReadResponseStreamToBytes(this WebResponse response)
        {
            var contentLength = response.ContentLength;

            // ContentLength is a long, but we cannot create a byte[] with more than Int32.MaxValue. Hence, the conversion.
            var bufferLength = contentLength < int.MaxValue ? (int) contentLength : int.MaxValue;

            if (bufferLength < 0)
            {
                throw new InvalidOperationException("Unable to get content length from web response.");
            }
            var buffer = new byte[bufferLength];
            using (var stream = response.GetResponseStream())
            {
                if (stream == null)
                {
                    throw new NullReferenceException("Unable to get response stream from web response.");
                }
                stream.Read(buffer, 0, bufferLength);
                return buffer;
            }
        }

        public static string ReadResponseStreamToString(this WebResponse response, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            var bytes = response.ReadResponseStreamToBytes();
            var responseString = encoding.GetString(bytes);
            return responseString;
        }
    }
}