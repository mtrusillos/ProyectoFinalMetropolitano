using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using visanetSOAP.Dominio;
using visanetSOAP.Persistencia;

namespace visanetSOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        private TC_VisaDAO visaDAO = new TC_VisaDAO();

        public int ValidarPagoVisaNet(TC_Visa tarjeta)
        {
            if  (visaDAO.ValidarPago(tarjeta))
            {
                return 1;
            }
            else {
                return 0;
            }
        }
    }
}
