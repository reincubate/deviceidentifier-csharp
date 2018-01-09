using RestSharp;

using System.Threading.Tasks;

namespace Reincubate.DeviceIdentifier
{
    static class RestCoreExtensions
    {
        public static IRestResponse Execute(this IRestClient @this, IRestRequest request)
        {
            TaskCompletionSource<IRestResponse> sync = new TaskCompletionSource<IRestResponse>();
            @this.ExecuteAsync(request, sync.SetResult);
            return sync.Task.Result;
        }
    }
}
