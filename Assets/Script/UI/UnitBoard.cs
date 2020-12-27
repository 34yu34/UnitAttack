using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBoard : MonoBehaviour
{
    // Dimensions and unit size
    public int padding;

    // Basic tiles
    public UnitBoardItem _basic_tile;
    
    //boards images and units
    private UnitBoardItem[] _tiles;

    //Top playerController
    private PlayerController _player_controller;
    public PlayerController PlayerController { get { return _player_controller; } }

    private PlayerUI _ui;
    public PlayerUI UI { get { return _ui; } }

    void Awake()
    {
        resize();
    }

    public UnitBoardItem this[int i]
    {
        get { return _tiles[i]; }
    }

    public int Size
    {
        get { return _tiles.Length; }
    }

    private void resize()
    {
        int side_size = padding + _basic_tile.Size / 2;
        int start_x = -side_size - (_player_controller._board_dimension.x / 2) * side_size - ((_player_controller._board_dimension.x % 2) * side_size);
        int start_y = side_size + (_player_controller._board_dimension.y - 1) * (2 * side_size);
        _tiles = new UnitBoardItem[_player_controller._board_dimension.x * _player_controller._board_dimension.y];
        for (int i = 0; i < _player_controller._board_dimension.x; ++i)
        {
            for (int j = 0; j < _player_controller._board_dimension.y; j++)
            {
                Vector2Int pos = new Vector2Int(start_x + 2 * i * side_size, start_y - 2 * j * side_size);
                UnitBoardItem img = Instantiate(_basic_tile, this.transform);
                img.SetPosition(pos);
                _tiles[(i * _player_controller._board_dimension.y) + j] = img;
            }
        }
    }

    private void OnValidate()
    {
        _player_controller = GetComponentInParent<PlayerController>();
        _ui = GetComponentInParent<PlayerUI>();
    }
}
