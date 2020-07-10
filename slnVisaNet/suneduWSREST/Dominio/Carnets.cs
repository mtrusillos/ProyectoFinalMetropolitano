using System;
using System.Runtime.Serialization;

namespace suneduWSREST.Dominio

{
    [DataContract]
    public class Carnets
    {
        [DataMember]
        public string COD_CARNET { get; set; }

        [DataMember]
        public string DNI_ALUMNO { get; set; }

        [DataMember]
        public string UNI_ALUMNO { get; set; }

        [DataMember]
        public System.DateTime FECEXP_ALUMNO { get; set; }
        
      }
}