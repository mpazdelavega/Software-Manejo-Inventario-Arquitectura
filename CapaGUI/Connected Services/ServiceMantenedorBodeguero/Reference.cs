﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaGUI.ServiceMantenedorBodeguero {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoap")]
    public interface WebServiceMantenedorBodegueroSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/webGuardarTransaccionBodeguero", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void webGuardarTransaccionBodeguero(CapaGUI.ServiceMantenedorBodeguero.bodeguero bod);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/webGuardarTransaccionBodeguero", ReplyAction="*")]
        System.Threading.Tasks.Task webGuardarTransaccionBodegueroAsync(CapaGUI.ServiceMantenedorBodeguero.bodeguero bod);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/webActualizarBodeguero", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void webActualizarBodeguero(CapaGUI.ServiceMantenedorBodeguero.bodeguero bodeguero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/webActualizarBodeguero", ReplyAction="*")]
        System.Threading.Tasks.Task webActualizarBodegueroAsync(CapaGUI.ServiceMantenedorBodeguero.bodeguero bodeguero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/webEliminarBodeguero", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void webEliminarBodeguero(string rut_bodeguero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/webEliminarBodeguero", ReplyAction="*")]
        System.Threading.Tasks.Task webEliminarBodegueroAsync(string rut_bodeguero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/webPosicionBodeguero", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        CapaGUI.ServiceMantenedorBodeguero.bodeguero webPosicionBodeguero(int pos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/webPosicionBodeguero", ReplyAction="*")]
        System.Threading.Tasks.Task<CapaGUI.ServiceMantenedorBodeguero.bodeguero> webPosicionBodegueroAsync(int pos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/webConsultaBodeguero", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet webConsultaBodeguero();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/webConsultaBodeguero", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> webConsultaBodegueroAsync();
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class bodeguero : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string rut_bodegueroField;
        
        private string nombre_bodegueroField;
        
        private string apellido_bodegueroField;
        
        private string genero_bodegueroField;
        
        private string correo_bodegueroField;
        
        private int telefono_bodegueroField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Rut_bodeguero {
            get {
                return this.rut_bodegueroField;
            }
            set {
                this.rut_bodegueroField = value;
                this.RaisePropertyChanged("Rut_bodeguero");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Nombre_bodeguero {
            get {
                return this.nombre_bodegueroField;
            }
            set {
                this.nombre_bodegueroField = value;
                this.RaisePropertyChanged("Nombre_bodeguero");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Apellido_bodeguero {
            get {
                return this.apellido_bodegueroField;
            }
            set {
                this.apellido_bodegueroField = value;
                this.RaisePropertyChanged("Apellido_bodeguero");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Genero_bodeguero {
            get {
                return this.genero_bodegueroField;
            }
            set {
                this.genero_bodegueroField = value;
                this.RaisePropertyChanged("Genero_bodeguero");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Correo_bodeguero {
            get {
                return this.correo_bodegueroField;
            }
            set {
                this.correo_bodegueroField = value;
                this.RaisePropertyChanged("Correo_bodeguero");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int Telefono_bodeguero {
            get {
                return this.telefono_bodegueroField;
            }
            set {
                this.telefono_bodegueroField = value;
                this.RaisePropertyChanged("Telefono_bodeguero");
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
    public interface WebServiceMantenedorBodegueroSoapChannel : CapaGUI.ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebServiceMantenedorBodegueroSoapClient : System.ServiceModel.ClientBase<CapaGUI.ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoap>, CapaGUI.ServiceMantenedorBodeguero.WebServiceMantenedorBodegueroSoap {
        
        public WebServiceMantenedorBodegueroSoapClient() {
        }
        
        public WebServiceMantenedorBodegueroSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebServiceMantenedorBodegueroSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceMantenedorBodegueroSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebServiceMantenedorBodegueroSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void webGuardarTransaccionBodeguero(CapaGUI.ServiceMantenedorBodeguero.bodeguero bod) {
            base.Channel.webGuardarTransaccionBodeguero(bod);
        }
        
        public System.Threading.Tasks.Task webGuardarTransaccionBodegueroAsync(CapaGUI.ServiceMantenedorBodeguero.bodeguero bod) {
            return base.Channel.webGuardarTransaccionBodegueroAsync(bod);
        }
        
        public void webActualizarBodeguero(CapaGUI.ServiceMantenedorBodeguero.bodeguero bodeguero) {
            base.Channel.webActualizarBodeguero(bodeguero);
        }
        
        public System.Threading.Tasks.Task webActualizarBodegueroAsync(CapaGUI.ServiceMantenedorBodeguero.bodeguero bodeguero) {
            return base.Channel.webActualizarBodegueroAsync(bodeguero);
        }
        
        public void webEliminarBodeguero(string rut_bodeguero) {
            base.Channel.webEliminarBodeguero(rut_bodeguero);
        }
        
        public System.Threading.Tasks.Task webEliminarBodegueroAsync(string rut_bodeguero) {
            return base.Channel.webEliminarBodegueroAsync(rut_bodeguero);
        }
        
        public CapaGUI.ServiceMantenedorBodeguero.bodeguero webPosicionBodeguero(int pos) {
            return base.Channel.webPosicionBodeguero(pos);
        }
        
        public System.Threading.Tasks.Task<CapaGUI.ServiceMantenedorBodeguero.bodeguero> webPosicionBodegueroAsync(int pos) {
            return base.Channel.webPosicionBodegueroAsync(pos);
        }
        
        public System.Data.DataSet webConsultaBodeguero() {
            return base.Channel.webConsultaBodeguero();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> webConsultaBodegueroAsync() {
            return base.Channel.webConsultaBodegueroAsync();
        }
    }
}
