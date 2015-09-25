using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace CreativeWebAPI.Infrastructure.HttpActionResults
{
    public class NoContentResult : IHttpActionResult
    {
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var responseMessage = new HttpResponseMessage() { StatusCode = HttpStatusCode.NoContent };

            return Task.FromResult(responseMessage);
        }
    }
}