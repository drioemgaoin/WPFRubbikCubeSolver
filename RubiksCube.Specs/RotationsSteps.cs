using System;
using NUnit.Framework;
using RubiksCube.Core.Factory;
using RubiksCube.Core.Model;
using TechTalk.SpecFlow;

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

        [Then(@"the ""(.*)"" face is visible")]
        public void ThenThenTheFaceIsVisible(string visibleColor)
        {
            foreach (var facie in cube.FrontFace.Facies)
            {
                Assert.AreEqual(facie.ColorName, visibleColor);
            }
        }

        [When(@"row (.*) turns ""(.*)"" (.*) times")]
        public void WhenTheRowTurns(int position, string direction, uint times)
        {
            var rotationType = (RotationType)Enum.Parse(typeof(RotationType), position.ToString());
            var rotation = new Rotation(direction, times, rotationType);
            cube.Rotate(rotation);
        }

        [Then(@"row (.*) is ""(.*)""")]
        public void ThenTheRowsIsVisible(int position, string visibleColor)
        {
            var rotationType = (RotationType)Enum.Parse(typeof(RotationType), position.ToString());
            foreach(var facie in cube.FrontFace.GetRowFacies(rotationType))
            {
                Assert.AreEqual(facie.ColorName, visibleColor);
            }
        }

        [When(@"column (.*) turns ""(.*)"" (.*) times")]
        public void WhenTheColumnTurns(int position, string direction, uint times)
        {
            var rotationType = (RotationType)Enum.Parse(typeof(RotationType), position.ToString());
            var rotation = new Rotation(direction, times, rotationType);
            cube.Rotate(rotation);
        }

        [Then(@"column (.*) is ""(.*)""")]
        public void ThenTheColumnIsVisible(int position, string visibleColor)
        {
            var rotationType = (RotationType)Enum.Parse(typeof(RotationType), position.ToString());
            foreach (var facie in cube.FrontFace.GetColumnFacies(rotationType))
            {
                Assert.AreEqual(facie.ColorName, visibleColor);
            }
        }
    }
}
