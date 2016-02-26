using NUnit.Framework;
using Ploeh.AutoFixture;
using RubiksCube.Enums;
using RubiksCube.Factory;

namespace RubbikCube.Tests.Factory
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

            Assert.That(positions[FaciePositionType.Middle], Is.EqualTo("0 2 0  1 2 0  0 2 -1  1 2 -1"));
            Assert.That(positions[FaciePositionType.MiddleTop], Is.EqualTo("1 2 0  2 2 0  1 2 -1  2 2 -1"));
            Assert.That(positions[FaciePositionType.MiddleBottom], Is.EqualTo("-1 2 0  0 2 0  -1 2 -1  0 2 -1"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("0 2 1  1 2 1  0 2 0  1 2 0"));
            Assert.That(positions[FaciePositionType.RightTop], Is.EqualTo("1 2 1  2 2 1  1 2 0  2 2 0"));
            Assert.That(positions[FaciePositionType.RightBottom], Is.EqualTo("-1 2 1  0 2 1  -1 2 0  0 2 0"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("0 2 -1  1 2 -1  0 2 -2  1 2 -2"));
            Assert.That(positions[FaciePositionType.LeftTop], Is.EqualTo("1 2 -1  2 2 -1  1 2 -2  2 2 -2"));
            Assert.That(positions[FaciePositionType.LeftBottom], Is.EqualTo("-1 2 -1  0 2 -1  -1 2 -2  0 2 -2"));
        }

        [Test]
        public void GivenBottomFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Bottom);

            Assert.That(positions[FaciePositionType.Middle], Is.EqualTo("-1 0 -1  -1 0 0  -1 1 -1  -1 1 0"));
            Assert.That(positions[FaciePositionType.MiddleTop], Is.EqualTo("-1 0 0  -1 0 1  -1 1 0  -1 1 1"));
            Assert.That(positions[FaciePositionType.MiddleBottom], Is.EqualTo("-1 0 -2  -1 0 -1  -1 1 -2  -1 1 -1"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("-1 -1 -1  -1 -1 0  -1 0 -1  -1 0 0"));
            Assert.That(positions[FaciePositionType.RightTop], Is.EqualTo("-1 -1 0  -1 -1 1  -1 0 0  -1 0 1"));
            Assert.That(positions[FaciePositionType.RightBottom], Is.EqualTo("-1 -1 -2  -1 -1 -1  -1 0 -2  -1 0 -1"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("-1 1 -1  -1 1 0  -1 2 -1  -1 2 0"));
            Assert.That(positions[FaciePositionType.LeftTop], Is.EqualTo("-1 1 0  -1 1 1  -1 2 0  -1 2 1"));
            Assert.That(positions[FaciePositionType.LeftBottom], Is.EqualTo("-1 1 -2  -1 1 -1  -1 2 -2  -1 2 -1"));
        }

        [Test]
        public void GivenBackFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Back);

            Assert.That(positions[FaciePositionType.Middle], Is.EqualTo("1 0 -2  0 0 -2  1 1 -2  0 1 -2"));
            Assert.That(positions[FaciePositionType.MiddleTop], Is.EqualTo("2 0 -2  1 0 -2  2 1 -2  1 1 -2"));
            Assert.That(positions[FaciePositionType.MiddleBottom], Is.EqualTo("0 0 -2  -1 0 -2  0 1 -2  -1 1 -2"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("1 -1 -2  0 -1 -2  1 0 -2  0 0 -2"));
            Assert.That(positions[FaciePositionType.RightTop], Is.EqualTo("2 -1 -2  1 -1 -2  2 0 -2  1 0 -2"));
            Assert.That(positions[FaciePositionType.RightBottom], Is.EqualTo("0 -1 -2  -1 -1 -2  0 0 -2  -1 0 -2"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("1 1 -2  0 1 -2  1 2 -2  0 2 -2"));
            Assert.That(positions[FaciePositionType.LeftTop], Is.EqualTo("2 1 -2  1 1 -2  2 2 -2  1 2 -2"));
            Assert.That(positions[FaciePositionType.LeftBottom], Is.EqualTo("0 1 -2  -1 1 -2  0 2 -2  -1 2 -2"));
        }

        [Test]
        public void GivenRightFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Right);

            Assert.That(positions[FaciePositionType.Middle], Is.EqualTo("0 -1 -1  1 -1 -1  0 -1 0  1 -1 0"));
            Assert.That(positions[FaciePositionType.MiddleTop], Is.EqualTo("1 -1 -1  2 -1 -1  1 -1 0  2 -1 0"));
            Assert.That(positions[FaciePositionType.MiddleBottom], Is.EqualTo("-1 -1 -1  0 -1 -1  -1 -1 0  0 -1 0"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("0 -1 -2  1 -1 -2  0 -1 -1  1 -1 -1"));
            Assert.That(positions[FaciePositionType.RightTop], Is.EqualTo("1 -1 -2  2 -1 -2  1 -1 -1  2 -1 -1"));
            Assert.That(positions[FaciePositionType.RightBottom], Is.EqualTo("-1 -1 -2  0 -1 -2  -1 -1 -1  0 -1 -1"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("0 -1 0  1 -1 0  0 -1 1  1 -1 1"));
            Assert.That(positions[FaciePositionType.LeftTop], Is.EqualTo("1 -1 0  2 -1 0  1 -1 1  2 -1 1"));
            Assert.That(positions[FaciePositionType.LeftBottom], Is.EqualTo("-1 -1 0  0 -1 0  -1 -1 1  0 -1 1"));
        }

        [Test]
        public void GivenTopFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Top);

            Assert.That(positions[FaciePositionType.Middle], Is.EqualTo("2 0 0  2 0 -1  2 1 0  2 1 -1"));
            Assert.That(positions[FaciePositionType.MiddleTop], Is.EqualTo("2 0 -1  2 0 -2  2 1 -1  2 1 -2"));
            Assert.That(positions[FaciePositionType.MiddleBottom], Is.EqualTo("2 0 1  2 0 0  2 1 1  2 1 0"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("2 -1 0  2 -1 -1  2 0 0  2 0 -1"));
            Assert.That(positions[FaciePositionType.RightTop], Is.EqualTo("2 -1 -1  2 -1 -2  2 0 -1  2 0 -2"));
            Assert.That(positions[FaciePositionType.RightBottom], Is.EqualTo("2 -1 1  2 -1 0  2 0 1  2 0 0"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("2 1 0  2 1 -1  2 2 0  2 2 -1"));
            Assert.That(positions[FaciePositionType.LeftTop], Is.EqualTo("2 1 -1  2 1 -2  2 2 -1  2 2 -2"));
            Assert.That(positions[FaciePositionType.LeftBottom], Is.EqualTo("2 1 1  2 1 0  2 2 1  2 2 0"));
        }

        [Test]
        public void GivenFrontFace_WhenCreatePositions_ShoulReturnTheRightPositions()
        {
            var subject = fixture.Create<PositionsFactory>();

            var positions = subject.CreatePositions(FaceType.Front);

            Assert.That(positions[FaciePositionType.Middle], Is.EqualTo("0 0 1  1 0 1  0 1 1  1 1 1"));
            Assert.That(positions[FaciePositionType.MiddleTop], Is.EqualTo("1 0 1  2 0 1  1 1 1  2 1 1"));
            Assert.That(positions[FaciePositionType.MiddleBottom], Is.EqualTo("-1 0 1  0 0 1  -1 1 1  0 1 1"));
            Assert.That(positions[FaciePositionType.RightMiddle], Is.EqualTo("0 -1 1  1 -1 1  0 0 1  1 0 1"));
            Assert.That(positions[FaciePositionType.RightTop], Is.EqualTo("1 -1 1  2 -1 1  1 0 1  2 0 1"));
            Assert.That(positions[FaciePositionType.RightBottom], Is.EqualTo("-1 -1 1  0 -1 1  -1 0 1  0 0 1"));
            Assert.That(positions[FaciePositionType.LeftMiddle], Is.EqualTo("0 1 1  1 1 1  0 2 1  1 2 1"));
            Assert.That(positions[FaciePositionType.LeftTop], Is.EqualTo("1 1 1  2 1 1  1 2 1  2 2 1"));
            Assert.That(positions[FaciePositionType.LeftBottom], Is.EqualTo("-1 1 1  0 1 1  -1 2 1  0 2 1"));
        }
    }
}
