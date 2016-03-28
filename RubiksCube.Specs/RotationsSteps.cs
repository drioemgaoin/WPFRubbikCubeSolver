using NUnit.Framework;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations;
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
            cube = new Cube();
        }

        [When(@"the cube turns ""(.*)"" (.*) times")]
        public void WhenTheCubeTurns(string direction, uint times)
        {
            var axis = direction == FaceMove.Down || direction == FaceMove.Up ? AxisType.X : AxisType.Y;
            var clockwise = direction == FaceMove.Up || direction == FaceMove.Right;
            var rotationInfo = new RotationInfo(LayerType.All, axis, clockwise, times);
            var rotation = rotationInfo.CreateRotation();

            cube.Rotate(rotation);
        }

        [Then(@"the ""(.*)"" face is visible")]
        public void ThenThenTheFaceIsVisible(string visibleColor)
        {
            foreach (var facie in cube[FaceType.Front].Facies)
            {
                Assert.AreEqual(visibleColor, facie.Color.ToString());
            }
        }

        [When(@"turns the ""(.*)"" '(.*)' layer ""(.*)"" (.*) times")]
        public void WhenTurnsTheLayerTimes(string layer, char axis, string way, uint times)
        {
            var info = new RotationInfo(layer, axis, way, times);
            var rotation = info.CreateRotation();

            cube.Rotate(rotation);
        }

        [Then(@"the ""(.*)"" face ""(.*)"" '(.*)' layer is ""(.*)""")]
        public void ThenTheLayerIs(string face, string layer, char axis, string color)
        {
            var facies = cube.GetLayer(face, axis, layer);
            foreach (var facie in facies)
            {
                Assert.AreEqual(color, facie.Color.ToString());
            }
        }
    }
}