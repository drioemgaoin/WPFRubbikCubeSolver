using NUnit.Framework;
using RubiksCube.Core.Model;

namespace RubiksCube.Core.Tests.Model
{
    [TestFixture]
    public class CubeTests
    {
        [Test]
        public void GivenNewCube_WhenAccessingFaces_ThenFacesAreSet()
        {
            const int ExpectedFaciesByFace = 9;

            var cube = new Cube();
            Assert.That(cube[FaceType.Front].Type, Is.EqualTo(FaceType.Front));
            Assert.That(cube[FaceType.Front].Facies.Count, Is.EqualTo(ExpectedFaciesByFace));
            Assert.That(cube[FaceType.Left].Type, Is.EqualTo(FaceType.Left));
            Assert.That(cube[FaceType.Left].Facies.Count, Is.EqualTo(ExpectedFaciesByFace));
            Assert.That(cube[FaceType.Right].Type, Is.EqualTo(FaceType.Right));
            Assert.That(cube[FaceType.Right].Facies.Count, Is.EqualTo(ExpectedFaciesByFace));
            Assert.That(cube[FaceType.Back].Type, Is.EqualTo(FaceType.Back));
            Assert.That(cube[FaceType.Back].Facies.Count, Is.EqualTo(ExpectedFaciesByFace));
            Assert.That(cube[FaceType.Down].Type, Is.EqualTo(FaceType.Down));
            Assert.That(cube[FaceType.Down].Facies.Count, Is.EqualTo(ExpectedFaciesByFace));
            Assert.That(cube[FaceType.Up].Type, Is.EqualTo(FaceType.Up));
            Assert.That(cube[FaceType.Up].Facies.Count, Is.EqualTo(ExpectedFaciesByFace));
        }       
    }
}