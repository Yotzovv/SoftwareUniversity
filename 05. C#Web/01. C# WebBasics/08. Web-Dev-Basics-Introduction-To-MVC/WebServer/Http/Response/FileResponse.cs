using System;
using WebServer.Enums;
using WebServer.Exceptions;
using WebServer.Http.Contracts;

namespace WebServer.Http.Response
{
    public class FileResponse : IHttpResponse
    {
        public FileResponse(HttpStatusCode statusCode, byte[] fileData)
        {
            this.ValidateStatusCode(statusCode);

            this.FileData = fileData;
            this.StatusCode = statusCode;

            this.Headers.Add(HttpHeader.ContentLength.ToString(), this.FileData.Length.ToString());
            this.Headers.Add(HttpHeader.ContentDisposition.ToString(), "attachment");
        }

        private void ValidateStatusCode(HttpStatusCode statusCode)
        {
            var statusCodeNumber = (int)statusCode;

            if(299 > statusCodeNumber && statusCodeNumber < 400)
            {
                throw new InvalidResponseException("File responses need a status code above 300 and below 400.");
            }
        }
        
        public byte[] FileData { get; }

        public HttpStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; set; }

        public IHttpCookieCollection Cookies { get; set; }
    }
}
