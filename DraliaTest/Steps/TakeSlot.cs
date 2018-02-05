// <copyright file="TakeSlot.cs">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Andrii Vasyliev</author>

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using MiddlewareLayerFramework.Entities;

namespace DraliaTest.Steps
{
    [Binding]
    public class TakeSlot
    {
        #region Given's

        [Given(@"TBD")]
        public void GivenTBD()
        {
            //The step indicates that planned test case should be implemented once tech debt is resolved
            //So it would be ignored once test is launched
            ScenarioContext.Current.Pending();
        }


        [Given(@"I take the follwoing slot")]
        public void GivenITakeTheFollwoingSlot(Table table)
        {
            dynamic slot = table.CreateDynamicInstance();

            var result = new Slot(slot).PostSlotTaking();

            ScenarioContext.Current.Set(result.Item1);
            ScenarioContext.Current.Set(result.Item2);
        }

        [Given(@"I take the follwoing slot with errors")]
        public void GivenITakeTheFollwoingSlotWithErrors(Table table)
        {
            dynamic slot = table.CreateDynamicInstance();

            var result = new Slot(slot).PostSlotTakingExpectError();

            ScenarioContext.Current.Set(result.Item1);
            ScenarioContext.Current.Set(result.Item2);
        }


        #endregion 

    }
}
