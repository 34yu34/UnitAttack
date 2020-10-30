using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideUnitsController : MonoBehaviour
{
    public GameUnitsController _game_controller;
    public GameUnitsController.Side _side;
    public List<Unit> _units;
    public Path _path;
    
    // Start is called before the first frame update
    void Start()
    {
        _units = new List<Unit>();
        FindSubUnits();
        _path = GetComponentInChildren<Path>();
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

    public void AddUnit(ref Unit u)
    {
        _units.Add(u);
        u._side_controller = this;
    }

    public void Spawn()
    {

    }

}
