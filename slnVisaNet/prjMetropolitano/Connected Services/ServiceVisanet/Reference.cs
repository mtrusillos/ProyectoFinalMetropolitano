﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjMetropolitano.ServiceVisanet {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TC_Visa", Namespace="http://schemas.datacontract.org/2004/07/visanetSOAP.Dominio")]
    [System.SerializableAttribute()]
    public partial class TC_Visa : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CVV_TARJETAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ESTADO_TARJETAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal MONTO_CARGAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NRO_TARJETAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TIT_TARJETAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VENC_TARJETAField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CVV_TARJETA {
            get {
                return this.CVV_TARJETAField;
            }
            set {
                if ((object.ReferenceEquals(this.CVV_TARJETAField, value) != true)) {
                    this.CVV_TARJETAField = value;
                    this.RaisePropertyChanged("CVV_TARJETA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ESTADO_TARJETA {
            get {
                return this.ESTADO_TARJETAField;
            }
            set {
                if ((object.ReferenceEquals(this.ESTADO_TARJETAField, value) != true)) {
                    this.ESTADO_TARJETAField = value;
                    this.RaisePropertyChanged("ESTADO_TARJETA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal MONTO_CARGA {
            get {
                return this.MONTO_CARGAField;
            }
            set {
                if ((object.ReferenceEquals(this.MONTO_CARGAField, value) != true)) {
                    this.MONTO_CARGAField = value;
                    this.RaisePropertyChanged("MONTO_CARGA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NRO_TARJETA {
            get {
                return this.NRO_TARJETAField;
            }
            set {
                if ((object.ReferenceEquals(this.NRO_TARJETAField, value) != true)) {
                    this.NRO_TARJETAField = value;
                    this.RaisePropertyChanged("NRO_TARJETA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TIT_TARJETA {
            get {
                return this.TIT_TARJETAField;
            }
            set {
                if ((object.ReferenceEquals(this.TIT_TARJETAField, value) != true)) {
                    this.TIT_TARJETAField = value;
                    this.RaisePropertyChanged("TIT_TARJETA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string VENC_TARJETA {
            get {
                return this.VENC_TARJETAField;
            }
            set {
                if ((object.ReferenceEquals(this.VENC_TARJETAField, value) != true)) {
                    this.VENC_TARJETAField = value;
                    this.RaisePropertyChanged("VENC_TARJETA");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ErroresExceptions", Namespace="http://schemas.datacontract.org/2004/07/visanetSOAP.Errores")]
    [System.SerializableAttribute()]
    public partial class ErroresExceptions : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoField, value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceVisanet.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ValidarPagoVisaNet", ReplyAction="http://tempuri.org/IService1/ValidarPagoVisaNetResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(prjMetropolitano.ServiceVisanet.ErroresExceptions), Action="http://tempuri.org/IService1/ValidarPagoVisaNetErroresExceptionsFault", Name="ErroresExceptions", Namespace="http://schemas.datacontract.org/2004/07/visanetSOAP.Errores")]
        int ValidarPagoVisaNet(prjMetropolitano.ServiceVisanet.TC_Visa tarjeta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ValidarPagoVisaNet", ReplyAction="http://tempuri.org/IService1/ValidarPagoVisaNetResponse")]
        System.Threading.Tasks.Task<int> ValidarPagoVisaNetAsync(prjMetropolitano.ServiceVisanet.TC_Visa tarjeta);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : prjMetropolitano.ServiceVisanet.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<prjMetropolitano.ServiceVisanet.IService1>, prjMetropolitano.ServiceVisanet.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int ValidarPagoVisaNet(prjMetropolitano.ServiceVisanet.TC_Visa tarjeta) {
            return base.Channel.ValidarPagoVisaNet(tarjeta);
        }
        
        public System.Threading.Tasks.Task<int> ValidarPagoVisaNetAsync(prjMetropolitano.ServiceVisanet.TC_Visa tarjeta) {
            return base.Channel.ValidarPagoVisaNetAsync(tarjeta);
        }
    }
}