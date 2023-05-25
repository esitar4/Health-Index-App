using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PexelsDotNetSDK.Api;

namespace health_index_app.Shared.PexelsAPI
{
    public class PexelsAPIClient
    {
        public static async Task<string> searchImage(string searchExpression)
        {
            var pexelsClient = new PexelsClient("ymYbt0oDXezqVvURIKu4YPPIQnHC2WkrcKerJV39NxomWTYYhP4nerAf");

            var result = await pexelsClient.SearchPhotosAsync(searchExpression, pageSize: 1);
            var ret = result.photos.FirstOrDefault().url;
            var result1 = await pexelsClient.SearchPhotosAsync("apple", pageSize: 1);

            return ret;
        }
    }
}
