using System;
using RubiksCube.Factory;

namespace RubiksCube.Service
{
    public interface IRotationService
    {
        Func<double>[,] RotationRow(double angle);
        Func<double>[,] RotationColumn(double angle);
    }

    public class RotationService : IRotationService
    {
        private readonly IRotationFactory rotationFactory;
        private double angleX;
        private double angleY;

        public RotationService()
        {
            rotationFactory = new RotationFactory();
        }

        public Func<double>[,] RotationRow(double angle)
        {
            angleX += angle;
            return rotationFactory.RotateX(angleX);
        }

        public Func<double>[,] RotationColumn(double angle)
        {
            angleY += angle;
            return rotationFactory.RotateY(angleY);
        }
    }
}