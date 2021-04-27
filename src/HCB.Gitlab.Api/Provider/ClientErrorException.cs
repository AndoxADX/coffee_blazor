using System;
using System.Net;

namespace HCB.Gitlab.Api.Provider
{
    public class ClientErrorException : Exception
    {
        public HttpStatusCode code;
        public ClientErrorException(string reason, HttpStatusCode code) : base(reason)
        {
            this.code = code;
        }
    }
}