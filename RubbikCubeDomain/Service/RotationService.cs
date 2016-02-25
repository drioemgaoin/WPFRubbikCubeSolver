using System;
using RubiksCube.Factory;

namespace RubiksCube.Service
{
    public interface IRotationService
    {
        Func<double>[,] RotationRight(double angle);
        Func<double>[,] RotationLeft(double angle);
        Func<double>[,] RotationUp(double angle);
        Func<double>[,] RotationDown(double angle);
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

        public Func<double>[,] RotationRight(double angle)
        {
            angleX += angle;
            return rotationFactory.RotateX(angleX);
        }

        public Func<double>[,] RotationLeft(double angle)
        {
            angleX += angle;
            return rotationFactory.RotateX(angleX);
        }

        public Func<double>[,] RotationUp(double angle)
        {
            angleY += angle;
            return rotationFactory.RotateY(angleY);
        }

        public Func<double>[,] RotationDown(double angle)
        {
            angleY += angle;
            return rotationFactory.RotateY(angleY);
        }
    }
}