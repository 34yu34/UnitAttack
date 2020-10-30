using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // sub controller
    private PlayerCamera _camera;
    private UnitBoard _playing_board;
    private UnitShop _shop;

    // These are the buyable Unit for the player
    public Unit[] _units;

    // The actual board size
    public Vector2Int _board_dimension;

    // Control entry
    private Vector3 _mouse_pos;
    private bool _mouse_down;

    private void Awake()
    {
        _camera = GetComponent<PlayerCamera>();
        _playing_board = GetComponentInChildren<UnitBoard>();
        _shop = GetComponentInChildren<UnitShop>();
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
