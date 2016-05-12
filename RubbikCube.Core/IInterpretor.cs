using System.Collections.Generic;
using RubiksCube.Core.Model.Rotations;

namespace RubiksCube.Core
{
    public interface IInterpretor
    {
        ICollection<RotationInfo> Interpret(string moves);
    }
}
