﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceServicesReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServicesServiceObj", Namespace="http://schemas.datacontract.org/2004/07/")]
    public partial class ServicesServiceObj : object
    {
        
        private string company_nameField;
        
        private int idField;
        
        private string nameField;
        
        private string typeField;
        
        private string unitField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string company_name
        {
            get
            {
                return this.company_nameField;
            }
            set
            {
                this.company_nameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceServicesReference.IServiceServices")]
    public interface IServiceServices
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/getServiceById", ReplyAction="http://tempuri.org/IServiceServices/getServiceByIdResponse")]
        System.Threading.Tasks.Task<ServiceServicesReference.ServicesServiceObj> getServiceByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/getServicesByBuilding_id", ReplyAction="http://tempuri.org/IServiceServices/getServicesByBuilding_idResponse")]
        System.Threading.Tasks.Task<ServiceServicesReference.ServicesServiceObj[]> getServicesByBuilding_idAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/getAllServices", ReplyAction="http://tempuri.org/IServiceServices/getAllServicesResponse")]
        System.Threading.Tasks.Task<ServiceServicesReference.ServicesServiceObj[]> getAllServicesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/createService", ReplyAction="http://tempuri.org/IServiceServices/createServiceResponse")]
        System.Threading.Tasks.Task<bool> createServiceAsync(string name, string type, string unit, string company_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/editService", ReplyAction="http://tempuri.org/IServiceServices/editServiceResponse")]
        System.Threading.Tasks.Task<bool> editServiceAsync(int id, string name, string type, string unit, string company_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/deleteService", ReplyAction="http://tempuri.org/IServiceServices/deleteServiceResponse")]
        System.Threading.Tasks.Task<bool> deleteServiceAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/deleteAllService_Building", ReplyAction="http://tempuri.org/IServiceServices/deleteAllService_BuildingResponse")]
        System.Threading.Tasks.Task<bool> deleteAllService_BuildingAsync(int public_services_id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IServiceServicesChannel : ServiceServicesReference.IServiceServices, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class ServiceServicesClient : System.ServiceModel.ClientBase<ServiceServicesReference.IServiceServices>, ServiceServicesReference.IServiceServices
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ServiceServicesClient() : 
                base(ServiceServicesClient.GetDefaultBinding(), ServiceServicesClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IServiceServices.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceServicesClient(EndpointConfiguration endpointConfiguration) : 
                base(ServiceServicesClient.GetBindingForEndpoint(endpointConfiguration), ServiceServicesClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceServicesClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ServiceServicesClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceServicesClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ServiceServicesClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ServiceServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceServicesReference.ServicesServiceObj> getServiceByIdAsync(int id)
        {
            return base.Channel.getServiceByIdAsync(id);
        }
        
        public System.Threading.Tasks.Task<ServiceServicesReference.ServicesServiceObj[]> getServicesByBuilding_idAsync(int id)
        {
            return base.Channel.getServicesByBuilding_idAsync(id);
        }
        
        public System.Threading.Tasks.Task<ServiceServicesReference.ServicesServiceObj[]> getAllServicesAsync()
        {
            return base.Channel.getAllServicesAsync();
        }
        
        public System.Threading.Tasks.Task<bool> createServiceAsync(string name, string type, string unit, string company_name)
        {
            return base.Channel.createServiceAsync(name, type, unit, company_name);
        }
        
        public System.Threading.Tasks.Task<bool> editServiceAsync(int id, string name, string type, string unit, string company_name)
        {
            return base.Channel.editServiceAsync(id, name, type, unit, company_name);
        }
        
        public System.Threading.Tasks.Task<bool> deleteServiceAsync(int id)
        {
            return base.Channel.deleteServiceAsync(id);
        }
        
        public System.Threading.Tasks.Task<bool> deleteAllService_BuildingAsync(int public_services_id)
        {
            return base.Channel.deleteAllService_BuildingAsync(public_services_id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceServices))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IServiceServices))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:62024/Service.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ServiceServicesClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IServiceServices);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ServiceServicesClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IServiceServices);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IServiceServices,
        }
    }
}
