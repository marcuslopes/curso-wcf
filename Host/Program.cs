using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Modelo.Contratos;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            CriarHost();
            CriarHostRest();
            Console.ReadLine();
        }

        private static void CriarHost()
        {
            // A + B + C
            string address = string.Format("http://{0}:9000/Servico/NFE", Environment.MachineName);

            Console.WriteLine(address);

            //Binding = Letra B
            BasicHttpBinding binding = new BasicHttpBinding();

            ServiceHost host = new ServiceHost(typeof(NFE), new Uri(address));

            host.AddServiceEndpoint(
                typeof (INFE), binding, new Uri(address));

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior()
            {
                HttpGetEnabled = true
            };

            host.Description.Behaviors.Add(smb);

            host.Open();

        }

        private static void CriarHostRest()
        {
            // A + B + C
            string address = string.Format("http://{0}:9001/Servico/NFE/", Environment.MachineName);

            Console.WriteLine(address);

            //Binding = Letra B
            WebHttpBinding binding = new WebHttpBinding();

            WebServiceHost host = new WebServiceHost(typeof(NFERest), new Uri(address));

            host.AddServiceEndpoint(
                typeof(INFERNO), binding, new Uri(address));

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior()
            {
                HttpGetEnabled = true
            };

            host.Description.Behaviors.Add(smb);

            host.AddServiceEndpoint(typeof (IMetadataExchange), 
                MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            host.Open();

        }
    }
}
