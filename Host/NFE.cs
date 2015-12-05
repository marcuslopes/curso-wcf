using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Contratos;
using Modelo.Modelos.NFE;

namespace Host
{
    public class NFE : INFE
    {
        public void EnviarNFE(RequestNFE request)
        {
            throw new NotImplementedException();
        }

        public ResponseNFE NfeAssinada(int numeroNota)
        {
            return new ResponseNFE()
            {
                Assinatura = Guid.NewGuid().ToString(),
                CNPJ = "111.111.111/0001-24",
                ISS = 6.5m,
                Valor = 1000,
                RazaoSocial = "PTs Association"
//            };
        }
    }
}
