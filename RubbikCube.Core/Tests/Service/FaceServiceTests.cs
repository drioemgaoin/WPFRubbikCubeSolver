using NUnit.Framework;
using Ploeh.AutoFixture;
using RubiksCube.Core.Model;
using RubiksCube.Core.Service;

namespace RubbikCube.Core.Tests.Service
{
    [TestFixture]
    public class FaceServiceTests
    {
        private IFixture fixture;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            fixture = new Fixture();
        }

        [TestCase(FaceType.Front)]
        [TestCase(FaceType.Left)]
        [TestCase(FaceType.Right)]
        [TestCase(FaceType.Bottom)]
        [TestCase(FaceType.Top)]
        [TestCase(FaceType.Back)]
        public void GivenFaceType_WhenCreateFace_ShouldCreateTheRightFace(FaceType faceType)
        {
            var subject = fixture.Create<FaceService>();

            var result = subject.CreateFace(faceType);

            Assert.That(result.Type, Is.EqualTo(faceType));
        }
    }
}
