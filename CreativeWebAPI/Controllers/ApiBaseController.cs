using CreativeWebAPI.Infrastructure.HttpActionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CreativeWebAPI.Controllers
{
    /// <summary>
    /// Custom base class for api controllers.
    /// </summary>
    public class ApiBaseController : ApiController
    {
        protected internal virtual NoContentResult NoContent()
        {
            return new NoContentResult();
        }

        protected internal virtual SeeOtherResult SeeOther(string seeOtherUri)
        {
            return new SeeOtherResult(seeOtherUri);
        }
    }
}