using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Vector3> _points;
    private List<Vector3> _direction;

    public Vector3 Start
    {
        get { return _points[0]; }
        set { _points[0] = value; }
    }

    public Vector3 End
    {
        get { return _points[_points.Count - 1]; }
        set { _points[_points.Count - 1] = value; }
    }

    public Vector3 this[int i] 
    {
        get { return _points[i]; }
        set { _points[i] = value; }
    }

    public Vector3 Direction(int index)
    {
        if (index < _points.Count -1)
        {
            return (_direction[index]);
        }
        return Vector3.zero;
    }
    public void OnValidate()
    {
        _direction = new List<Vector3>();
        for (int i = 0; i < _points.Count-1; i++)
        {
            _direction.Add((_points[i + 1] - _points[i]).normalized);
        }
    }
}
