﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace FoodieFlow.UnitTest.Services.ProcessamentoPagamento.Exceptions.ZeroValue
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "payment")]
    public partial class PaymentProcessingAsACustomerIWantToBeAbleToProcessPaymentsSoThatICanCompleteMyPurchaseButHaveAErrorWithAZeroValueFeature : object, Xunit.IClassFixture<PaymentProcessingAsACustomerIWantToBeAbleToProcessPaymentsSoThatICanCompleteMyPurchaseButHaveAErrorWithAZeroValueFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "payment"};
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "PaymentProcessingStepsExceptionZeroValue.feature"
#line hidden
        
        public PaymentProcessingAsACustomerIWantToBeAbleToProcessPaymentsSoThatICanCompleteMyPurchaseButHaveAErrorWithAZeroValueFeature(PaymentProcessingAsACustomerIWantToBeAbleToProcessPaymentsSoThatICanCompleteMyPurchaseButHaveAErrorWithAZeroValueFeature.FixtureData fixtureData, FoodieFlow_UnitTest_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Services/ProcessamentoPagamento/Exceptions/Zero Value", "Payment Processing As a customer I want to be able to process payments  So that I" +
                    " can complete my purchase but have a error with a zero value", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Processing a payment request with zero payment")]
        [Xunit.TraitAttribute("FeatureTitle", "Payment Processing As a customer I want to be able to process payments  So that I" +
            " can complete my purchase but have a error with a zero value")]
        [Xunit.TraitAttribute("Description", "Processing a payment request with zero payment")]
        [Xunit.TraitAttribute("Category", "zeroPayment")]
        public void ProcessingAPaymentRequestWithZeroPayment()
        {
            string[] tagsOfScenario = new string[] {
                    "zeroPayment"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Processing a payment request with zero payment", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    testRunner.Given("I have a payment request with zero payment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
    testRunner.When("I call the payment request with zero payment", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
    testRunner.Then("an exception should be thrown with the message \"O valor do pagamento não pode ser" +
                        " 0.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                PaymentProcessingAsACustomerIWantToBeAbleToProcessPaymentsSoThatICanCompleteMyPurchaseButHaveAErrorWithAZeroValueFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                PaymentProcessingAsACustomerIWantToBeAbleToProcessPaymentsSoThatICanCompleteMyPurchaseButHaveAErrorWithAZeroValueFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion