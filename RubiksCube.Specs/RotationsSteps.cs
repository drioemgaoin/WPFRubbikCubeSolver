using NUnit.Framework;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations;
using TechTalk.SpecFlow;

namespace RubiksCube.Specs
{
    [Binding]
    public class RotationsSteps
    {
        private IRotationFactory rotationFactory;
        private Cube cube;

        [Given(@"a cube with a visible ""(.*)"" face")]
        public void GivenACubeWithAVisableFace(string visibleColor)
        {
            rotationFactory = new RotationFactory();
            cube = new Cube();
        }

        [When(@"the cube turns ""(.*)"" (.*) times")]
        public void WhenTheCubeTurns(string direction, uint times)
        {
            var rotation = rotationFactory.CreateFaceRotation(string.Format("{0}Whole", direction), times);
            cube.Rotate(rotation);
        }

        [Then(@"the ""(.*)"" face is visible")]
        public void ThenThenTheFaceIsVisible(string visibleColor)
        {
            foreach (var facie in cube.FrontFace.Facies)
            {
                Assert.AreEqual(visibleColor, facie.Color.ToString());
            }
        }

        [When(@"turns the top face in ""(.*)"" (.*) times")]
        public void WhenTheTopFaceTurns(string way, uint times)
        {
            var rotation = rotationFactory.CreateLayerRotation(Rotation.Up, way, times);
            cube.Rotate(rotation);
        }

        [Then(@"top row is ""(.*)""")]
        public void ThenTheFirstRowIsVisible(string visibleColor)
        {
            foreach (var facie in cube.FrontFace.GetRowFacies(CubeLayerType.First))
            {
                Assert.AreEqual(facie.Color.ToString(), visibleColor);
            }
        }

        [When(@"turns the bottom face in ""(.*)"" (.*) times")]
        public void WhenTheBottomFaceTurns(string way, uint times)
        {
            var rotation = rotationFactory.CreateLayerRotation(Rotation.Down, way, times);
            cube.Rotate(rotation);
        }

        [Then(@"bottom row is ""(.*)""")]
        public void ThenTheThirdRowIsVisible(string visibleColor)
        {
            foreach (var facie in cube.FrontFace.GetRowFacies(CubeLayerType.Third))
            {
                Assert.AreEqual(facie.Color.ToString(), visibleColor);
            }
        }

        [When(@"turns the left face in ""(.*)"" (.*) times")]
        public void WhenTheLeftFaceTurns(string way, uint times)
        {
            var rotation = rotationFactory.CreateLayerRotation(Rotation.Left, way, times);
            cube.Rotate(rotation);
        }

        [Then(@"left column is ""(.*)""")]
        public void ThenTheLeftColumnIsVisible(string visibleColor)
        {
            foreach (var facie in cube.FrontFace.GetColumnFacies(CubeLayerType.First))
            {
                Assert.AreEqual(facie.Color.ToString(), visibleColor);
            }
        }

        [When(@"turns the right face in ""(.*)"" (.*) times")]
        public void WhenTheRightFaceTurns(string way, uint times)
        {
            var rotation = rotationFactory.CreateLayerRotation(Rotation.Right, way, times);
            cube.Rotate(rotation);
        }

        [Then(@"right column is ""(.*)""")]
        public void ThenTheRightColumnIsVisible(string visibleColor)
        {
            foreach (var facie in cube.FrontFace.GetColumnFacies(CubeLayerType.Third))
            {
                Assert.AreEqual(facie.Color.ToString(), visibleColor);
            }
        }
    }
}