﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace DraliaTest.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GetWeeklyAvailability")]
    public partial class GetWeeklyAvailabilityFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetWeeklyAvailability.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetWeeklyAvailability", "\tAs a user\r\n\tI want to get slot availability by concrete week\r\n\tSo I could use th" +
                    "is information to book a slot", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get weekly availability successfully")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        public virtual void GetWeeklyAvailabilitySuccessfully()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get weekly availability successfully", new string[] {
                        "smoke"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I GET Weekly availability", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.Then("response status is OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Non-Monday day getting error correctness")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        [NUnit.Framework.TestCaseAttribute("20180102", null)]
        [NUnit.Framework.TestCaseAttribute("20180103", null)]
        [NUnit.Framework.TestCaseAttribute("20180104", null)]
        [NUnit.Framework.TestCaseAttribute("20180105", null)]
        [NUnit.Framework.TestCaseAttribute("20180106", null)]
        [NUnit.Framework.TestCaseAttribute("20180107", null)]
        public virtual void Non_MondayDayGettingErrorCorrectness(string nonMondayDay, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "smoke"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Non-Monday day getting error correctness", @__tags);
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given(string.Format("I GET Weekly availability for {0} day", nonMondayDay), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.Then("response status is Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.And("response content is \"\"datetime must be a Monday\"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Incorrect day parameter format error correctness")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        [NUnit.Framework.TestCaseAttribute("2018010", null)]
        [NUnit.Framework.TestCaseAttribute("15201801", null)]
        [NUnit.Framework.TestCaseAttribute("10012018", null)]
        public virtual void IncorrectDayParameterFormatErrorCorrectness(string nonMondayDay, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "smoke"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect day parameter format error correctness", @__tags);
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given(string.Format("I GET Weekly availability for {0} day", nonMondayDay), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.Then("response status is Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.And("response content is \"\"datetime must be YYYYMMdd\"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Incorrect day parameter validation error correctness")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        [NUnit.Framework.TestCaseAttribute("2018010a", null)]
        [NUnit.Framework.TestCaseAttribute("2018010!", null)]
        [NUnit.Framework.TestCaseAttribute("20180000", null)]
        [NUnit.Framework.TestCaseAttribute("20180001", null)]
        [NUnit.Framework.TestCaseAttribute("20180100", null)]
        [NUnit.Framework.TestCaseAttribute("00000101", null)]
        [NUnit.Framework.TestCaseAttribute("20181301", null)]
        [NUnit.Framework.TestCaseAttribute("20180132", null)]
        [NUnit.Framework.TestCaseAttribute("20180229", null)]
        [NUnit.Framework.TestCaseAttribute("20180431", null)]
        [NUnit.Framework.TestCaseAttribute("20180631", null)]
        [NUnit.Framework.TestCaseAttribute("20180931", null)]
        [NUnit.Framework.TestCaseAttribute("20181131", null)]
        public virtual void IncorrectDayParameterValidationErrorCorrectness(string nonMondayDay, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "smoke"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect day parameter validation error correctness", @__tags);
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given(string.Format("I GET Weekly availability for {0} day", nonMondayDay), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.Then("response status is Bad Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("response content is \"\"datetime must be a valid YYYYMMdd\"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Weekly availability data correctness")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        public virtual void WeeklyAvailabilityDataCorrectness()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Weekly availability data correctness", new string[] {
                        "smoke"});
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given("TBD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Busy slots data correctness")]
        [NUnit.Framework.CategoryAttribute("smoke")]
        public virtual void BusySlotsDataCorrectness()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Busy slots data correctness", new string[] {
                        "smoke"});
#line 69
this.ScenarioSetup(scenarioInfo);
#line 70
 testRunner.Given("TBD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
