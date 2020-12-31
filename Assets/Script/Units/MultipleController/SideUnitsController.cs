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
        _path = GetComponentInChildren<Path>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Spawn()
    {

    }

}
