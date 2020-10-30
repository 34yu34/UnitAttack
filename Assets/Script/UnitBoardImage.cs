using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class UnitBoardImage : MonoBehaviour
{
    private readonly string _empty_tile_path = "UnitBoardImages/Selector-Empty";
    private readonly string _basic_unit_sprite_path = "UnitBoardImages/Basic_Unit";
    private Sprite _empty_tile;
    private Sprite _basic_unit_sprite;

    public int _size;

    private Unit _unit;

    private UnityEngine.UI.Image _image_selector;
    private RectTransform _loc;

    void Awake()
    {
        _empty_tile = Resources.Load<Sprite>(_empty_tile_path);
        _basic_unit_sprite = Resources.Load<Sprite>(_basic_unit_sprite_path);
        _image_selector = GetComponent<UnityEngine.UI.Image>();
        _image_selector.sprite = _empty_tile;
        _unit = null;
        _loc = GetComponent<RectTransform>();
        _loc.sizeDelta = new Vector2(_size, _size);
    }

    public void SetPosition(Vector2 v)
    {
        _loc.anchoredPosition = v;
    }

    public Unit Unit
    {
        get { return _unit; }
        set 
        { 
            _unit = value;
            if (_unit != null)
            {
                _image_selector.sprite = _unit._sprite != null ? _unit._sprite : _basic_unit_sprite;
            }
            else
            {
                _image_selector.sprite = _empty_tile;
            }
        }
    }

    private void OnValidate()
    {
        _empty_tile = Resources.Load<Sprite>(_empty_tile_path);
        _basic_unit_sprite = Resources.Load<Sprite>(_basic_unit_sprite_path);
    }
}
