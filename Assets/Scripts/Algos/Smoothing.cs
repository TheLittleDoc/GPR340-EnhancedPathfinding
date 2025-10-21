using System.Collections.Generic;
using UnityEngine;

namespace Algos
{
    public class Smoothing : MonoBehaviour
    {
        
        // Input points
        protected List<Vector2> _inputPoints = new List<Vector2>();
        protected List<Vector2> _outputPoints = new List<Vector2>();
        
        public virtual List<Vector2> Smooth(List<Vector2> inputPoints, int steps)
        {
            _inputPoints.Clear();
            _inputPoints = inputPoints;
            
            
            return _outputPoints;
        }
        
        
    
    }
}
