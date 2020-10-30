using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBoard : MonoBehaviour
{
    // Dimensions and unit size
    public int padding;

    // Basic tiles
    public UnitBoardImage _basic_tile;
    
    //boards images and units
    private UnitBoardImage[][] _images;

    //Top playerController
    private PlayerController _player_controller;

    void Awake()
    {
        _player_controller = GetComponentInParent<PlayerController>();
        resize();
    }

    public UnitBoardImage this[int i, int j]
    {
        get { return _images[i][j]; }
    }

    public UnitBoardImage[] this[int i]
    {
        get { return _images[i]; }
    }

    private void resize()
    {
        int side_size = padding + _basic_tile._size / 2;
        int start_x = -side_size - (_player_controller._board_dimension.x / 2) * side_size - ((_player_controller._board_dimension.x % 2) * side_size);
        int start_y = side_size + (_player_controller._board_dimension.y - 1) * (2 * side_size);
        _images = new UnitBoardImage[_player_controller._board_dimension.x][];
        for (int i = 0; i < _player_controller._board_dimension.x; ++i)
        {
            _images[i] = new UnitBoardImage[_player_controller._board_dimension.y];
            for (int j = 0; j < _player_controller._board_dimension.y; j++)
            {
                Vector2Int pos = new Vector2Int(start_x + 2 * i * side_size, start_y - 2 * j * side_size);
                UnitBoardImage img = Instantiate(_basic_tile, this.transform);
                img.SetPosition(pos);
                _images[i][j] = img;
            }
        }
    }
}
