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
        private readonly IInterpretor interpretor = new Interpretor();
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
            rotationsInfos = interpretor.Interpret(moves);
        }
        
        [Then(@"the list contains a ""(.*)"" ""(.*)"" rotation")]
        public void ThenTheListContainsARotation(string face, string way)
        {
            var faceType = (FaceType)Enum.Parse(typeof(FaceType), face);
            var clockwise = way == "Clockwise";

            var actual = rotationsInfos.FirstOrDefault(r => r.Clockwise == clockwise && r.Face == faceType);
            Assert.IsNotNull(actual);
        }
    }
}
