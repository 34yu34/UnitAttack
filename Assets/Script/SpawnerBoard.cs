using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoard : MonoBehaviour
{

    public Hero _hero;
    public Vector2 _size;
    [SerializeField]
    private Path _path;
    public Path Path { get { return _path; } }

    private Dictionary<int, UnitSpawner> _spawners;

    private IPlayer _player;
    public IPlayer Player { get { return _player; } }

    // unique int for each spawner created in the game
    private int _item_counter;


    public void Awake()
    {
        _spawners = new Dictionary<int, UnitSpawner>();
        _player = GetComponentInParent<IPlayer>();
        _item_counter = 1;
    }

    void Start()
    {

    }

    public int CreateSpawner(Unit unit, Vector2 position_2d)
    {
        GameObject go = new GameObject();
        UnitSpawner unit_spawner = go.AddComponent<UnitSpawner>();
        unit_spawner._unit = unit;

        go.transform.parent = transform;

        Vector3 position_3d = this.transform.position + new Vector3(_size.x * (position_2d.x - 0.5f), 0, _size.y * (position_2d.y - 0.5f)) ;
        unit_spawner.transform.position = position_3d;
        
        _spawners[_item_counter] = unit_spawner;

        return _item_counter++;
    }

    public void RemoveSpawner(int index)
    {
        _spawners.Remove(index);
    }

    

    void Update()
    {

    }

    private void OnValidate()
    {
        Transform spawner_transform = GetComponentInChildren<MeshRenderer>().transform;

        spawner_transform.localScale = new Vector3(_size.x, spawner_transform.localScale.y, _size.y);

        if (_path == null)
        {
            _path = this.gameObject.AddComponent<Path>();
        }
    }
}
