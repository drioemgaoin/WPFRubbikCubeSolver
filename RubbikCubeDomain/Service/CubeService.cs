using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel;
using System.Linq;
>>>>>>> 5491ab82b046a0bd9d71b3d08e9322c4d5e9cb3f
using RubiksCube.Entity;
using RubiksCube.Enums;

namespace RubiksCube.Service
{
    public interface ICubeService
    {
        IList<Face> RotateOnRightSide(Cube cube, RotationType rotationType);
        IList<Face> RotateOnLeftSide(Cube cube, RotationType rotationType);
        IList<Face> RotateOnUpSide(Cube cube, RotationType rotationType);
        IList<Face> RotateOnDownSide(Cube cube, RotationType rotationType);
    }

    public class CubeService : ICubeService
    {
        private readonly IRotationService rotationService;
<<<<<<< HEAD

=======
        private double currentAngleX;
        private double currentAngleY;
        
>>>>>>> 5491ab82b046a0bd9d71b3d08e9322c4d5e9cb3f
        public CubeService()
        {
            rotationService = new RotationService();
        }

        public void Rotate(Cube cube, Rotation rotation)
        {
            Action rorateAction;
            switch (rotation.Direction)
            {
                case Rotation.Up:
                    rorateAction = () => RotateOnUpSide(cube, RotationType.All);
                    break;
                case Rotation.Right:
                    rorateAction = () => RotateOnRightSide(cube, RotationType.All);
                    break;
                case Rotation.Left:
                    rorateAction = () => RotateOnLeftSide(cube, RotationType.All);
                    break;
                case Rotation.Down:
                    rorateAction = () => RotateOnDownSide(cube, RotationType.All);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            for (int i = 0; i < rotation.Times; i++)
            {
                rorateAction();
            }
        }

        public IList<Face> RotateOnRightSide(Cube cube, RotationType rotationType)
        {
            var rotation = rotationService.RotationRow(Math.PI / 2);
            return cube.RotateOnRightSide(rotation, rotationType);
        }

        public IList<Face> RotateOnLeftSide(Cube cube, RotationType rotationType)
        {
            var rotation = rotationService.RotationRow(-Math.PI / 2);
            return cube.RotateOnLeftSide(rotation, rotationType);
        }

        public IList<Face> RotateOnUpSide(Cube cube, RotationType rotationType)
        {
            var rotation = rotationService.RotationColumn(Math.PI / 2);
            return cube.RotateOnUpSide(rotation, rotationType);
        }

        public IList<Face> RotateOnDownSide(Cube cube, RotationType rotationType)
        {
            var rotation = rotationService.RotationColumn(-Math.PI / 2);
            return cube.RotateOnDownSide(rotation, rotationType);
        }
    }
}