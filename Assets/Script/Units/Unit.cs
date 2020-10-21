using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Unit : MonoBehaviour
{
    public UnitStatsController _stats;
    public UnitStateController _states;
    public SideUnitsController _side_controller;
    public SphereCollider _range_collider;

    public Rigidbody _rb;
    public Collider _col;
    public Unit _target;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
        _range_collider = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        _range_collider.isTrigger = true;
        _range_collider.radius = _stats.Range.Value;
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

    public bool InRange(Unit u)
    {
        return Vector3.Distance(u.transform.position, gameObject.transform.position) <= _stats.Range.Value;
    }

    public void FindTraget()
    {
        List<Unit> potentials = _side_controller._game_controller.GetEnemyUnits(this);

        foreach (Unit u in potentials)
        {
            if (InRange(u))
            {
                _target = u;
                return;
            }
        }
    }
}
