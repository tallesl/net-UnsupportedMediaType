namespace UnsupportedMediaTypeLibrary
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// DelegatingHandler that checks the request Content-Type and gives 415 (UnsupportedMediaType) if there isn't a
    /// configured formatter for such media type.
    /// </summary>
    public class UnsupportedMediaTypeHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var formatters = request.GetConfiguration().Formatters;
            var contentType = request.Content.Headers.ContentType;
            Func<HttpResponseMessage> unsupportedMediaType =
                () => new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);

            return formatters.Any(f => f.SupportedMediaTypes.Contains(contentType)) ?
                base.SendAsync(request, cancellationToken) :
                Task<HttpResponseMessage>.Factory.StartNew(unsupportedMediaType);
        }
    }
}
