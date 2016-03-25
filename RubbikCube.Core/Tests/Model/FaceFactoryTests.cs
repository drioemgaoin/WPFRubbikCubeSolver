using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using RubiksCube.Core.Model;

namespace RubiksCube.Core.Tests.Model
{
    [TestFixture]
    public class FaceFactoryTests
    {
        private IFixture fixture;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            fixture = new Fixture();
        }

        [Test]
        public void GivenFrontFaceRequest_WhenCreateFace_ShouldReturnFrontFaceInstance()
        {
            var subject = fixture.Create<FaceFactory>();

            var result = subject.CreateFace(FaceType.Front);

            Assert.That(result.Type, Is.EqualTo(FaceType.Front));
            Asserts(result.Facies, FaceType.Front, Color.White);
        }

        [Test]
        public void GivenLeftFaceRequest_WhenCreateFace_ShouldReturnLeftFaceInstance()
        {
            var subject = fixture.Create<FaceFactory>();

            var result = subject.CreateFace(FaceType.Left);

            Assert.That(result.Type, Is.EqualTo(FaceType.Left));
            Asserts(result.Facies, FaceType.Left, Color.Green);
        }

        [Test]
        public void GivenRightFaceRequest_WhenCreateFace_ShouldReturnRightFaceInstance()
        {
            var subject = fixture.Create<FaceFactory>();

            var result = subject.CreateFace(FaceType.Right);

            Assert.That(result.Type, Is.EqualTo(FaceType.Right));
            Asserts(result.Facies, FaceType.Right, Color.Blue);
        }

        [Test]
        public void GivenTopFaceRequest_WhenCreateFace_ShouldReturnTopFaceInstance()
        {
            var subject = fixture.Create<FaceFactory>();

            var result = subject.CreateFace(FaceType.Top);

            Assert.That(result.Type, Is.EqualTo(FaceType.Top));
            Asserts(result.Facies, FaceType.Top, Color.Orange);
        }

        [Test]
        public void GivenBottomFaceRequest_WhenCreateFace_ShouldReturnBottomFaceInstance()
        {
            var subject = fixture.Create<FaceFactory>();

            var result = subject.CreateFace(FaceType.Bottom);

            Assert.That(result.Type, Is.EqualTo(FaceType.Bottom));
            Asserts(result.Facies, FaceType.Bottom, Color.Red);
        }

        [Test]
        public void GivenBackFaceRequest_WhenCreateFace_ShouldReturnBackFaceInstance()
        {
            var subject = fixture.Create<FaceFactory>();

            var result = subject.CreateFace(FaceType.Back);

            Assert.That(result.Type, Is.EqualTo(FaceType.Back));
            Asserts(result.Facies, FaceType.Back, Color.Yellow);
        }

        private void Asserts(IList<Facie> facies, FaceType faceType, Color color)
        {
            Asserts(facies.Single(x => x.FaciePosition == FaciePositionType.Middle), faceType, color);
            Asserts(facies.Single(x => x.FaciePosition == FaciePositionType.MiddleTop), faceType, color);
            Asserts(facies.Single(x => x.FaciePosition == FaciePositionType.MiddleBottom), faceType, color);
            Asserts(facies.Single(x => x.FaciePosition == FaciePositionType.RightMiddle), faceType, color);
            Asserts(facies.Single(x => x.FaciePosition == FaciePositionType.RightTop), faceType, color);
            Asserts(facies.Single(x => x.FaciePosition == FaciePositionType.RightBottom), faceType, color);
            Asserts(facies.Single(x => x.FaciePosition == FaciePositionType.LeftMiddle), faceType, color);
            Asserts(facies.Single(x => x.FaciePosition == FaciePositionType.LeftTop), faceType, color);
            Asserts(facies.Single(x => x.FaciePosition == FaciePositionType.LeftBottom), faceType, color);

        }

        private void Asserts(Facie facie, FaceType faceType, Color color)
        {
            Assert.That(facie.Color, Is.EqualTo(color));
        }
    }
}
