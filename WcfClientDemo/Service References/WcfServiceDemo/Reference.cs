﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfClientDemo.WcfServiceDemo {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfServiceDemo.IUser")]
    public interface IUser {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/ShowName", ReplyAction="http://tempuri.org/IUser/ShowNameResponse")]
        string ShowName(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserChannel : WcfClientDemo.WcfServiceDemo.IUser, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserClient : System.ServiceModel.ClientBase<WcfClientDemo.WcfServiceDemo.IUser>, WcfClientDemo.WcfServiceDemo.IUser {
        
        public UserClient() {
        }
        
        public UserClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ShowName(string name) {
            return base.Channel.ShowName(name);
        }
    }
}