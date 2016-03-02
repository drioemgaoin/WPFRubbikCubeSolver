using RubiksCube.Factory;

namespace RubiksCube.Service
{
    public interface IRotationService
    {
        double[,] RotationRow(double angle);
        double[,] RotationColumn(double angle);
    }

    public class RotationService : IRotationService
    {
        private readonly IRotationFactory rotationFactory;

        public RotationService()
        {
            rotationFactory = new RotationFactory();
        }

        public double[,] RotationRow(double angle)
        {
            return rotationFactory.RotateX(angle);
        }

        public double[,] RotationColumn(double angle)
        {
            return rotationFactory.RotateY(angle);
        }
    }
}