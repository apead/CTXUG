namespace AdSoftwareSystems.Tracking.Mobile.Core.Services.Rest
{
    using System;

    public interface ISimpleRestService
    {
        void MakeRequest<T>(string requestUrl, string verb, Action<T> successAction, Action<Exception> errorAction);
    }
}