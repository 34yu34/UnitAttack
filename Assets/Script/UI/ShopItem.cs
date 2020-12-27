using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler 
{
    private UnitBoardImage _image;
    private UnityEngine.UI.Text _text;

    private RectTransform _transform;

    private Unit _unit;

    public UnitShop _shop;

    void Awake()
    {
        _image = GetComponentInChildren<UnitBoardImage>();
        _text = GetComponentInChildren<UnityEngine.UI.Text>();
        _transform = GetComponent<RectTransform>();
        _shop = GetComponentInParent<UnitShop>();
        if (_unit != null)
        {
            this.Unit = _unit;
        }
    }

    public void SetPosition(Vector2 pos)
    {
        _transform.anchoredPosition = pos;
        _image.SetPosition(new Vector2(0, 0));
    }

    public int size()
    {
        return _image._size;
    }

    public Unit Unit
    {
        get { return _unit; }
        set
        {
            _unit = value;
            _image.Unit = _unit;
            _text.text = _unit._stats.Price.ToString();
        }
    }

    private void OnValidate()
    {
        Awake();
    }


    private UnitDragData _drag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!_shop.UI.PlayerController.MoneyGenerator.CanBuy(_unit._stats.Price))
        {
            _drag = null;
            return;
        }

        _drag = Instantiate(_shop.UI._dragger, transform);
        _drag.Unit = _unit;
        _drag.transform.SetParent(_shop.UI.transform);
        _drag.Awake();

        _drag.OnBeginDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_drag != null)
        {
            _drag.OnEndDrag(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_drag != null)
        {
            _drag.OnDrag(eventData);
        }
    }
}
