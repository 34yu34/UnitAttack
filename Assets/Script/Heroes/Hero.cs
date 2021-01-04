using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private List<Unit> _units;
    public List<Unit> Units { get { return _units; } }
}
