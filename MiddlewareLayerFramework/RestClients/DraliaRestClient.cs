// <copyright file="DraliaRestClient.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using MiddlewareLayerFramework.Repository;
using RestSharp;
using RestSharp.Authenticators;
using System.Configuration;

namespace MiddlewareLayerFramework.RestClients
{
    /// <summary>
    /// Rest client handles REST API requests 
    /// </summary>
    public class DraliaRestClient
    {
        private RestClient DraliaClient;
        private DraliaRestRepo repo;
        private string _authValueBase64;

        public DraliaRestClient(string baseUrl)
        {
            DraliaClient = new RestClient(baseUrl);
            DraliaClient.ClearHandlers();
            DraliaClient.Authenticator = new NtlmAuthenticator();

            _authValueBase64 = ConfigurationManager.AppSettings["authValue"];
            repo = new DraliaRestRepo(_authValueBase64);
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
            (sender, certificate, chain, errors) => true;
        }


        #region GET's

        /// <summary>
        /// REST GET request
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns>REST response</returns>
        public IRestResponse Get(string endpoint) => repo.Get(DraliaClient, endpoint);

        #endregion

        #region POST's

        /// <summary>
        /// REST GET request
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="json"></param>
        /// <returns>REST response</returns>
        public IRestResponse Post(string endpoint, string json) => repo.Post(DraliaClient, endpoint, json);

        #endregion

    }
}
