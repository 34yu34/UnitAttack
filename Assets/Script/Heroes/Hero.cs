using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private List<Unit> _units;
    public List<Unit> Units { get { return _units; } }

    private SpawnerBoard _spawner;
    public SpawnerBoard Spawner { get { return _spawner; } }


    public void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValidate()
    {
        
    }
}
