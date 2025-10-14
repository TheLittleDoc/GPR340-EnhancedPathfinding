using System.Collections.Generic;
using UnityEngine;

namespace Algos
{
    public class Bezier : Smoothing
    {
        public override List<Vector3> Smooth(List<Vector3> inputPoints)
        {
            _inputPoints = inputPoints;
            
            return _outputPoints;
        }
        
        
    }
}