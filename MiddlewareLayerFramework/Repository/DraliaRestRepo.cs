using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLayerFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    internal class DraliaRestRepo : IRestRepository
    {

        #region GET's

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public IRestResponse Get(RestClient client) => client.Execute(new RestRequest(Method.GET));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public IRestResponse Get(RestClient client, string endpoint) => client.Execute(new RestRequest(endpoint, Method.GET));

        #endregion

        #region POST's

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public IRestResponse Post(RestClient client, string endpoint) => client.Execute(new RestRequest(endpoint, Method.POST));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="endpoint"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public IRestResponse Post(RestClient client, string endpoint, string requestBody)
        {
            var request = new RestRequest(endpoint, Method.POST);

            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", requestBody, ParameterType.RequestBody);

            return client.Execute(request);
        }



        #endregion
    }
}
