using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Modelo.Contratos;
using Modelo.Modelos.NFE;

namespace Host
{
    public class NFERest : INFERNO
    {
        public void EnviarNFE(RequestNFE request)
        {
            throw new NotImplementedException();
        }


        [WebInvoke(Method = "GET", UriTemplate =  "nota/{numeroNota}",
            ResponseFormat = WebMessageFormat.Json)]
        public ResponseNFE NfeAssinada(string numeroNota)
        {
            return new ResponseNFE()
            {
                Assinatura = Guid.NewGuid().ToString(),
                CNPJ = "111.111.111/0001-24",
                ISS = 6.5m,
                Valor = 1000,
                RazaoSocial = "PTs Association"
           };
        }


    }

    [ServiceContract]
    public interface INFERNO
    {
        [OperationContract]
        ResponseNFE NfeAssinada(string numeroNota);
    }
}
