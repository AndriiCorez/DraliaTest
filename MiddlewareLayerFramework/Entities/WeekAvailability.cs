// <copyright file="WeekAvailability.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using MiddlewareLayerFramework.Repository;
using MiddlewareLayerFramework.RestClients;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MiddlewareLayerFramework.Entities
{
    /// <summary>
    /// Class refrects Week Availability entity used for GETing
    /// </summary>
    public class WeekAvailability : IWeekAvailability
    {
        private string endpoint;
        private string baseUrl;
        private string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        private DraliaRestClient restClient;
        private JObject responseObject;

        /// <summary>
        /// Duration of the slot in minutes
        /// </summary>
        public int slotDurationMinutes { get; set; }

        /// <summary>
        /// Facility entity details
        /// </summary>
        public Facility facility;

        /// <summary>
        /// Available working days for current facility
        /// </summary>
        public IList<WorkingDay> workingDays;

        public WeekAvailability()
        {
            endpoint = ConfigurationManager.AppSettings["endpointGetWeeklyAvailability"];
            baseUrl = ConfigurationManager.AppSettings["baseUrl"];

            restClient = new DraliaRestClient(baseUrl);
        }

        private WeekAvailability ConvertRestResponseToObject(string jsonText)
        {
            try
            {
                responseObject = JObject.Parse(jsonText);
            }
            catch (JsonReaderException) { return this; }

            //Mapping JSON data to objects/propperties
            facility = new Facility(responseObject.SelectToken("Facility"));

            slotDurationMinutes = (int)responseObject.SelectToken("SlotDurationMinutes");

            workingDays = new List<WorkingDay>();
            foreach (var d in days)
            {
                var token = responseObject.SelectToken(d);

                if (token != null)
                    workingDays.Add(new WorkingDay(token, d));
            }

            return this;
        }

        /// <summary>
        /// Sends GET request using currect object data
        /// </summary>
        /// <param name="dateParameter"></param>
        /// <returns>Current object and Data of the REST response</returns>
        public Tuple<WeekAvailability, ResponseData> GetWeekAvailability(string dateParameter)
        {
            ResponseData response = new ResponseData(restClient.Get(endpoint + dateParameter));
            ConvertRestResponseToObject(response.Content);

            return new Tuple<WeekAvailability, ResponseData>(this, response);
        }
    }

    /// <summary>
    /// Facility entity details
    /// </summary>
    public class Facility
    {
        string FacilityId { get; set; }
        string Name { get; set; }
        string Address { get; set; }

        public Facility(JToken token)
        {
            FacilityId = (string)token["FacilityId"];
            Name = (string)token["Name"];
            Address = (string)token["Address"];
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class WorkingDay
    {
        /// <summary>
        /// Working weekday name
        /// </summary>
        public string Day { get; set; }

        /// <summary>
        /// Working period details
        /// </summary>
        public WorkPeriod workPeriod;

        /// <summary>
        /// Array of taken slots. Can be empty. No one can pick one of those slots
        /// </summary>
        public IList<BusySlot> busySlots;

        public WorkingDay(JToken token, string dayName)
        {
            Day = dayName;
            workPeriod = new WorkPeriod(token.SelectToken("WorkPeriod"));

            busySlots = new List<BusySlot>();
            var slots = token.SelectToken("BusySlots");
            if (slots != null)
            {
                foreach (var s in slots)
                {
                    busySlots.Add(new BusySlot(s));
                }
            }
        }
    }

    /// <summary>
    /// Working period details of Working day
    /// </summary>
    public class WorkPeriod
    {
        /// <summary>
        /// Morning opening hour (int, from 0 to 23)
        /// </summary>
        public int StartHour { get; set; }

        /// <summary>
        /// Morning closing hour (int, from 0 to 23)
        /// </summary>
        public int LunchStartHour { get; set; }

        /// <summary>
        /// Afternoon opening hour (int, from 0 to 23)
        /// </summary>
        public int LunchEndHour { get; set; }

        /// <summary>
        /// Afternoon closing hour (int, from 0 to 23)
        /// </summary>
        public int EndHour { get; set; }

        public WorkPeriod(JToken token)
        {
            StartHour = (int)token["StartHour"];
            LunchStartHour = (int)token["LunchStartHour"];
            LunchEndHour = (int)token["LunchEndHour"];
            EndHour = (int)token["EndHour"];
        }
    }

    /// <summary>
    /// Represents an entity of taken time slots
    /// </summary>
    public class BusySlot
    {
        public string Start { get; set; }
        public string End { get; set; }

        public BusySlot(JToken token)
        {
            Start = (string)token["Start"];
            End = (string)token["End"];
        }
    }
}
