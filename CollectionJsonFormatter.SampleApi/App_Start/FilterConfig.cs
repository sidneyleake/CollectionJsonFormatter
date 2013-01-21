using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace CollectionJsonFormatter.SampleApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, HttpConfiguration config)
        {
            config.Filters.Add(new HttpResponseExceptionFilterAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }

    public class HttpResponseExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public HttpResponseExceptionFilterAttribute()
            : base()
        {
        }

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);
        }
    }
}