using System.Collections.Generic;
using UnityEngine;

namespace Algos
{
    public class Bezier : Smoothing
    {
        public override List<Vector2> Smooth(List<Vector2> inputPoints, int steps)
        {
            _inputPoints = inputPoints;
            float t = 0;
            
            while (t <= 1)
            {
                Vector2 a = Vector2.Lerp(_inputPoints[0], _inputPoints[1], t);
                Vector2 b = Vector2.Lerp(_inputPoints[1], _inputPoints[2], t);
                Vector2 c = b;
                Vector2 d = Vector2.Lerp(_inputPoints[2], _inputPoints[3], t);
                
                Vector2 p = Vector2.Lerp(Vector2.Lerp(a,b,t),Vector2.Lerp(c,d,t),t);
                _outputPoints.Add(p);
                t += (1.0f / (float)steps);
            }
            
            return _outputPoints;
        }
        
        
    }
}