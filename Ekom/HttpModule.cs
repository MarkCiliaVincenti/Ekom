﻿using Ekom.Models;
using Ekom.Services;
using Ekom.Utilities;
using System;
using System.Web;
using Umbraco.Core;

namespace Ekom
{
    /// <summary>
    /// Ekom HttpModule, ensures an ekmRequest object exists in the runtime cache for all
    /// controller requests.
    /// The module checks for existence of a store querystring parameter and if found,
    /// creates an ekmRequest object with DomainPrefix and currency if applicable.
    /// </summary>
    class HttpModule : IHttpModule
    {
        /// <summary>
        /// ModuleName
        /// </summary>
        public String ModuleName
        {
            get { return "Ekom HttpModule"; }
        }

        /// <summary>
        /// <see cref="IHttpModule"/> init method
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(Application_BeginRequest);
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext httpCtx = application.Context;

            var url = httpCtx.Request.Url;

            var storeSvc = Configuration.container.GetInstance<StoreService>();

            Store store = storeSvc.GetStoreByDomain(url.Host);

            if (store != null)
            {
                #region Currency 

                // Unfinished - move to currency service

                HttpCookie storeInfo = httpCtx.Request.Cookies["StoreInfo"];

                object Currency = storeInfo != null ? /* CurrencyHelper.Get(*/storeInfo.Values["Currency"] : null;

                #endregion

                var path = url.AbsolutePath.ToLower().AddTrailing();

                var appCtx = Configuration.container.GetInstance<ApplicationContext>();

                var appCache = appCtx.ApplicationCache;
                appCache.RequestCache.GetCacheItem("ekmRequest", () =>
                    new ContentRequest(new HttpContextWrapper(httpCtx), new LogFactory())
                    {
                        Store = store,
                        Currency = Currency,
                        DomainPrefix = path,
                    }
                );
            }
        }

        /// <summary>
        /// No actions needed
        /// </summary>
        public void Dispose() { }
    }
}