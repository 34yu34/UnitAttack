using GameSide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayer
{
    // sub controller
    private PlayerCamera _player_camera;
    private PlayerUI _ui;
    private MoneyGenerator _money_generator;
    public MoneyGenerator MoneyGenerator => _money_generator;

    private SpawnerBoard _spawner;
    public SpawnerBoard Spawner { get { return _spawner; } }

    [SerializeField]
    private GameSide.UnitSide _side;
    public GameSide.UnitSide Side { get { return _side; } }

    private GameController _game_controller;
    public GameController GameController { get { return _game_controller; } }

    // These are the buyable Unit for the player
    [SerializeField]
    private Hero _hero;
    public Hero Hero { get { return _hero; } }

    private void OnValidate()
    {
        // parents component
        _game_controller = GetComponentInParent<GameController>();

        // self component
        _money_generator = GetComponent<MoneyGenerator>();
        

        // Child component
        _player_camera = GetComponentInChildren<PlayerCamera>();
        _ui = GetComponentInChildren<PlayerUI>();
        _spawner = GetComponentInChildren<SpawnerBoard>();
    }

    public Vector2Int board_dimension()
    {
        return GameController.BoardDimension;
    }

    private void Update()
    {

    }
}
