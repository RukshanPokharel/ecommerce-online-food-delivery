using Autofac;
using Autofac.Integration.SignalR;
using AutoMapper;
using DriverApplication.App_Start;
using DriverApplication.CacheLayer;
using DriverApplication.Models;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DriverApplication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //private const string pushLogCacheItemKey = "pushLog";
        //private const string DummyPageUrl = "http://localhost/TestCacheTimeout/WebForm1.aspx";

        protected void Application_Start()
        {
            
            // initializing autofac configuration.
            AutofacConfig.config();
            // initializing auto mapper for mapping class, objects or DTOs.
            //Mapper.Initialize(c => c.AddProfile<MappingProfile>());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // used for authentication and authorization
            //GlobalConfiguration.Configure(FilterConfig.Configure);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters
            .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            // configuring our application to return camel-case JSON (thisIsCamelCase), instead of the default pascal-case (ThisIsPascalCase).
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();


        }

    }
}
