using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RubiksCube.Core.Model;
using RubiksCube.Core.Service;

namespace RubiksCube.Core.Model
{
    public class Cube
    {
        private readonly IRotationService rotationService;

        public Cube()
        {
            rotationService = new RotationService();

            FrontFace = new Face();
            LeftFace = new Face();
            RightFace = new Face();
            BottomFace = new Face();
            TopFace = new Face();
            BackFace = new Face();
        }

        public Face FrontFace { get; set; }
        public Face LeftFace { get; set; }
        public Face RightFace { get; set; }
        public Face BottomFace { get; set; }
        public Face TopFace { get; set; }
        public Face BackFace { get; set; }

        public IList<List<Face>> Rotate(Rotation rotation)
        {
            var facies = new List<List<Face>>();
            for (var i = 0; i < rotation.Times; i++)
            {
                facies.Add(new List<Face>());
                switch (rotation.Direction)
                {
                    case Rotation.Up:
                        facies[i].AddRange(RotateOnUpSide(RotationType.All));
                        break;
                    case Rotation.Right:
                        facies[i].AddRange(RotateOnRightSide(RotationType.All));
                        break;
                    case Rotation.Left:
                        facies[i].AddRange(RotateOnLeftSide(RotationType.All));
                        break;
                    case Rotation.Down:
                        facies[i].AddRange(RotateOnDownSide(RotationType.All));
                        break;
                }
            }

            return facies;
        }

        private IList<Face> RotateOnRightSide(RotationType rotationType)
        {
            var matrix = rotationService.RotationRow(Math.PI / 2);

            var frontFacies = FrontFace.RotateRow(matrix, rotationType).ToList();
            var leftFacies = LeftFace.RotateRow(matrix, rotationType).ToList();
            var rightFacies = RightFace.RotateRow(matrix, rotationType).ToList();
            var backFacies = BackFace.RotateRow(matrix, rotationType).ToList();

            Move(LeftFace, FrontFace, leftFacies);
            Move(BackFace, LeftFace, backFacies);
            Move(RightFace, BackFace, rightFacies);
            Move(FrontFace, RightFace, frontFacies);

            System.Diagnostics.Debug.WriteLine(this);

            return frontFacies
                .Union(leftFacies)
                .Union(rightFacies)
                .Union(backFacies).ToList();
        }

        private IList<Face> RotateOnLeftSide(RotationType rotationType)
        {
            var matrix = rotationService.RotationRow(-Math.PI / 2);

            var frontFacies = FrontFace.RotateRow(matrix, rotationType).ToList();
            var leftFacies = LeftFace.RotateRow(matrix, rotationType).ToList();
            var rightFacies = RightFace.RotateRow(matrix, rotationType).ToList();
            var backFacies = BackFace.RotateRow(matrix, rotationType).ToList();

            Move(RightFace, FrontFace, rightFacies);
            Move(BackFace, RightFace, backFacies);
            Move(LeftFace, BackFace, leftFacies);
            Move(FrontFace, LeftFace, frontFacies);

            System.Diagnostics.Debug.WriteLine(this);

            return frontFacies
                .Union(leftFacies)
                .Union(rightFacies)
                .Union(backFacies).ToList();
        }

        private IList<Face> RotateOnUpSide(RotationType rotationType)
        {
            var matrix = rotationService.RotationColumn(Math.PI / 2);

            var frontFacies = FrontFace.RotateColumn(matrix, rotationType).ToList();
            var bottomFacies = BottomFace.RotateColumn(matrix, rotationType).ToList();
            var topFacies = TopFace.RotateColumn(matrix, rotationType).ToList();
            var backFacies = BackFace.RotateColumn(matrix, rotationType).ToList();

            Move(BottomFace, FrontFace, bottomFacies);
            Move(BackFace, BottomFace, backFacies);
            Move(TopFace, BackFace, topFacies);
            Move(FrontFace, TopFace, frontFacies);

            System.Diagnostics.Debug.WriteLine(this);

            return frontFacies
                .Union(topFacies)
                .Union(bottomFacies)
                .Union(backFacies).ToList();
        }

        private IList<Face> RotateOnDownSide(RotationType rotationType)
        {
            var matrix = rotationService.RotationColumn(-Math.PI / 2);

            var frontFacies = FrontFace.RotateColumn(matrix, rotationType).ToList();
            var bottomFacies = BottomFace.RotateColumn(matrix, rotationType).ToList();
            var topFacies = TopFace.RotateColumn(matrix, rotationType).ToList();
            var backFacies = BackFace.RotateColumn(matrix, rotationType).ToList();

            Move(TopFace, FrontFace, topFacies);
            Move(BackFace, TopFace, backFacies);
            Move(BottomFace, BackFace, bottomFacies);
            Move(FrontFace, BottomFace, frontFacies);

            System.Diagnostics.Debug.WriteLine(this);

            return frontFacies
                .Union(topFacies)
                .Union(bottomFacies)
                .Union(backFacies).ToList();
        }

        private static void Move(Face source, Face target, IList<Face> facies)
        {
            foreach (var facie in facies)
            {
                source.Facies.Remove(facie);
            }

            foreach (var facie in facies)
            {
                facie.Move(target.Type);
                target.Facies.Add(facie);
            }
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            buffer.Append(FrontFace);
            buffer.Append(RightFace);
            buffer.Append(BackFace);
            buffer.Append(LeftFace);
            buffer.Append(TopFace);
            buffer.Append(BottomFace);
            return buffer.ToString();
        }
    }
}