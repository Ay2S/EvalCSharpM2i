using EvalTechnique.Business;
using System;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace EvalTechnique.Server
{
    public static class ServerHelper
    {
        private static string BaseAddress = "http://localhost:36990/";
        private static ServiceHost serviceHost = null;

        public static bool StartService<IServiceType>()
        {
            try
            {
                // TODO DONE: Search serviceType class (wich implements IServiceType) using reflection in Business assembly 

                var x = typeof(VideoDataBaseService).Assembly;

                Type[] businessServices =
                    Assembly.Load("EvalTechnique.Business, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                    .GetTypes()
                    .Where(t =>
                        t.GetInterfaces()
                        .Any(i => i.CustomAttributes.Any(att => att.AttributeType == typeof(ServiceContractAttribute)) && i.Name.EndsWith("Service")))
                    .ToArray();

                Type serviceType = businessServices.FirstOrDefault(type =>
                    type.Equals(typeof(IServiceType))
                    || type.GetInterfaces().Any(i => i.Equals(typeof(IServiceType))));

                serviceHost = new ServiceHost(serviceType, new Uri(BaseAddress));

                var behaviour = serviceHost.Description.Behaviors.Find<ServiceBehaviorAttribute>();
                behaviour.InstanceContextMode = InstanceContextMode.Single;

                BasicHttpBinding webHttpBinding = new BasicHttpBinding();
                ServiceEndpoint endPoint = serviceHost.AddServiceEndpoint(
                    typeof(IServiceType),
                    webHttpBinding,
                    BaseAddress + typeof(IServiceType).Name);

                serviceHost.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool StopService()
        {
            try
            {
                serviceHost.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
