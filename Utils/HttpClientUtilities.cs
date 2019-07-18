using System.Net.Http;

namespace Utils
{
    public static class HttpClientUtilities
    {
        public static void TryAppendingSecurityToken(this HttpClient httpService, string token)
        {
            var headerName = "Brainshark-SToK";
            if(!httpService.DefaultRequestHeaders.Contains(headerName))
                httpService.DefaultRequestHeaders.Add(headerName, token);
        }
    }
}