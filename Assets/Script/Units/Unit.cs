using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitStatsController _stats;
    public UnitStateController _states;
    public SideUnitsController _side_controller;

    public Rigidbody _rb;
    public Collider _col;
    public Unit _target;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _states = new UnitStateController(this);
        _stats.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        _stats.Update();
    }
}
