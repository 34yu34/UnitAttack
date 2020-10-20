using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideUnitsController : MonoBehaviour
{
    public GameUnitsController _game_units;
    public List<Unit> _units;
    public List<Vector3> points;
    
    // Start is called before the first frame update
    void Start()
    {
        _units = new List<Unit>();
        FindSubUnits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FindSubUnits()
    {
        Unit[] units = GetComponentsInChildren<Unit>();
        foreach (Unit u in units)
        {
            _units.Add(u);
            u._side_controller = this;
        }
    }
}
