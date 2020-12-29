using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitBoardItem : MonoBehaviour
{ 
    private bool _is_inside;
    private Unit _unit;
    private int _board_ref;

    private UnitBoard _board;
    private RectTransform _rect_transform;

    public Unit Unit
    {
        get { return _unit; }
        set
        {
            _unit = value;
            _image.Unit = value;
        }
    }

    public void SetUnit(Unit u, int board_ref)
    {
        _board_ref = board_ref;
        Unit = u;
    }

    private UnitBoardImage _image;

    public Vector2 Position
    {
        set { _rect_transform.anchoredPosition = value; }
        get { return _rect_transform.anchoredPosition; }
    }

    public void SetPosition(Vector2 v)
    {
        GetComponent<RectTransform>().anchoredPosition = v;
    }

    public int Size { get { return _image._size; } }


    public void Awake()
    {
        _board = GetComponentInParent<UnitBoard>();
        _image = GetComponentInChildren<UnitBoardImage>();
        _rect_transform = GetComponent<RectTransform>();
    }

    public void OnValidate()
    {
        _board = GetComponentInParent<UnitBoard>();
        _image = GetComponentInChildren<UnitBoardImage>();
        _rect_transform = GetComponent<RectTransform>();
    }

    public bool IsInside()
    {
        Vector2 mouse_pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        Vector2 pos = RectTransformUtility.WorldToScreenPoint(_board.UI.PlayerCamera.Camera, transform.position);

        pos.x -= Size / 2;
        pos.y -= Size / 2;

        Rect zone = new Rect(pos, new Vector2(Size, Size));

        return zone.Contains(mouse_pos);

    }
}
