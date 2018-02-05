// <copyright file="DraliaRestRepo.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using RestSharp;

namespace MiddlewareLayerFramework.Repository
{
    /// <summary>
    /// Contains REST methods calls
    /// </summary>
    internal class DraliaRestRepo : IRestRepository
    {
        private string authValue { get; set; }

        public DraliaRestRepo(string authValueBase64)
        {
            authValue = authValueBase64;
        }

        #region GET's

        /// <summary>
        /// REST GET method call
        /// </summary>
        /// <param name="client"></param>
        /// <param name="endpoint"></param>
        /// <returns>REST response</returns>
        public IRestResponse Get(RestClient client, string endpoint) => client.Execute(new RestRequest(endpoint, Method.GET).AddHeader("Authorization", $"Basic {authValue}"));

        #endregion

        #region POST's

        /// <summary>
        /// REST POST method call
        /// </summary>
        /// <param name="client"></param>
        /// <param name="endpoint"></param>
        /// <param name="requestBody"></param>
        /// <returns>REST response</returns>
        public IRestResponse Post(RestClient client, string endpoint, string requestBody)
        {
            var request = new RestRequest(endpoint, Method.POST);
            request.Parameters.Clear();
            request.AddHeader("Authorization", $"Basic {authValue}");
            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            return client.Execute(request);
        }

        #endregion
    }
}
