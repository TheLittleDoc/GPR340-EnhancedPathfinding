using System;
using System.Collections.Generic;
using UnityEngine;

namespace Algos
{
    struct Segment
    {
        public Vector2 a;
        public Vector2 b;
        public Vector2 c;
        public Vector2 d;
    }
    public class Bezier : Smoothing
    {
        public override List<Vector2> Smooth(List<Vector2> inputPoints, int steps)
        {
            Vector2 p0 = inputPoints[0];
            Vector2 p1 = inputPoints[1];
            Vector2 p2 = inputPoints[2];
            Vector2 p3 = inputPoints[3];
            double alpha = 0.5;
            double tension = 0;
            _inputPoints = inputPoints;
            float t = 0;
            
            double t01 = Math.Pow(Vector2.Distance(_inputPoints[0], _inputPoints[1]), alpha);
            double t12 = Math.Pow(Vector2.Distance(_inputPoints[1], _inputPoints[2]), alpha);
            double t23 = Math.Pow(Vector2.Distance(_inputPoints[2], _inputPoints[3]), alpha);

            Vector2 m1 = (float)(1.0 - tension) * 
                         (p2 - p1 + (float)t12 * ((p1 - p0) / (float)t01 - (p2 - p0) / (float)(t01 + t12)));
            Vector2 m2 = (float)(1.0 - tension) *
                         (p2 - p1 + (float)t12 * ((p3 - p2) / (float)t23 - (p3 - p1) / (float)(t12 + t23)));
            
            Segment segment;
            segment.a = 2.0f * (p1 - p2) + m1 + m2;
            segment.b = -3.0f * (p1 - p2) - m1 - m1 - m2;
            segment.c = m1;
            segment.d = p1;
            
            while (t <= 1)
            {
                Vector2 point =  segment.a * t * t * t +
                                 segment.b * t * t +
                                 segment.c * t +
                                 segment.d;
                _outputPoints.Add(point);
                t += 1 / (float)steps;
            }
            
            
            return _outputPoints;
        }
        
        
    }
}