using System;
using System.Collections.Generic;
using UnityEngine;

namespace Algos
{
    struct Segment
    {
        public Vector3 a;
        public Vector3 b;
        public Vector3 c;
        public Vector3 d;
    }
    public class Bezier : Smoothing
    {
        public double alpha = 0.5;
        public double tension = 0;
        public override List<Vector3> Smooth(List<Vector3> inputPoints, int steps)
        {
            this.steps = steps;
            _inputPoints = inputPoints;
            float t = 0;
            
            for (int i = 0; i < _inputPoints.Count - 1; i++)
            {
                Segment segment;
                segment.a = i == 0 ? _inputPoints[i] : _inputPoints[i - 1];
                segment.b = _inputPoints[i];
                segment.c = _inputPoints[i + 1];
                segment.d = i + 2 < _inputPoints.Count ? _inputPoints[i + 2] : _inputPoints[i + 1];
                for (int j = 0; j <= steps; j++)
                {
                    t = j / (float)steps;
                    Vector3 point = calculateCatmulRomPoint(segment.a, segment.b, segment.c, segment.d, t);
                    _outputPoints.Add(point);
                }
            }
            _outputPoints.Add(_inputPoints[_inputPoints.Count - 1]);
            
            
            return _outputPoints;
        }

        public Vector3 calculateCatmulRomPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            float t2 = t * t;
            float t3 = t2 * t;
            
            double t01 = Math.Pow(Vector3.Distance(_inputPoints[0], _inputPoints[1]), alpha);
            double t12 = Math.Pow(Vector3.Distance(_inputPoints[1], _inputPoints[2]), alpha);
            double t23 = Math.Pow(Vector3.Distance(_inputPoints[2], _inputPoints[3]), alpha);
            
            var splineFactor = 0.5f * (1 - tension);
            
            Vector3 m1 = (float)(1.0 - splineFactor) * 
                         (p2 - p1 + (float)t12 * ((p1 - p0) / (float)t01 - (p2 - p0) / (float)(t01 + t12)));
            Vector3 m2 = (float)(1.0 - splineFactor) *
                         (p2 - p1 + (float)t12 * ((p3 - p2) / (float)t23 - (p3 - p1) / (float)(t12 + t23)));
            
            Vector3 point = (2 * p1 - 2 * p2 + m1 + m2) * t3 +
                            (-3 * p1 + 3 * p2 - 2 * m1 - m2) * t2 +
                            m1 * t +
                            p1;

            return point;
        }
        
        
    }
}