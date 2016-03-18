using RubiksCube.Entity;
using TechTalk.SpecFlow;
using NUnit.Framework;
using RubiksCube.Factory;

namespace RubiksCube.Specs
{
    [Binding]
    public class RotationsSteps
    {
        private Cube cube;

        [Given(@"a cube with a visible ""(.*)"" face")]
        public void GivenACubeWithAVisableFace(string visibleColor)
        {
            var cubeFactory = new CubeFactory();
            cube = cubeFactory.Create();
        }
        
        [When(@"the cube turns ""(.*)"" (.*) times")]
        public void WhenTheCubeTurns(string direction, uint times)
        {
            var rotation = new Rotation(direction, times);
            cube.Rotate(rotation);
        }
        
        [Then(@"then the ""(.*)"" face is visible")]
        public void ThenThenTheFaceIsVisible(string visibleColor)
        {
            foreach (var facie in cube.FrontFace.Facies)
            {
                Assert.AreEqual(facie.ColorName, visibleColor);    
            }
        }
    }
}
