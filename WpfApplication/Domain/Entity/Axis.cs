using System.Windows.Media.Media3D;

namespace WpfApplication.Domain.Entity
{
    public class Axis
    {
        public Axis(double x, double y, double z)
        {
            Vector = new Vector3D(x, y, z);
        }

        public Vector3D Vector { get; private set; }

        public double Angle { get; set; }
    }
}
