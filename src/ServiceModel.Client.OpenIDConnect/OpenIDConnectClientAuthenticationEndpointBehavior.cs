﻿using System.Net.Http;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System;

namespace Morgados.ServiceModel.Client.OpenIDConnect
{
    public sealed class OpenIDConnectClientAuthenticationEndpointBehavior : IEndpointBehavior
    {
        private readonly Func<HttpClient> httpClientFactory;

        public OpenIDConnectClientAuthenticationEndpointBehavior(Func<HttpClient> httpClientFactory)
            => this.httpClientFactory = httpClientFactory;

        public void Validate(ServiceEndpoint endpoint) { }
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new OpenIDConnectClientMessageInspector(this.httpClientFactory));
        }
    }
}
