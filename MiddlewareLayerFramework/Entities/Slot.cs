// <copyright file="Slot.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using MiddlewareLayerFramework.Repository;
using MiddlewareLayerFramework.RestClients;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;

namespace MiddlewareLayerFramework.Entities
{
    /// <summary>
    /// Class refrects Slot entity used for POSTing
    /// </summary>
    public class Slot : ISlot
    {
        private DraliaRestClient restClient;
        private string endpoint;
        private string baseUrl;

        /// <summary>
        /// Start timestamp (string "YYYY-MM-dd HH:mm:ss")
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// End timestamp (string "YYYY-MM-dd HH:mm:ss")
        /// </summary>
        public string End { get; set; }

        /// <summary>
        /// Aditional instructions for the doctor
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Patient data
        /// </summary>
        public Patient Patient;

        public Slot(dynamic slot)
        {
            endpoint = ConfigurationManager.AppSettings["endpointTakeSlots"];
            baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            restClient = new DraliaRestClient(baseUrl);

            Start = slot.Start;
            End = slot.End;
            Comments = slot.Comments;

            Patient = new Patient(slot);
        }

        /*Usage of JsonConvert.SerializeObject(this) currently outs Patient in front of
         JSON wich leads to the error while making a request taking into consideration small
         size of the request body - current implementation could be a temp solution*/
        private string ConvertObjectToJson() => $"{{" +
                $"\"Start\":\"{Start}\"," +
                $"\"End\":\"{End}\"," +
                $"\"Comments\":\"{Comments}\"," +
                $"\"Patient\" : {{" +
                $"\"Name\":\"{Patient.Name}\"," +
                $"\"SecondName\":\"{Patient.SecondName}\"," +
                $"\"Email\":\"{Patient.Email}\"," +
                $"\"Phone\":\"{Patient.Phone}\"" +
                $"}}" +
                $"}}";

        //Please see the comment for ConvertObjectToJson() above
        private string ConvertObjectToJsonWithPatientFirst() => JsonConvert.SerializeObject(this);

        /// <summary>
        /// Sends POST request using currect object data
        /// </summary>
        /// <returns>Current object and Data of the REST response</returns>
        public Tuple<Slot, ResponseData> PostSlotTaking()
        {
            IRestResponse restResponse = restClient.Post(endpoint, ConvertObjectToJson());
            return new Tuple<Slot, ResponseData>(this, new ResponseData(restResponse));
        }

        /// <summary>
        /// Sends POST request with incorrect request body format using currect object data
        /// </summary>
        /// <returns>Current object and Data of the REST response</returns>
        public Tuple<Slot, ResponseData> PostSlotTakingExpectError()
        {
            IRestResponse restResponse = restClient.Post(endpoint, ConvertObjectToJsonWithPatientFirst());
            return new Tuple<Slot, ResponseData>(this, new ResponseData(restResponse));
        }
    }

    /// <summary>
    /// Class refrects Patient entity used for POSTing within Slot entity
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Patient Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Patient SecondName
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Patient Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Patient Phone
        /// </summary>
        public string Phone { get; set; }

        public Patient(dynamic slot)
        {
            Name = slot.Name;
            SecondName = slot.SecondName;
            Email = slot.Email;
            Phone = Convert.ToString(slot.Phone);
        }
    }
}
