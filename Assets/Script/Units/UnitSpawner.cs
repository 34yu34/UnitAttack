using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public Unit _unit;
    public SpawnerBoard _spawner;

    private int _wave_count;
    private float _unit_height;

    private int _delegate_int;

    void Start()
    {
        _spawner = GetComponentInParent<SpawnerBoard>();

        _wave_count = _unit._stats.SpawnCooldown; // initialize to launch at first wave
        _unit._stats.ResetStats(); // make sure de values are fine

        _unit_height = _unit.GetComponent<CapsuleCollider>().height;

        _delegate_int = _spawner.Player.GameController.WaveController.RegisterWaveLauncher(Spawn);
    }

    private void Spawn()
    {
        ++_wave_count;
        if ( _wave_count >= _unit._stats.SpawnCooldown)
        {   
            Vector3 spawn_pos = Position();
            spawn_pos.y += _unit_height / 2;
            Unit u = Instantiate(_unit, spawn_pos, Quaternion.LookRotation(_spawner.Path.Direction(0)));
            u.setup_side(_spawner);
            u.gameObject.SetActive(true);
            _wave_count = 0;
        }
    }

    public void Disconnect()
    {
        _spawner.Player.GameController.WaveController.UnregisterWaveLauncher(_wave_count);
        Destroy(gameObject);
    }

    public Vector3 Position()
    {
        return transform.position;
    }
}
