using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoard : MonoBehaviour
{
    
    public Hero _hero;
    public Vector2 _size;

    private List<UnitSpawner> _spawners;

    public void Awake()
    {
        _spawners = new List<UnitSpawner>();
    }

    void Start()
    {
        
    }

    private int CreateSpawner(Unit unit, Vector2 position)
    {
        UnitSpawner unit_spawner = gameObject.AddComponent<UnitSpawner>();
        unit_spawner._unit = unit;

        position = this.transform.position + new Vector3(_size.x * (position.x - 0.5f), 0, _size.y * (position.y - 0.5f)) ;
        unit_spawner.transform.position = position;
        
        _spawners.Add(unit_spawner);

        return _spawners.Count - 1;
    }

    void Update()
    {
        
    }

    private void OnValidate()
    {
        Transform spawner_transform = GetComponentInChildren<MeshRenderer>().transform;

        spawner_transform.localScale = new Vector3(_size.x, spawner_transform.localScale.y, _size.y);
    }
}
