using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitDragData : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Unit _unit;

    private PlayerUI _ui;
    private UnitBoardImage _image;
    private Vector3 _last_mouse_pos;

    public void Awake()
    {
        _ui = GetComponentInParent<PlayerUI>();
        _image = GetComponentInChildren<UnitBoardImage>();
    }

    public Unit Unit
    {
        get { return _unit; }
        set
        {
            _unit = value;
            _image.Unit = _unit;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _last_mouse_pos = Input.mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 delta = Input.mousePosition - _last_mouse_pos;
        GetComponent<RectTransform>().anchoredPosition += new Vector2(delta.x, delta.y);

        _last_mouse_pos = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        for (int i = 0; i < _ui.Board.Size; ++i)
        {
            if (_ui.Board[i].IsInside())
            {
                if (_ui.PlayerController.MoneyGenerator.Pay(_unit._stats.Price) == MoneyGenerator.TransactionCode.Accepted)
                {
                    _ui.Board.SetUnit(i, _unit);
                }
            }
        }
        Destroy(gameObject);
    }
}
