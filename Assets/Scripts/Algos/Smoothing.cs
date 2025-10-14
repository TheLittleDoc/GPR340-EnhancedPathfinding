using System.Collections.Generic;
using UnityEngine;

namespace Algos
{
    public class Smoothing : MonoBehaviour
    {
        
        // Input points
        protected List<Vector3> _inputPoints = new List<Vector3>();
        protected List<Vector3> _outputPoints = new List<Vector3>();
        
        public virtual List<Vector3> Smooth(List<Vector3> inputPoints)
        {
            _inputPoints.Clear();
            _inputPoints = inputPoints;
            
            
            return _outputPoints;
        }
        
        
    
    }
}
