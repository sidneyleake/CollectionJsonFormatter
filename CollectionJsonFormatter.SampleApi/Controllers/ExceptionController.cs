namespace CollectionJsonFormatter.SampleApi.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using CollectionJsonFormatter.SampleApi.Models;

    public class ExceptionController : ApiController
    {
        public IQueryable<FluidFriend> Get()
        {
            var message = new HttpResponseMessage(HttpStatusCode.NotFound);
            message.Content = new ObjectContent(typeof(Exception), new Exception("not found"), new CollectionJsonMediaTypeFormatter());
            throw new HttpResponseException(message);
        }

        public FluidFriend GetOne(string id)
        {
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}