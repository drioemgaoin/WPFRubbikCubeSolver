using System.Collections.Generic;
using RubiksCube.Core.Model.Rotations;

namespace RubiksCube.Core
{
    public interface IMoveInterpretor
    {
        ICollection<RotationInfo> Interpret(string algorythm);
    }
}
