using System;
using System.Collections.Generic;
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
            var axis = direction == Move.Face.Down || direction == Move.Face.Up ? AxisType.X : AxisType.Y;
            var clockwise = direction == Move.Face.Up || direction == Move.Face.Right;
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

        [When(@"turns the ""(.*)"" layer on the '(.*)' axis ""(.*)"" (.*) times")]
        public void WhenTurnsTheLayerTimes(string layer, char axis, string way, uint times)
        {
            var info = new RotationInfo(layer, axis, way, times);
            var rotation = info.CreateRotation();
                
            cube.Rotate(rotation);
        }

        [Then(@"the ""(.*)"" face ""(.*)"" row is ""(.*)""")]
        public void ThenTheFaceRowIs(string face, string row, string color)
        {
            var faceType = (FaceType)Enum.Parse(typeof(FaceType), face);
            var layerType = (LayerType)Enum.Parse(typeof(LayerType), row);
            var facies = cube[faceType].GetRow(layerType);

            AssertColorAreEqual(color, facies);
        }

        [Then(@"the ""(.*)"" face ""(.*)"" column is ""(.*)""")]
        public void ThenTheFaceColumnIs(string face, string column, string color)
        {
            var faceType = (FaceType)Enum.Parse(typeof(FaceType), face);
            var layerType = (LayerType)Enum.Parse(typeof(LayerType), column);
            var facies = cube[faceType].GetColumn(layerType);

            AssertColorAreEqual(color, facies);
        }

        private static void AssertColorAreEqual(string color, IList<Facie> facies)
        {
            foreach (var facie in facies)
            {
                Assert.AreEqual(color, facie.Color.ToString());
            }
        }
    }
}