namespace Endpoint.Api.ViewModel
{
    public class LinkDto
    {
        public LinkDto(string url, string rEl, string method)
        {
            Url = url;
            REl = rEl;
            Method = method;
        }
        public string Url { get;private set; }
        public string REl { get;private set; }
        public string Method { get;private set; }
    }
}
