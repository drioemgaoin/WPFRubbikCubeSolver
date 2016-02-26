using System;
using NUnit.Framework;
using Ploeh.AutoFixture;
using RubiksCube.Service;

namespace RubbikCube.Tests.Service
{
    [TestFixture]
    public class RotationServiceTests
    {
        private IFixture fixture;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            fixture = new Fixture();
        }

        [Test]
        public void GivenFace_WhenRotationRight_ShouldRotateRightCorrectly()
        {
            var angle = fixture.Create<double>();

            var subject = fixture.Create<RotationService>();

            var result = subject.RotationRow(angle);

            Assert.That(result[0, 0](), Is.EqualTo(1));
            Assert.That(result[0, 1](), Is.EqualTo(0));
            Assert.That(result[0, 2](), Is.EqualTo(0));
            Assert.That(result[0, 3](), Is.EqualTo(0));
            Assert.That(result[1, 0](), Is.EqualTo(0));
            Assert.That(result[1, 1](), Is.EqualTo(Math.Cos(angle)));
            Assert.That(result[1, 2](), Is.EqualTo(Math.Sin(angle)));
            Assert.That(result[1, 3](), Is.EqualTo(0));
            Assert.That(result[2, 0](), Is.EqualTo(0));
            Assert.That(result[2, 1](), Is.EqualTo(-Math.Sin(angle)));
            Assert.That(result[2, 2](), Is.EqualTo(Math.Cos(angle)));
            Assert.That(result[2, 3](), Is.EqualTo(0));
            Assert.That(result[3, 0](), Is.EqualTo(0));
            Assert.That(result[3, 1](), Is.EqualTo(0));
            Assert.That(result[3, 2](), Is.EqualTo(0));
            Assert.That(result[3, 3](), Is.EqualTo(1));
        }

        [Test]
        public void GivenFace_WhenRotationLeft_ShouldRotateRightCorrectly()
        {
            var angle = -fixture.Create<double>();

            var subject = fixture.Create<RotationService>();

            var result = subject.RotationRow(angle);

            Assert.That(result[0, 0](), Is.EqualTo(1));
            Assert.That(result[0, 1](), Is.EqualTo(0));
            Assert.That(result[0, 2](), Is.EqualTo(0));
            Assert.That(result[0, 3](), Is.EqualTo(0));
            Assert.That(result[1, 0](), Is.EqualTo(0));
            Assert.That(result[1, 1](), Is.EqualTo(Math.Cos(angle)));
            Assert.That(result[1, 2](), Is.EqualTo(Math.Sin(angle)));
            Assert.That(result[1, 3](), Is.EqualTo(0));
            Assert.That(result[2, 0](), Is.EqualTo(0));
            Assert.That(result[2, 1](), Is.EqualTo(-Math.Sin(angle)));
            Assert.That(result[2, 2](), Is.EqualTo(Math.Cos(angle)));
            Assert.That(result[2, 3](), Is.EqualTo(0));
            Assert.That(result[3, 0](), Is.EqualTo(0));
            Assert.That(result[3, 1](), Is.EqualTo(0));
            Assert.That(result[3, 2](), Is.EqualTo(0));
            Assert.That(result[3, 3](), Is.EqualTo(1));
        }

        [Test]
        public void GivenFace_WhenRotationUp_ShouldRotateRightCorrectly()
        {
            var angle = fixture.Create<double>();

            var subject = fixture.Create<RotationService>();

            var result = subject.RotationColumn(angle);

            Assert.That(result[0, 0](), Is.EqualTo(Math.Cos(2 * Math.PI - angle)));
            Assert.That(result[0, 1](), Is.EqualTo(0));
            Assert.That(result[0, 2](), Is.EqualTo(Math.Sin(2 * Math.PI - angle)));
            Assert.That(result[0, 3](), Is.EqualTo(0));
            Assert.That(result[1, 0](), Is.EqualTo(0));
            Assert.That(result[1, 1](), Is.EqualTo(1));
            Assert.That(result[1, 2](), Is.EqualTo(0));
            Assert.That(result[1, 3](), Is.EqualTo(0));
            Assert.That(result[2, 0](), Is.EqualTo(-Math.Sin(2 * Math.PI - angle)));
            Assert.That(result[2, 1](), Is.EqualTo(0));
            Assert.That(result[2, 2](), Is.EqualTo(Math.Cos(2 * Math.PI - angle)));
            Assert.That(result[2, 3](), Is.EqualTo(0));
            Assert.That(result[3, 0](), Is.EqualTo(0));
            Assert.That(result[3, 1](), Is.EqualTo(0));
            Assert.That(result[3, 2](), Is.EqualTo(0));
            Assert.That(result[3, 3](), Is.EqualTo(1));
        }

        [Test]
        public void GivenFace_WhenRotationDown_ShouldRotateRightCorrectly()
        {
            var angle = -fixture.Create<double>();

            var subject = fixture.Create<RotationService>();

            var result = subject.RotationColumn(angle);

            Assert.That(result[0, 0](), Is.EqualTo(Math.Cos(2 * Math.PI - angle)));
            Assert.That(result[0, 1](), Is.EqualTo(0));
            Assert.That(result[0, 2](), Is.EqualTo(Math.Sin(2 * Math.PI - angle)));
            Assert.That(result[0, 3](), Is.EqualTo(0));
            Assert.That(result[1, 0](), Is.EqualTo(0));
            Assert.That(result[1, 1](), Is.EqualTo(1));
            Assert.That(result[1, 2](), Is.EqualTo(0));
            Assert.That(result[1, 3](), Is.EqualTo(0));
            Assert.That(result[2, 0](), Is.EqualTo(-Math.Sin(2 * Math.PI - angle)));
            Assert.That(result[2, 1](), Is.EqualTo(0));
            Assert.That(result[2, 2](), Is.EqualTo(Math.Cos(2 * Math.PI - angle)));
            Assert.That(result[2, 3](), Is.EqualTo(0));
            Assert.That(result[3, 0](), Is.EqualTo(0));
            Assert.That(result[3, 1](), Is.EqualTo(0));
            Assert.That(result[3, 2](), Is.EqualTo(0));
            Assert.That(result[3, 3](), Is.EqualTo(1));
        }
    }
}
