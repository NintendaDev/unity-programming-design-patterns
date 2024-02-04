using Example09.Configurations;
using System.Collections.Generic;
using UnityEngine;

namespace Example09.Core
{
    public class RectangleGridMaker : GridMaker
    {
        private float _width;
        private float _height;
        private float _step;

        public RectangleGridMaker(RectangleGridConfig config) : this(config.Width, config.Height, config.Step)
        {
        }

        public RectangleGridMaker(float width, float height, float step)
        {
            _width = width;
            _height = height;
            _step = step;
        }

        public override List<Vector3> GetGridPoints(Vector3 gridCenter)
        {
            int pointsCountInWidth = (int)Mathf.Ceil(_width / _step);
            int pointsCountInHeight = (int)Mathf.Ceil(_height / _step);

            float halfPointsCountInWidth = (float)pointsCountInWidth / 2;
            float halfPointsCountInHeight = (float)pointsCountInHeight / 2;

            List<Vector3> gridPoints = new();

            Vector3 startGridPoint = new Vector3(gridCenter.x - halfPointsCountInWidth * _step, gridCenter.y,
                gridCenter.x + halfPointsCountInHeight * _step);

            for (int heightCounter = 0; heightCounter < pointsCountInHeight; heightCounter++)
            {
                for (int widthCounter = 0; widthCounter < pointsCountInWidth; widthCounter++)
                {
                    Vector3 gridPoint = new Vector3(startGridPoint.x + _step * widthCounter, startGridPoint.y, startGridPoint.z - _step * heightCounter);
                    gridPoints.Add(gridPoint);
                }
            }

            return gridPoints;
        }
    }
}
