using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace CreativeWebAPI.Infrastructure.HttpActionResults
{
    public class SeeOtherResult : IHttpActionResult
    {
        private string _resourceUri;

        public SeeOtherResult(string resourceUri)
        {
            _resourceUri = resourceUri;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage() { StatusCode = HttpStatusCode.SeeOther };
            responseMessage.Headers.Add("Location", _resourceUri);

            return Task.FromResult(responseMessage);
        }
    }
}