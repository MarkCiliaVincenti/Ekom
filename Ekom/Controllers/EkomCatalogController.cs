#if NETFRAMEWORK
using System.Web.Http;
#else
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endif
using Ekom.Utilities;
using System;
using Ekom.Models;
using Ekom.Exceptions;

namespace Ekom.Controllers
{
    /// <summary>
    /// Product catalog
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Reliability",
        "CA2007:Consider calling ConfigureAwait on the awaited task",
        Justification = "Async controller actions don't need ConfigureAwait")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "VSTHRD200:Use \"Async\" suffix for async methods",
        Justification = "Async controller action")]
#if NETFRAMEWORK
    public class EkomCatalogController : ApiController
    {
#else
    public class EkomCatalogController : ControllerBase
    {

#endif

        /// <summary>
        /// ctor
        /// </summary>
        public EkomCatalogController()
        {
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="Id">Guid Key of product</param>
        /// <returns></returns>
        public IProduct GetProduct(Guid Id)
        {
            try
            {
                return API.Catalog.Instance.GetProduct(Id);
            }
            catch (Exception ex) when (!(ex is HttpResponseException))
            {
                throw ExceptionHandler.Handle<HttpResponseException>(ex);
            }
        }
    }
}
