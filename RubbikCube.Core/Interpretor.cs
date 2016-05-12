using System.Collections.Generic;
using System.Linq;
using RubiksCube.Core.Model.Rotations;
using RubiksCube.Core.Model.Rotations.XAxis;
using RubiksCube.Core.Model.Rotations.YAxis;
using RubiksCube.Core.Model.Rotations.ZAxis;

namespace RubiksCube.Core
{
    public class Interpretor : IInterpretor
    {
        private readonly Dictionary<string, RotationInfo> mappings;

        public Interpretor()
        {
            mappings = new Dictionary<string, RotationInfo>();
            mappings["L"] = new LeftFaceRotationInfo(true);
            mappings["L'"] = new LeftFaceRotationInfo(false);
            mappings["R"] = new RightFaceRotationInfo(true);
            mappings["R'"] = new RightFaceRotationInfo(false);
            mappings["F"] = new FrontFaceRotationInfo(true);
            mappings["F'"] = new FrontFaceRotationInfo(false);
            mappings["B"] = new BackFaceRotationInfo(false);
            mappings["B'"] = new BackFaceRotationInfo(true);
            mappings["U"] = new UpFaceRotationInfo(true);
            mappings["U'"] = new UpFaceRotationInfo(false);
            mappings["D"] = new DownFaceRotationInfo(true);
            mappings["D'"] = new DownFaceRotationInfo(false);
        }

        public ICollection<RotationInfo> Interpret(string moves)
        {
            var items = moves.Split(' ');
            return items.Select(item => mappings[item]).ToList();
        }
    }
}
