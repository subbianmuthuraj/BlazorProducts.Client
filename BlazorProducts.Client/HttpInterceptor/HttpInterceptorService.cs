using Microsoft.AspNetCore.Components;
using System.Net;
using Toolbelt.Blazor;

namespace BlazorProducts.Client.HttpInterceptor
{
    public class HttpInterceptorService
    {
        private readonly HttpClientInterceptor _interceptor;
        private readonly NavigationManager _navManager;
        public HttpInterceptorService(HttpClientInterceptor interceptor, NavigationManager navManager)
        {
            _interceptor = interceptor;
            _navManager = navManager;

        }

        public void RegisterEvent() => _interceptor.AfterSend += HandleResponse;
        public void DisposeEvent() => _interceptor.AfterSend -= HandleResponse;

        private void HandleResponse(object? sender, HttpClientInterceptorEventArgs e)
        {
            if (e.Response == null)
            {
                _navManager.NavigateTo("/error");
                throw new HttpResponseException("Server Not Available");
            }
            var message = "";
            if (!e.Response.IsSuccessStatusCode)
            {
                switch (e.Response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        _navManager.NavigateTo("/404");
                        message = "Resource Not Found.";
                        break;
                    case HttpStatusCode.Unauthorized:
                        _navManager.NavigateTo("/unauthorized");
                        message = "Unauthorized access";
                        break;
                    default:
                        _navManager.NavigateTo("/error");
                        message = "Something Went Wrong..Plesae contact Administator...";
                        break;
                }
                throw new HttpResponseException(message);
            }

        }
    }
}
