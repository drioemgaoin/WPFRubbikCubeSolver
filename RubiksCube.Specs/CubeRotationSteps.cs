using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace RubiksCube.Specs
{
    [Binding]
    public class CubeRotationSteps
    {
        [Given(@"a cube with a visable ""(.*)"" face")]
        public void GivenACubeWithAVisableFace(string color)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the cube turns ""(.*)"" (.*)")]
        public void WhenTheCubeTurns(string move, int times)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"then the ""(.*)"" face is visible")]
        public void ThenThenTheFaceIsVisible(string color)
        {
            Assert.Fail();
        }
    }
}
