using MiddlewareLayerFramework.Repository;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareLayerFramework
{
    public class DraliaRestClient
    {
        private RestClient DraliaClient;
        private DraliaRestRepo repo;

        public DraliaRestClient(string baseUrl)
        {
            DraliaClient = new RestClient(baseUrl);
            DraliaClient.ClearHandlers();

            repo = new DraliaRestRepo();
        }


        #region GET's

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public IRestResponse Get(string endpoint) => repo.Get(DraliaClient, endpoint);

        #endregion

        #region POST's


        #endregion

    }
}
