using System;
using NUnit.Framework;
using Ploeh.AutoFixture;
using RubiksCube.Core.Model;

namespace RubiksCube.Core.Tests.Model
{
    [TestFixture]
    public class RotationFactoryTests
    {
        private IFixture fixture;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            fixture = new Fixture();
        }

        [Test]
        public void GivenAnAngle_WhenRotateX_ShouldReturnTheRightMatrix()
        {
            var angle = fixture.Create<double>();

            var subject = fixture.Create<RotationFactory>();

            var result = subject.RotateX(angle);

            Assert.That(result[0, 0], Is.EqualTo(1));
            Assert.That(result[0, 1], Is.EqualTo(0));
            Assert.That(result[0, 2], Is.EqualTo(0));
            Assert.That(result[0, 3], Is.EqualTo(0));
            Assert.That(result[1, 0], Is.EqualTo(0));
            Assert.That(result[1, 1], Is.EqualTo(Math.Cos(angle)));
            Assert.That(result[1, 2], Is.EqualTo(Math.Sin(angle)));
            Assert.That(result[1, 3], Is.EqualTo(0));
            Assert.That(result[2, 0], Is.EqualTo(0));
            Assert.That(result[2, 1], Is.EqualTo(-Math.Sin(angle)));
            Assert.That(result[2, 2], Is.EqualTo(Math.Cos(angle)));
            Assert.That(result[2, 3], Is.EqualTo(0));
            Assert.That(result[3, 0], Is.EqualTo(0));
            Assert.That(result[3, 1], Is.EqualTo(0));
            Assert.That(result[3, 2], Is.EqualTo(0));
            Assert.That(result[3, 3], Is.EqualTo(1));
        }

        [Test]
        public void GivenAnAngle_WhenRotateY_ShouldReturnTheRightMatrix()
        {
            var angle = fixture.Create<double>();

            var subject = fixture.Create<RotationFactory>();

            var result = subject.RotateY(angle);

            Assert.That(result[0, 0], Is.EqualTo(Math.Cos(angle)));
            Assert.That(result[0, 1], Is.EqualTo(0));
            Assert.That(result[0, 2], Is.EqualTo(-Math.Sin(angle)));
            Assert.That(result[0, 3], Is.EqualTo(0));
            Assert.That(result[1, 0], Is.EqualTo(0));
            Assert.That(result[1, 1], Is.EqualTo(1));
            Assert.That(result[1, 2], Is.EqualTo(0));
            Assert.That(result[1, 3], Is.EqualTo(0));
            Assert.That(result[2, 0], Is.EqualTo(Math.Sin(angle)));
            Assert.That(result[2, 1], Is.EqualTo(0));
            Assert.That(result[2, 2], Is.EqualTo(Math.Cos(angle)));
            Assert.That(result[2, 3], Is.EqualTo(0));
            Assert.That(result[3, 0], Is.EqualTo(0));
            Assert.That(result[3, 1], Is.EqualTo(0));
            Assert.That(result[3, 2], Is.EqualTo(0));
            Assert.That(result[3, 3], Is.EqualTo(1));
        }

        [Test]
        public void GivenAnAngle_WhenRotateZ_ShouldReturnTheRightMatrix()
        {
            var angle = fixture.Create<double>();

            var subject = fixture.Create<RotationFactory>();

            var result = subject.RotateZ(angle);

            Assert.That(result[0, 0], Is.EqualTo(Math.Cos(angle)));
            Assert.That(result[0, 1], Is.EqualTo(Math.Sin(angle)));
            Assert.That(result[0, 2], Is.EqualTo(0));
            Assert.That(result[0, 3], Is.EqualTo(0));
            Assert.That(result[1, 0], Is.EqualTo(-Math.Sin(angle)));
            Assert.That(result[1, 1], Is.EqualTo(Math.Cos(angle)));
            Assert.That(result[1, 2], Is.EqualTo(0));
            Assert.That(result[1, 3], Is.EqualTo(0));
            Assert.That(result[2, 0], Is.EqualTo(0));
            Assert.That(result[2, 1], Is.EqualTo(0));
            Assert.That(result[2, 2], Is.EqualTo(1));
            Assert.That(result[2, 3], Is.EqualTo(0));
            Assert.That(result[3, 0], Is.EqualTo(0));
            Assert.That(result[3, 1], Is.EqualTo(0));
            Assert.That(result[3, 2], Is.EqualTo(0));
            Assert.That(result[3, 3], Is.EqualTo(1));
        }
    }
}
