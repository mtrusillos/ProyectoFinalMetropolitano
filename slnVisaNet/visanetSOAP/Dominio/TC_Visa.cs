using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace visanetSOAP.Dominio
{
    [DataContract]
    public class TC_Visa
    {
        [DataMember]
        public string NRO_TARJETA { get; set; }

        [DataMember]
        public string CVV_TARJETA { get; set; }

        [DataMember]
        public string VENC_TARJETA { get; set; }

        [DataMember]
        public string TIT_TARJETA { get; set; }

        [DataMember]
        public string ESTADO_TARJETA { get; set; }

        [DataMember]
        public decimal MONTO_CARGA { get; set; }


    }
}