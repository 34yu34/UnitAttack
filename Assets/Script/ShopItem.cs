using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    private UnitBoardImage _image;
    private UnityEngine.UI.Text _text;

    private RectTransform _transform;

    private Unit _unit;

    void Awake()
    {
        _image = GetComponentInChildren<UnitBoardImage>();
        _text = GetComponentInChildren<UnityEngine.UI.Text>();
        _transform = GetComponent<RectTransform>();
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


}
