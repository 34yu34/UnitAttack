using GameSide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour, IPlayer
{
    [SerializeField]
    private UnitSide _side;
    public UnitSide Side => _side;

    public Hero _hero;
    public Hero Hero => _hero;

    private SpawnerBoard _spawner;
    public SpawnerBoard Spawner => _spawner;

    private GameController _game_controller;
    public GameController GameController => _game_controller;

    [SerializeField]
    private MoneyGenerator _money_generator;
    public MoneyGenerator MoneyGenerator => _money_generator;

    public void Awake()
    {
        _game_controller = GetComponentInParent<GameController>();
        _spawner = GetComponentInChildren<SpawnerBoard>();
    }

    public void Start()
    {
        _spawner.CreateSpawner(_hero.Units[0], new Vector2(0,0));
    }

    public void Update()
    {

    }

    public void OnValidate()
    {
        if (_money_generator == null)
        {
            _money_generator = gameObject.AddComponent<MoneyGenerator>();
        }

        
    }
}