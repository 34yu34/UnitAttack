using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitShop : MonoBehaviour
{
    public int _padding;
    public UnitBoardImage _basic_tile;
    
    private Vector2Int _dimension;
    private UnitBoardImage[][] _images;

    private PlayerController _player_controller;

    void Awake()
    {
        _player_controller = GetComponentInParent<PlayerController>();
        setup_dimension();
        resize();
    }

<<<<<<< HEAD
=======

    // make sure there is 2 rows if there is more than 6 units
>>>>>>> add hero and spawner
    private void setup_dimension()
    {
        _dimension = new Vector2Int();
        _dimension.x = _player_controller._units.Length >= 6 ? 2 : 1;
        _dimension.y = _player_controller._units.Length / _dimension.x + _player_controller._units.Length % _dimension.x;
        Debug.Log(_dimension);
    }

    private void resize()
    {
        int side_size = _padding + _basic_tile._size / 2;
        int start_x = -side_size - (_dimension.x - 1) * (2 * side_size);  
        int start_y = side_size + (_dimension.y / 2) * side_size - ((_dimension.y % 2) * side_size);
        _images = new UnitBoardImage[_dimension.x][];
        for (int i = 0; i < _dimension.x; ++i)
        {
            _images[i] = new UnitBoardImage[_dimension.y];
            for (int j = 0; j < _dimension.y; j++)
            {
                Vector2Int pos = new Vector2Int(start_x + 2 * i * side_size, start_y - 2 * j * side_size);
                UnitBoardImage img = Instantiate(_basic_tile, this.transform);
                img.SetPosition(pos);
                img.Unit = _player_controller._units[i * (int)_player_controller._units.Length + j];
                _images[i][j] = img;
            }
        }
    }
}
