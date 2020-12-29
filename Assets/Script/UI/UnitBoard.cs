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
    private List<UnitBoardItem> _tiles;

    //Top playerController
    private PlayerController _player_controller;
    public PlayerController PlayerController { get { return _player_controller; } }

    // the spwaner Board reference
    private SpawnerBoard _spawner;

    
    // Ui info
    private PlayerUI _ui;
    public PlayerUI UI { get { return _ui; } }

    private Rect _board_zone;

    void Awake()
    {
        resize();
    }

    public UnitBoardItem this[int i]
    {
        get { return _tiles[i]; }
    }

    public void SetUnit(int index, Unit u)
    {
        int board_ref = _spawner.CreateSpawner(u, GetPosition(index));
        _tiles[index].SetUnit(u, board_ref);
    }

    public int Size
    {
        get { return _tiles.Count; }
    }

    private void resize()
    {
        _board_zone = new Rect();
        int side_size = padding + _basic_tile.Size / 2;
        int start_x = -side_size - (_player_controller._board_dimension.x / 2) * side_size - ((_player_controller._board_dimension.x % 2) * side_size);
        int start_y = side_size + (_player_controller._board_dimension.y - 1) * (2 * side_size);
        _tiles = new List<UnitBoardItem>(_player_controller._board_dimension.x * _player_controller._board_dimension.y);
        for (int i = 0; i < _player_controller._board_dimension.x; ++i)
        {
            for (int j = 0; j < _player_controller._board_dimension.y; j++)
            {
                Vector2Int pos = new Vector2Int(start_x + 2 * i * side_size, start_y - 2 * j * side_size);

                create_image(pos);
 
            }
        }
    }

    private void create_image(Vector2Int pos)
    {
        UnitBoardItem img = Instantiate(_basic_tile, this.transform);
        img.SetPosition(pos);
        Rect _unit_rect = img.GetComponent<RectTransform>().rect;

        _unit_rect.center = img.GetComponent<RectTransform>().anchoredPosition;

        englobe_rect(_unit_rect);

        _tiles.Add(img);
    }

    // Gives out the position on the board between 0 and 1
    public Vector2 GetPosition(int index)
    {
        return (_tiles[index].Position - _board_zone.min) / (_board_zone.max - _board_zone.min);
    }

    // this function makes sure the board zone includes the rect provided
    private void englobe_rect(Rect rect)
    {
        if (rect.min.x <= _board_zone.min.x)
        {
            _board_zone.min = new Vector2(rect.min.x, _board_zone.min.y);
        }
        if (rect.min.y <= _board_zone.min.y)
        {
            _board_zone.min = new Vector2(_board_zone.min.x, rect.min.y);
        }
        if (rect.max.x >= _board_zone.max.x)
        {
            _board_zone.max = new Vector2(rect.max.x, _board_zone.max.y);
        }
        if (rect.max.y >= _board_zone.max.y)
        {
            _board_zone.max = new Vector2(_board_zone.max.x, rect.max.y);
        }
    }


    private void OnValidate()
    {
        _player_controller = GetComponentInParent<PlayerController>();
        _ui = GetComponentInParent<PlayerUI>();
        _spawner = _player_controller.Hero.Spawner;
    }
}
