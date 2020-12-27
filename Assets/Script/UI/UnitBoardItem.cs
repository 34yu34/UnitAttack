using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitBoardItem : MonoBehaviour
{ 
    private bool _is_inside;
    private Unit _unit;

    private UnitBoard _board;

    public Unit Unit
    {
        get { return _unit; }
        set
        {
            _unit = value;
            _image.Unit = value;
        }
    }

    private UnitBoardImage _image;

    public void SetPosition(Vector2 v)
    {
        GetComponent<RectTransform>().anchoredPosition = v;
    }

    public int Size
    {
        get { return _image._size; }
    }


    public void Awake()
    {
        _board = GetComponentInParent<UnitBoard>();
        _image = GetComponentInChildren<UnitBoardImage>();
    }

    public void OnValidate()
    {
        _board = GetComponentInParent<UnitBoard>();
        _image = GetComponentInChildren<UnitBoardImage>();
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
