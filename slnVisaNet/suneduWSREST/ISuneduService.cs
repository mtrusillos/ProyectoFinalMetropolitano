using suneduWSREST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace suneduWSREST
{   
    [ServiceContract]
    public interface ISuneduService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "carnets/{codcarnet}", ResponseFormat = WebMessageFormat.Json)]
        CARNET ObtenerHorario(string codcarnet);
    }
}
