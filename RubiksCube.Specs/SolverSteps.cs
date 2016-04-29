using System;
using System.Linq;
using NUnit.Framework;
using RubiksCube.Core;
using RubiksCube.Core.Model;
using TechTalk.SpecFlow;

namespace RubiksCube.Specs
{
    [Binding]
    public class SolverSteps
    {
        private IRubiksCubeSolver solver;
        private Cube cube;

        [Given(@"a solver")]
        public void GivenASolver()
        {
            solver = new FriedrichSolver();
        }
        
        [Given(@"a scrambled cube")]
        public void GivenAScrambledCube()
        {
            cube = new Cube();
            cube.Scramble();
        }
        
        [Given(@"the ""(.*)"" center facie is ""(.*)""")]
        public void GivenTheCenterFacieIs(string face, string color)
        {
            var faceType = (FaceType)Enum.Parse(typeof(FaceType), face);
            var facie = cube[faceType].Facies.Single(f => f.Position == FaciePositionType.Center);

            var expectedColor = (Color)Enum.Parse(typeof(Color), color);
            Assert.AreEqual(expectedColor, facie.Color);
        }
        
        [When(@"ask the solver to resolve the white cross")]
        public void WhenAskTheSolverToResolveTheCube()
        {
            solver.Solve(cube);
        }

        [Then(@"the ""(.*)"" face ""(.*)"" facie is ""(.*)""")]
        public void ThenTheFaceFacieIs(string face, string position, string color)
        {
            var faceType = (FaceType)Enum.Parse(typeof(FaceType), face);
            var faciePositionType = (FaciePositionType)Enum.Parse(typeof(FaciePositionType), position);
            var expectedColor = (Color)Enum.Parse(typeof(Color), color);

            var facie = cube[faceType].Facies.Single(f => f.Position == faciePositionType);
            Assert.AreEqual(expectedColor, facie.Color);
        }
    }
}
