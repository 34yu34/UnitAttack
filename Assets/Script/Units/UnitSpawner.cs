using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public Unit _unit;
    public SpawnerBoard _spawner;

    private float _timer;
    private float _unit_height;

    void Start()
    {
        _spawner = GetComponentInParent<SpawnerBoard>();

        _timer = 0.0f;
        _unit._stats.ResetStats(); // make sure de values are fine

        _unit_height = _unit.GetComponent<CapsuleCollider>().height;
    }


    void Update()
    {
        _timer += Time.deltaTime;
        if (_unit._stats.SpawnCooldown <= _timer)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 spawn_pos = Position();
        spawn_pos.y += _unit_height / 2;
        Unit u = Instantiate(_unit, spawn_pos, Quaternion.LookRotation(_spawner.Path.Direction(0)));
        u.setup_side(_spawner);
        u.gameObject.SetActive(true);
        _timer = 0;
    }

    public Vector3 Position()
    {
        return transform.position;
    }
}
