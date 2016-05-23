using System.Collections.Generic;
using System.Linq;
using RubiksCube.Core.Model.Rotations;
using RubiksCube.Core.Model.Rotations.XAxis;
using RubiksCube.Core.Model.Rotations.YAxis;
using RubiksCube.Core.Model.Rotations.ZAxis;

namespace RubiksCube.Core
{
    public class MoveInterpretor : IMoveInterpretor
    {
        private readonly Dictionary<string, RotationInfo> mappings;

        public MoveInterpretor()
        {
            mappings = new Dictionary<string, RotationInfo>();
            mappings["L"] = new LeftFaceRotationInfo(true);
            mappings["L2"] = new LeftFaceRotationInfo(true, 2);
            mappings["L'"] = new LeftFaceRotationInfo(false);
            mappings["L2'"] = new LeftFaceRotationInfo(false, 2);
            mappings["R"] = new RightFaceRotationInfo(true);
            mappings["R2"] = new RightFaceRotationInfo(true, 2);
            mappings["R'"] = new RightFaceRotationInfo(false);
            mappings["R2'"] = new RightFaceRotationInfo(false, 2);
            mappings["F"] = new FrontFaceRotationInfo(true);
            mappings["F2"] = new FrontFaceRotationInfo(true, 2);
            mappings["F'"] = new FrontFaceRotationInfo(false);
            mappings["F2'"] = new FrontFaceRotationInfo(false, 2);
            mappings["B"] = new BackFaceRotationInfo(false);
            mappings["B2"] = new BackFaceRotationInfo(false, 2);
            mappings["B'"] = new BackFaceRotationInfo(true);
            mappings["B2'"] = new BackFaceRotationInfo(true, 2);
            mappings["U"] = new UpFaceRotationInfo(true);
            mappings["U2"] = new UpFaceRotationInfo(true, 2);
            mappings["U'"] = new UpFaceRotationInfo(false);
            mappings["U2'"] = new UpFaceRotationInfo(false, 2);
            mappings["D"] = new DownFaceRotationInfo(true);
            mappings["D2"] = new DownFaceRotationInfo(true, 2);
            mappings["D'"] = new DownFaceRotationInfo(false);
            mappings["D2'"] = new DownFaceRotationInfo(false, 2);
        }

        public ICollection<RotationInfo> Interpret(string algorythm)
        {
            var moves = algorythm.Split(' ');

            return moves.Select(item => mappings[item]).ToList();
        }
    }
}
