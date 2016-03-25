using NUnit.Framework;
using RubiksCube.Core.Model;

namespace RubiksCube.Core.Tests.Factory
{
    [TestFixture]
    public class CubeTests
    {
        [Test]
        public void GivenCreation_WhenCreateFrontFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.FrontFace.Type, Is.EqualTo(FaceType.Front));
        }

        [Test]
        public void GivenCreation_WhenCreateLeftFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.LeftFace.Type, Is.EqualTo(FaceType.Left));
        }

        [Test]
        public void GivenCreation_WhenCreateRightFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.RightFace.Type, Is.EqualTo(FaceType.Right));
        }

        [Test]
        public void GivenCreation_WhenCreateBottomFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.BottomFace.Type, Is.EqualTo(FaceType.Bottom));
        }

        [Test]
        public void GivenCreation_WhenCreateTopFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.TopFace.Type, Is.EqualTo(FaceType.Top));
        }

        [Test]
        public void GivenCreation_WhenCreateBackFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.BackFace.Type, Is.EqualTo(FaceType.Back));
        }
    }
}