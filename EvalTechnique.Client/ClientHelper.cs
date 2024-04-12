using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace EvalTechnique.Client
{
    public static class ClientHelper
    {
        public static IServiceType GetService<IServiceType>(string address) 
        {
            BasicHttpBinding webHttpBinding = new BasicHttpBinding();

            EndpointAddress endPointAddress = new EndpointAddress(new Uri(address));

            ChannelFactory<IServiceType> factory = new ChannelFactory<IServiceType>(webHttpBinding, endPointAddress);
            
            return factory.CreateChannel();
        }
    }
}
