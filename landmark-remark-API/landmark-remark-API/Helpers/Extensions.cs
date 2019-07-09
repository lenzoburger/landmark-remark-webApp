using Microsoft.AspNetCore.Http;

namespace landmark_remark_API.Helpers
{
    // Helper extension methods
    public static class Extensions
    {
        // Append errors onto Http Response Header
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}