using NUnit.Framework;
using Ploeh.AutoFixture;
using RubiksCube.Core.Model;

namespace RubiksCube.UI.Tests
{
    [TestFixture]
    public class PositionsFactoryTests
    {
        private IFixture fixture;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            fixture = new Fixture();
        }

        [Test]
        public void GivenLeftFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Left);

            Assert.That(positions[FaciePositionType.Center], Is.EqualTo("0 2 0  1 2 0  0 2 -1  1 2 -1"));
            Assert.That(positions[FaciePositionType.MiddleUp], Is.EqualTo("1 2 0  2 2 0  1 2 -1  2 2 -1"));
            Assert.That(positions[FaciePositionType.MiddleDown], Is.EqualTo("-1 2 0  0 2 0  -1 2 -1  0 2 -1"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("0 2 1  1 2 1  0 2 0  1 2 0"));
            Assert.That(positions[FaciePositionType.RightUp], Is.EqualTo("1 2 1  2 2 1  1 2 0  2 2 0"));
            Assert.That(positions[FaciePositionType.RightDown], Is.EqualTo("-1 2 1  0 2 1  -1 2 0  0 2 0"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("0 2 -1  1 2 -1  0 2 -2  1 2 -2"));
            Assert.That(positions[FaciePositionType.LeftUp], Is.EqualTo("1 2 -1  2 2 -1  1 2 -2  2 2 -2"));
            Assert.That(positions[FaciePositionType.LeftDown], Is.EqualTo("-1 2 -1  0 2 -1  -1 2 -2  0 2 -2"));
        }

        [Test]
        public void GivenBottomFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Down);

            Assert.That(positions[FaciePositionType.Center], Is.EqualTo("-1 0 -1  -1 0 0  -1 1 -1  -1 1 0"));
            Assert.That(positions[FaciePositionType.MiddleDown], Is.EqualTo("-1 0 0  -1 0 1  -1 1 0  -1 1 1"));
            Assert.That(positions[FaciePositionType.MiddleUp], Is.EqualTo("-1 0 -2  -1 0 -1  -1 1 -2  -1 1 -1"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("-1 -1 -1  -1 -1 0  -1 0 -1  -1 0 0"));
            Assert.That(positions[FaciePositionType.RightDown], Is.EqualTo("-1 -1 0  -1 -1 1  -1 0 0  -1 0 1"));
            Assert.That(positions[FaciePositionType.RightUp], Is.EqualTo("-1 -1 -2  -1 -1 -1  -1 0 -2  -1 0 -1"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("-1 1 -1  -1 1 0  -1 2 -1  -1 2 0"));
            Assert.That(positions[FaciePositionType.LeftDown], Is.EqualTo("-1 1 0  -1 1 1  -1 2 0  -1 2 1"));
            Assert.That(positions[FaciePositionType.LeftUp], Is.EqualTo("-1 1 -2  -1 1 -1  -1 2 -2  -1 2 -1"));
        }

        [Test]
        public void GivenBackFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Back);

            Assert.That(positions[FaciePositionType.Center], Is.EqualTo("1 0 -2  0 0 -2  1 1 -2  0 1 -2"));
            Assert.That(positions[FaciePositionType.MiddleUp], Is.EqualTo("2 0 -2  1 0 -2  2 1 -2  1 1 -2"));
            Assert.That(positions[FaciePositionType.MiddleDown], Is.EqualTo("0 0 -2  -1 0 -2  0 1 -2  -1 1 -2"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("1 -1 -2  0 -1 -2  1 0 -2  0 0 -2"));
            Assert.That(positions[FaciePositionType.RightUp], Is.EqualTo("2 -1 -2  1 -1 -2  2 0 -2  1 0 -2"));
            Assert.That(positions[FaciePositionType.RightDown], Is.EqualTo("0 -1 -2  -1 -1 -2  0 0 -2  -1 0 -2"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("1 1 -2  0 1 -2  1 2 -2  0 2 -2"));
            Assert.That(positions[FaciePositionType.LeftUp], Is.EqualTo("2 1 -2  1 1 -2  2 2 -2  1 2 -2"));
            Assert.That(positions[FaciePositionType.LeftDown], Is.EqualTo("0 1 -2  -1 1 -2  0 2 -2  -1 2 -2"));
        }

        [Test]
        public void GivenRightFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Right);

            Assert.That(positions[FaciePositionType.Center], Is.EqualTo("0 -1 -1  1 -1 -1  0 -1 0  1 -1 0"));
            Assert.That(positions[FaciePositionType.MiddleUp], Is.EqualTo("1 -1 -1  2 -1 -1  1 -1 0  2 -1 0"));
            Assert.That(positions[FaciePositionType.MiddleDown], Is.EqualTo("-1 -1 -1  0 -1 -1  -1 -1 0  0 -1 0"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("0 -1 -2  1 -1 -2  0 -1 -1  1 -1 -1"));
            Assert.That(positions[FaciePositionType.RightUp], Is.EqualTo("1 -1 -2  2 -1 -2  1 -1 -1  2 -1 -1"));
            Assert.That(positions[FaciePositionType.RightDown], Is.EqualTo("-1 -1 -2  0 -1 -2  -1 -1 -1  0 -1 -1"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("0 -1 0  1 -1 0  0 -1 1  1 -1 1"));
            Assert.That(positions[FaciePositionType.LeftUp], Is.EqualTo("1 -1 0  2 -1 0  1 -1 1  2 -1 1"));
            Assert.That(positions[FaciePositionType.LeftDown], Is.EqualTo("-1 -1 0  0 -1 0  -1 -1 1  0 -1 1"));
        }

        [Test]
        public void GivenTopFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Up);

            Assert.That(positions[FaciePositionType.Center], Is.EqualTo("2 0 0  2 0 -1  2 1 0  2 1 -1"));
            Assert.That(positions[FaciePositionType.MiddleUp], Is.EqualTo("2 0 -1  2 0 -2  2 1 -1  2 1 -2"));
            Assert.That(positions[FaciePositionType.MiddleDown], Is.EqualTo("2 0 1  2 0 0  2 1 1  2 1 0"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("2 -1 0  2 -1 -1  2 0 0  2 0 -1"));
            Assert.That(positions[FaciePositionType.RightUp], Is.EqualTo("2 -1 -1  2 -1 -2  2 0 -1  2 0 -2"));
            Assert.That(positions[FaciePositionType.RightDown], Is.EqualTo("2 -1 1  2 -1 0  2 0 1  2 0 0"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("2 1 0  2 1 -1  2 2 0  2 2 -1"));
            Assert.That(positions[FaciePositionType.LeftUp], Is.EqualTo("2 1 -1  2 1 -2  2 2 -1  2 2 -2"));
            Assert.That(positions[FaciePositionType.LeftDown], Is.EqualTo("2 1 1  2 1 0  2 2 1  2 2 0"));
        }

        [Test]
        public void GivenFrontFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Front);

            Assert.That(positions[FaciePositionType.Center], Is.EqualTo("0 0 1  1 0 1  0 1 1  1 1 1"));
            Assert.That(positions[FaciePositionType.MiddleUp], Is.EqualTo("1 0 1  2 0 1  1 1 1  2 1 1"));
            Assert.That(positions[FaciePositionType.MiddleDown], Is.EqualTo("-1 0 1  0 0 1  -1 1 1  0 1 1"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("0 -1 1  1 -1 1  0 0 1  1 0 1"));
            Assert.That(positions[FaciePositionType.RightUp], Is.EqualTo("1 -1 1  2 -1 1  1 0 1  2 0 1"));
            Assert.That(positions[FaciePositionType.RightDown], Is.EqualTo("-1 -1 1  0 -1 1  -1 0 1  0 0 1"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("0 1 1  1 1 1  0 2 1  1 2 1"));
            Assert.That(positions[FaciePositionType.LeftUp], Is.EqualTo("1 1 1  2 1 1  1 2 1  2 2 1"));
            Assert.That(positions[FaciePositionType.LeftDown], Is.EqualTo("-1 1 1  0 1 1  -1 2 1  0 2 1"));
        }
    }
}
