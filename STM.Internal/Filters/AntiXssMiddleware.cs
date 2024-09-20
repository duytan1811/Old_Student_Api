namespace STM.API.Filters
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Ganss.Xss;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using STM.API.Responses.Base;
    using STM.Common.Constants;
    using STM.Common.Utilities;

    public class AntiXssMiddleware
    {
        private readonly RequestDelegate _next;

        public AntiXssMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // check ATTT
            // enable buffering so that the request can be read by the model binders next
            httpContext.Request.EnableBuffering();

            var contentTypeWhiteList = new List<string>()
            {
                "multipart/form-data",
            };

            if (httpContext.Request.ContentType == null || !httpContext.Request.ContentType.Contains(string.Join(';', contentTypeWhiteList)))
            {
                // leaveOpen: true to leave the stream open after disposing,
                // so it can be read by the model binders
                using (var streamReader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, leaveOpen: true))
                {
                    var raw = await streamReader.ReadToEndAsync();
                    var sanitiser = new HtmlSanitizer();
                    var sanitised = sanitiser.Sanitize(raw);

                    if (!raw.CompareText(sanitised))
                    {
                        await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse<bool>()
                        {
                            Type = GlobalConstants.Error,
                            Message = "XssError",
                        }));

                        return;
                    }
                }
            }

            // rewind the stream for the next middleware
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            await this._next.Invoke(httpContext);
        }
    }
}
