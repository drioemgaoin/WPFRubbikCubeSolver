using System;
using NUnit.Framework;
using Ploeh.AutoFixture;
using RubiksCube.Core.Model.Rotations;

namespace RubiksCube.Core.Tests.Model
{
    [TestFixture]
    public class MatrixFactoryTests
    {
        private IFixture fixture;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            fixture = new Fixture();
        }

        [Test]
        public void GivenAngle_WhenCreateRotateXRotationMatrix_ThenRotationsAreSet()
        {
            var angle = fixture.Create<double>();
            var result = RotationMatrixFactory.CreateXAxisRotation(angle);

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
        public void GivenAngle_WhenCreateRotateYRotationMatrix_ThenRotationsAreSet()
        {
            var angle = fixture.Create<double>();
            var result = RotationMatrixFactory.CreateYAxisRotation(angle);

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
        public void GivenAngle_WhenCreateRotateZRotationMatrix_ThenRotationsAreSet()
        {
            var angle = fixture.Create<double>();
            var result = RotationMatrixFactory.CreateZAxisRotation(angle);

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
