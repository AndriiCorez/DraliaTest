// <copyright file="GetWeeklyAvailability.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using TechTalk.SpecFlow;
using MiddlewareLayerFramework.Entities;
using MiddlewareLayerFramework.Repository;
using NUnit.Framework;

namespace DraliaTest.Steps
{
    [Binding]
    public class GetWeeklyAvailability
    {

        #region Given's

        [Given(@"I GET Weekly availability")]
        public void GivenIGETWeeklyAvailability()
        {
            WeekAvailability weekAvailability = new WeekAvailability();

            //helper class should be created to select mondays referencing from current week, time consuming
            //hardcoded as a temp solution so far
            var result = weekAvailability.GetWeekAvailability("20180205");

            ScenarioContext.Current.Set(result.Item1);
            ScenarioContext.Current.Set(result.Item2);
        }

        [Given(@"I GET Weekly availability for (.*) day")]
        public void GivenIGETWeeklyAvailabilityForDay(string date)
        {
            WeekAvailability weekAvailability = new WeekAvailability();
            var result = weekAvailability.GetWeekAvailability(date);

            ScenarioContext.Current.Set(result.Item1);
            ScenarioContext.Current.Set(result.Item2);
        }


        [Given(@"I GET Weekly availability for ""(.*)""")]
        public void GivenIGETWeeklyAvailabilityFor(string date)
        {
            WeekAvailability weekAvailability = new WeekAvailability();
            var result = weekAvailability.GetWeekAvailability(date);

            ScenarioContext.Current.Set(result.Item1);
            ScenarioContext.Current.Set(result.Item2);
        }

        #endregion

        #region When's


        #endregion


        #region Then's

        [Then(@"response status is OK")]
        public void ThenResponseStatusIsOK()
        {
            var responseData = ScenarioContext.Current.Get<ResponseData>();
            
            Assert.AreEqual(200, responseData.Status);
            Assert.AreEqual(true, responseData.IsSuccessful);
        }


        [Then(@"response content is correct")]
        public void ThenResponseContentIsCorrect()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"response status is Bad Request")]
        public void ThenResponseStatusIsBadRequest()
        {
            var responseData = ScenarioContext.Current.Get<ResponseData>();

            Assert.AreEqual(400, responseData.Status);
            Assert.AreEqual(false, responseData.IsSuccessful);
        }

        [Then(@"response content is ""(.*)""")]
        public void ThenResponseContentIs(string expectedErrorTxt)
        {
            Assert.AreEqual(expectedErrorTxt,
                ScenarioContext.Current.Get<ResponseData>().Content);
        }


        #endregion 
    }
}
