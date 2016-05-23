using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RubiksCube.Core;
using RubiksCube.Core.Model;
using RubiksCube.Core.Model.Rotations;
using TechTalk.SpecFlow;

namespace RubiksCube.Specs
{
    [Binding]
    public class MoveInterpretorSteps
    {
        private readonly IMoveInterpretor moveInterpretor = new MoveInterpretor();
        private ICollection<RotationInfo> rotationsInfos;
        private string moves;

        [Given(@"the moves ""(.*)""")]
        public void GivenTheMoves(string moves)
        {
            this.moves = moves;
        }
        
        [When(@"interpret moves")]
        public void WhenInterpretMoves()
        {
            rotationsInfos = moveInterpretor.Interpret(moves);
        }
        
        [Then(@"the list contains a ""(.*)"" ""(.*)"" rotation")]
        public void ThenTheListContainsARotation(string face, string way)
        {
            AssertRotationsContain(face, way, 1);
        }

        [Then(@"the list contains a ""(.*)"" twice ""(.*)"" rotation")]
        public void ThenTheListContainsATwiceRotation(string face, string way)
        {
            AssertRotationsContain(face, way, 2);
        }
        
        private void AssertRotationsContain(string face, string way, uint times)
        {
            var faceType = (FaceType) Enum.Parse(typeof (FaceType), face);
            var clockwise = way == "Clockwise";

            var actual = rotationsInfos.SingleOrDefault(r => r.Clockwise == clockwise && r.Face == faceType && r.Times == times);
            Assert.IsNotNull(actual);
        }
    }
}
