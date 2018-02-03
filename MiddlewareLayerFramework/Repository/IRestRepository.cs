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
    interface IRestRepository
    {
        IRestResponse Get(RestClient client);
        IRestResponse Get(RestClient client, string endpoint);
        IRestResponse Post(RestClient client, string endpoint);
        IRestResponse Post(RestClient client, string endpoint, string requestBody);

    }
}
