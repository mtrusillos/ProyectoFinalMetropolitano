using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using visanetSOAP.Dominio;
using visanetSOAP.Errores;

namespace visanetSOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [FaultContract(typeof(ErroresExceptions))]

        [OperationContract]
        int ValidarPagoVisaNet(TC_Visa tarjeta);
    }

}