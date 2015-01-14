namespace CCS.Services.WebApi
{
    using CCS.Data.UCare;
    using Data;
    using Microsoft.Practices.Unity;
    using System.Web.Http;
    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IUCareDataContext, UCareDataContext>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}