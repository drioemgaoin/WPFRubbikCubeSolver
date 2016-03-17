using System;
using System.Collections.Generic;
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

        public CubeService()
        {
            rotationService = new RotationService();
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