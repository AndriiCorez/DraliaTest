using MiddlewareLayerFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraliaTest.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    internal struct Endpoints
    {
        internal string getWeekAvailability;
        internal string takeSlot;
    }

    /// <summary>
    /// 
    /// </summary>
    internal static class MiddlewareHelper
    {

        private static Endpoints _endpoints;

        /// <summary>
        /// 
        /// </summary>
        public static void Initialize() //Implement singleton!
        {
            _endpoints = new Endpoints();
            _endpoints.getWeekAvailability = ConfigurationManager.AppSettings["endpointGetWeeklyAvailability"];
            _endpoints.takeSlot = ConfigurationManager.AppSettings["endpointTakeSlots"];

            DraliaRestClient restClient = new DraliaRestClient(ConfigurationManager.AppSettings["baseUrl"]);
        }
    }
}
