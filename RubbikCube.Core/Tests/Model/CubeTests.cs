using NUnit.Framework;
using RubiksCube.Core.Model;

namespace RubiksCube.Core.Tests.Model
{
    [TestFixture]
    public class CubeTests
    {
        [Test]
        public void GivenNewCube_WhenCreateFrontFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.FrontFace.Type, Is.EqualTo(FaceType.Front));
        }

        [Test]
        public void GivenNewCube_WhenCreateLeftFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.LeftFace.Type, Is.EqualTo(FaceType.Left));
        }

        [Test]
        public void GivenNewCube_WhenCreateRightFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.RightFace.Type, Is.EqualTo(FaceType.Right));
        }

        [Test]
        public void GivenNewCube_WhenCreateBottomFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.BottomFace.Type, Is.EqualTo(FaceType.Bottom));
        }

        [Test]
        public void GivenNewCube_WhenCreateTopFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.TopFace.Type, Is.EqualTo(FaceType.Top));
        }

        [Test]
        public void GivenNewCube_WhenCreateBackFace_ShouldInitializeCorrectlyTheNewInstance()
        {
            var cube = new Cube();
            Assert.That(cube.BackFace.Type, Is.EqualTo(FaceType.Back));
        }
    }
}