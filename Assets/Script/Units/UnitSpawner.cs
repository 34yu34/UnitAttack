using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public Unit _unit;
    public SideUnitsController _controller;

    private float _timer;
    private float _unit_height;

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0.0f;
        _unit._stats.ResetStats(); // make sure de value are fine

        _unit_height = _unit.GetComponent<CapsuleCollider>().height;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_unit._stats.SpawnCooldown <= _timer)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector3 spawn_pos = _controller._path.Start;
        spawn_pos.y += _unit_height / 2;
        Unit u = Instantiate(_unit, spawn_pos, Quaternion.LookRotation(_controller._path.Direction(0)));
        u.gameObject.SetActive(true);
        _controller.AddUnit(ref u);
        _timer = 0;
    }
}
