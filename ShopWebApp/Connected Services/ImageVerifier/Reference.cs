﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopWebApp.ImageVerifier {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ImageVerifier.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetVerifierString", ReplyAction="http://tempuri.org/IService/GetVerifierStringResponse")]
        string GetVerifierString(string myLength);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetVerifierString", ReplyAction="http://tempuri.org/IService/GetVerifierStringResponse")]
        System.Threading.Tasks.Task<string> GetVerifierStringAsync(string myLength);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetImage", ReplyAction="http://tempuri.org/IService/GetImageResponse")]
        System.IO.Stream GetImage(string myString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetImage", ReplyAction="http://tempuri.org/IService/GetImageResponse")]
        System.Threading.Tasks.Task<System.IO.Stream> GetImageAsync(string myString);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ShopWebApp.ImageVerifier.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ShopWebApp.ImageVerifier.IService>, ShopWebApp.ImageVerifier.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetVerifierString(string myLength) {
            return base.Channel.GetVerifierString(myLength);
        }
        
        public System.Threading.Tasks.Task<string> GetVerifierStringAsync(string myLength) {
            return base.Channel.GetVerifierStringAsync(myLength);
        }
        
        public System.IO.Stream GetImage(string myString) {
            return base.Channel.GetImage(myString);
        }
        
        public System.Threading.Tasks.Task<System.IO.Stream> GetImageAsync(string myString) {
            return base.Channel.GetImageAsync(myString);
        }
    }
}
