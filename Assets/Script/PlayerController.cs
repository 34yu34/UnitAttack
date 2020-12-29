using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // sub controller
    private PlayerCamera _player_camera;
    private PlayerUI _ui;
    private MoneyGenerator _money_generator;
    public MoneyGenerator MoneyGenerator { get { return _money_generator; } }


    // These are the buyable Unit for the player
    [SerializeField]
    private Hero _hero;
    public Hero Hero { get { return _hero; } }

    // The actual board size
    public Vector2Int _board_dimension;

    // Control entry
    private Vector3 _mouse_pos;
    private bool _mouse_down;

    private void Awake()
    {
        _player_camera = GetComponent<PlayerCamera>();
        _ui = GetComponentInChildren<PlayerUI>();
        _money_generator = GetComponent<MoneyGenerator>();
    }

    private void Update()
    {
        UpdateEntry();
    }

    private void UpdateEntry()
    {
        _mouse_down = Input.GetMouseButton(0);
        _mouse_pos = Input.mousePosition;
    }

    private void CheckClick()
    {

    }

}
