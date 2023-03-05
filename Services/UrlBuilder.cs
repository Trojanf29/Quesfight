namespace QuesFight.Services
{
    public class UrlBuilder
    {
        public string url;
        private bool hasQueryParam;

        public UrlBuilder(string url)
        {
            this.url = url;
        }

        public void AddParam(string param, string value)
        {
            if (!hasQueryParam)
            {
                url += '?';
                hasQueryParam = true;
            else
            {
                url += '&';
            }
            url += param + '=' + value;
        }
    }
}
// maybe this services should be in Helper/ Shared/ Utils services
