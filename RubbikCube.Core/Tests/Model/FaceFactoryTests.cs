using System.Linq;
using NUnit.Framework;
using RubiksCube.Core.Model;

namespace RubiksCube.Core.Tests.Model
{
    [TestFixture]
    public class FaceFactoryTests
    {
        [TestCase(FaceType.Front, Color.White)]
        [TestCase(FaceType.Left, Color.Green)]
        [TestCase(FaceType.Right, Color.Blue)]
        [TestCase(FaceType.Up, Color.Orange)]
        [TestCase(FaceType.Down, Color.Red)]
        [TestCase(FaceType.Back, Color.Yellow)]
        public void GivenFactory_WhenCreateFace_ThenReturnsExpectedTypeAndColor(FaceType faceType, Color color)
        {
            var face = new FaceFactory().CreateFace(faceType);

            Assert.That(face.Type, Is.EqualTo(faceType));
            Assert.IsTrue(face.Facies.All(x => x.Color == color));
        }
    }
}
