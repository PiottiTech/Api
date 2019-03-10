using PiottiTech.Common;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PiottiTech.Api
{
    public class BaseApiController : ApiController
    {
        protected HttpResponseMessage ProcessedRequest<T>(T obj)
        {
            return Request.CreateResponse<T>(HttpStatusCode.OK, obj, "application/json");
        }

        #region ProcessedRequestLogException - free logging, automattically news up ApiResult, before calling ProcessedRequest

        protected HttpResponseMessage ProcessedRequestLogException(Exception ex, string message, Object obj)
        {
            ApiResult apiResult = new ApiResult(message, ex);
            return ProcessedRequest(apiResult);
        }

        protected HttpResponseMessage ProcessedRequestLogException(Exception ex, string message)
        {
            ApiResult apiResult = new ApiResult(message, ex);
            return ProcessedRequest(apiResult);
        }

        protected HttpResponseMessage ProcessedRequestLogException(Exception ex, Object obj)
        {
            ApiResult apiResult = new ApiResult(ex);
            return ProcessedRequest(apiResult);
        }

        protected HttpResponseMessage ProcessedRequestLogException(Exception ex)
        {
            ApiResult apiResult = new ApiResult(ex);
            return ProcessedRequest(apiResult);
        }

        protected HttpResponseMessage ProcessedRequestNoPostBody(Object obj)
        {
            string mssg = "POST body is empty. Request could not be processed.";
            Logger.Log(mssg + obj.ToString());
            ApiResult apiResult = new ApiResult(false, mssg);
            return ProcessedRequest(apiResult);
        }

        #endregion ProcessedRequestLogException - free logging, automattically news up ApiResult, before calling ProcessedRequest
    }
}

