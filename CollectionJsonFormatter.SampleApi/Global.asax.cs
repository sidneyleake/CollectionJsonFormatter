using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CollectionJsonFormatter.Models;
using CollectionJsonFormatter.SampleApi.Models;

namespace CollectionJsonFormatter.SampleApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var formatter = new CollectionJsonMediaTypeFormatter();
            CollectionJsonConfiguration.RegisterQuery("search", new QueryProperty
            {
                Href = "/friends/search",
                Name = "search",
                Prompt = "Search",
                Rel = "search",
                Data = new List<DataProperty>
                {
                    new DataProperty
                    {
                        Name = "search",
                        Prompt = "Search",
                        Value = string.Empty
                    }
                }
            });

            GlobalConfiguration.Configuration.Formatters.Add(formatter);
        }
    }
}