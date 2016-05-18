﻿using PaddleBuddy.Core.Models.Map;

namespace PaddleBuddy.Core.DependencyServices
{
    public interface IMapDrawer
    {
        void DrawLine(Point[] points);
        void DrawMarker(Point point);
        void MoveCamera(Point p);
        void MoveCameraZoom(Point p, int zoom);
        void AnimateCameraBounds(Point[] points);
    }
}
