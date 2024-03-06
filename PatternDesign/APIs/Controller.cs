using Brokip.TradeIn.Api.Filters;
using Brokip.TradeIn.Api.Models;
using Microsoft.Web.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Brokip.TradeIn.Api.Services;
using Brokip.TradeIn.Api.Attributes;
using Brokip.MsCrm.Utiles;

namespace Brokip.TradeIn.Api.Controllers.v1
{
    /// <summary>
    /// Controlador de Ofertas
    /// </summary>
    [ApiVersion("v1")]
    [Route("api/v1/quote")]
    [DisplayName("Quote")]
    [Authorize]
    public class QuotesV1Controller : ApiController
    {

        /// <summary>
        /// Crea una oferta y se obtien su Id a partir de un objeto Oferta.
        /// </summary>
        /// <remarks>
        /// Aquí una descripción mas larga si fuera necesario. Obtiene un objeto por su Id.
        /// </remarks>
        /// <param name="quote">Oferta a crear</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [SwaggerOperation("Crear Oferta")]
        [SwaggerResponse(HttpStatusCode.OK,"", typeof(ApiResponse<Quote>))]
        [WrapResponseInData]
        [HttpPost(), ScopeAuthorize("write")]
        public Quote Create(QuoteV1CreateReq quote)
        {
            Trace.TraceInformation($"QuotesV1Controller > post - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} and following Json: {JsonConvert.SerializeObject(quote)}");
            try
            {
                var e_quote = quote.Create();
                var result = new Quote(e_quote);

                Trace.TraceInformation($"QuotesV1Controller > post > Response OK - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} and following Json: {JsonConvert.SerializeObject(result)}");
                return result;
            }
            catch (HttpResponseException ex)
            {
                Trace.TraceError($"QuotesV1Controller > post > HttpResponseException - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} Error: {ex.Message}");
                throw ex;
            }
            catch (Exception ex)
            {
                Trace.TraceError($"QuotesV1Controller > post > Exception - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} Error: {ex.Message}");
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
                //throw new HttpResponseException(Errors.CreateResponse(Request, System.Net.HttpStatusCode.InternalServerError, 9999));
            }
        }

        /// <summary>
        /// Obtener la Oferta.
        /// </summary>
        /// <remarks>
        /// Obtener objeto Oferta a partir del ID
        /// </remarks>
        /// <param name="quote">Oferta a crear</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token de acceso.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        [SwaggerOperation("Obtener la Oferta")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(ApiResponse<Quote>))]
        [WrapResponseInData]
        [Route("api/v1/quote/{id}"), HttpGet(), ScopeAuthorize("read")]
        public Quote GetQuote(Guid id)
        {
            Trace.TraceInformation($"QuotesV1Controller > get - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} and following Id: {JsonConvert.SerializeObject(id)}");
            try
            {

                Services.MsCrm.Utiles.Singleton crmUtiles = Services.MsCrm.Utiles.Singleton.Instance;
                var a = crmUtiles.ServiceProxy.Retrieve("quote", id, new Microsoft.Xrm.Sdk.Query.ColumnSet("name"));

                var result = new Quote(id);

                Trace.TraceInformation($"QuotesV1Controller > get > Response OK - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} and following Json: {JsonConvert.SerializeObject(result)}");
                return result;
            }
            catch (HttpResponseException ex)
            {
                Trace.TraceError($"QuotesV1Controller > get > HttpResponseException - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} Error: {ex.Message}");
                throw ex;
            }
            catch (Exception ex)
            {
                Trace.TraceError($"QuotesV1Controller > get > Exception - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} Error: {ex.Message}");
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
                //throw new HttpResponseException(Errors.CreateResponse(Request, System.Net.HttpStatusCode.InternalServerError, 9999));
            }
        }


        /// <summary>
        /// Deshabilitar una oferta por su ID.
        /// </summary>
        /// <remarks>
        /// Este endpoint deshabilita una oferta identificada por su ID.
        /// </remarks>
        /// <param name="id">El ID de la oferta a deshabilitar.</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token de acceso.</response>              
        /// <response code="200">OK. La oferta se ha deshabilitado con éxito.</response>
        [SwaggerOperation("Deshabilitar una oferta por su ID.")]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(ApiResponse<Boolean>))]
        [WrapResponseInData]
        [Route("api/v1/quote/{id}"), HttpPatch(), ScopeAuthorize("write")]
        public Boolean DisabledQuote(Guid id)
        {
            Trace.TraceInformation($"QuotesV1Controller > get - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} and following Id: {JsonConvert.SerializeObject(id)}");
            try
            {
                Quote quote = new Quote(id);
                bool result = quote.Delete();

                Trace.TraceInformation($"QuotesV1Controller > get > Response OK - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} and following Json: {JsonConvert.SerializeObject(result)}");
                return result;
            }
            catch (HttpResponseException ex)
            {
                Trace.TraceError($"QuotesV1Controller > get > HttpResponseException - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} Error: {ex.Message}");
                throw ex;
            }
            catch (Exception ex)
            {
                Trace.TraceError($"QuotesV1Controller > get > Exception - {HttpContext.Current.Request.UserHostAddress} - using the following URL: {HttpContext.Current.Request.Url} Error: {ex.Message}");
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
                //throw new HttpResponseException(Errors.CreateResponse(Request, System.Net.HttpStatusCode.InternalServerError, 9999));
            }
        }
    }
}