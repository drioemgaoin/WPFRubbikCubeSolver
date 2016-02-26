using NUnit.Framework;
using Ploeh.AutoFixture;
using RubiksCube.Enums;
using RubiksCube.Factory;

namespace RubbikCube.Tests.Factory
{
    [TestFixture]
    public class CubeFactoryTests
    {
        private IFixture fixture;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            fixture = new Fixture();
        }

        [Test]
        public void GivenCreation_WhenCreateFrontFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var subject = fixture.Create<CubeFactory>();

            var result = subject.Create();

            Assert.That(result.FrontFace.Type, Is.EqualTo(FaceType.Front));
        }

        [Test]
        public void GivenCreation_WhenCreateLeftFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var subject = fixture.Create<CubeFactory>();

            var result = subject.Create();

            Assert.That(result.LeftFace.Type, Is.EqualTo(FaceType.Left));
        }

        [Test]
        public void GivenCreation_WhenCreateRightFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var subject = fixture.Create<CubeFactory>();

            var result = subject.Create();

            Assert.That(result.RightFace.Type, Is.EqualTo(FaceType.Right));
        }

        [Test]
        public void GivenCreation_WhenCreateBottomFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var subject = fixture.Create<CubeFactory>();

            var result = subject.Create();

            Assert.That(result.BottomFace.Type, Is.EqualTo(FaceType.Bottom));
        }

        [Test]
        public void GivenCreation_WhenCreateTopFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var subject = fixture.Create<CubeFactory>();

            var result = subject.Create();

            Assert.That(result.TopFace.Type, Is.EqualTo(FaceType.Top));
        }

        [Test]
        public void GivenCreation_WhenCreateBackFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var subject = fixture.Create<CubeFactory>();

            var result = subject.Create();

            Assert.That(result.BackFace.Type, Is.EqualTo(FaceType.Back));
        }
    }
}