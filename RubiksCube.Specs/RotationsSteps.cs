using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations;
using RubiksCube.Core.Model.Rotations.XAxis;
using RubiksCube.Core.Model.Rotations.YAxis;
using RubiksCube.Core.Model.Rotations.ZAxis;
using TechTalk.SpecFlow;

namespace RubiksCube.Specs
{
    [Binding]
    public class RotationsSteps
    {
        private Cube cube;

        [Given(@"a new cube with a front white face and a top orange face")]
        public void GivenANewCube()
        {
            cube = new Cube();
            Assert.IsTrue(cube[FaceType.Front].Facies.All(facie => facie.Color == Color.White));
            Assert.IsTrue(cube[FaceType.Up].Facies.All(facie => facie.Color == Color.Orange));
        }

        [When(@"the cube turns ""(.*)"" (.*) times")]
        public void WhenTheCubeTurns(string direction, uint times)
        {
            throw new NotImplementedException("TODO");
        }

        [Then(@"the ""(.*)"" face is visible")]
        public void ThenThenTheFaceIsVisible(string visibleColor)
        {
            foreach (var facie in cube[FaceType.Front].Facies)
            {
                Assert.AreEqual(visibleColor, facie.Color.ToString());
            }
        }

        [When(@"turns the left face ""(.*)"" (.*) times")]
        public void WhenTurnsTheLeftFace(string way, uint times)
        {
            cube.Rotate(new LeftFaceRotationInfo(way == "Clockwise", times));
        }

        [When(@"turns the right face ""(.*)"" (.*) times")]
        public void WhenTurnsTheRightFace(string way, uint times)
        {
            cube.Rotate(new RightFaceRotationInfo(way == "Clockwise", times));
        }

        [When(@"turns the up face ""(.*)"" (.*) times")]
        public void WhenTurnsTheUpFace(string way, uint times)
        {
            cube.Rotate(new UpFaceRotationInfo(way == "Clockwise", times));
        }

        [When(@"turns the down face ""(.*)"" (.*) times")]
        public void WhenTurnsTheDownFace(string way, uint times)
        {
            cube.Rotate(new DownFaceRotationInfo(way == "Clockwise", times));
        }

        [When(@"turns the front face ""(.*)"" (.*) times")]
        public void WhenTurnsTheFrontFaceTimes(string way, uint times)
        {
            cube.Rotate(new FrontFaceRotationInfo(way == "Clockwise", times));
        }

        [When(@"turns the back face ""(.*)"" (.*) times")]
        public void WhenTurnsTheBackFaceTimes(string way, uint times)
        {
            cube.Rotate(new BackFaceRotationInfo(way == "Clockwise", times));
        }

        [Then(@"the ""(.*)"" face ""(.*)"" row is ""(.*)""")]
        public void ThenTheFaceRowIs(string face, string row, string color)
        {
            var faceType = (FaceType)Enum.Parse(typeof(FaceType), face);
            var layerType = (LayerType)Enum.Parse(typeof(LayerType), row);
            var facies = cube[faceType].GetRow(layerType);

            AssertColorAreEqual(color, facies);
            VerifyCubeFaciesIntegrity();
        }

        [Then(@"the ""(.*)"" face ""(.*)"" column is ""(.*)""")]
        public void ThenTheFaceColumnIs(string face, string column, string color)
        {
            var faceType = (FaceType)Enum.Parse(typeof(FaceType), face);
            var layerType = (LayerType)Enum.Parse(typeof(LayerType), column);
            var facies = cube[faceType].GetColumn(layerType);

            AssertColorAreEqual(color, facies);
            VerifyCubeFaciesIntegrity();
        }

        public void VerifyCubeFaciesIntegrity()
        {
            VerifyFaceIntegrity(FaceType.Front);
            VerifyFaceIntegrity(FaceType.Back);
            VerifyFaceIntegrity(FaceType.Left);
            VerifyFaceIntegrity(FaceType.Right);
            VerifyFaceIntegrity(FaceType.Up);
            VerifyFaceIntegrity(FaceType.Down);
        }

        private void VerifyFaceIntegrity(FaceType faceType)
        {
            var facies = cube[faceType].Facies;
            Assert.AreEqual(9, facies.Count);

            var duplicates = facies.GroupBy(facie => facie.Position)
                .Where(grouping => grouping.Count() > 1)
                .Select(grouping => grouping.Key)
                .ToList();

            Assert.IsEmpty(duplicates, string.Format("{0} facies contain duplicated positions.", Enum.GetName(faceType.GetType(), faceType)));
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