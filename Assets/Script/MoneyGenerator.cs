using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGenerator : MonoBehaviour
{
    public enum TransactionCode
    {
        Refused = 0,
        Accepted = 1
    }

    private int _money;
    private float _update_timer;


    public float _update_time = 10.0f;
    public int _starting_money;
    public int _money_step;
    
    public int Money { get { return _money; } }

    void Start()
    {
        _money = _starting_money;
        _update_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _update_timer += Time.deltaTime;
        
        if (_update_timer > _update_time)
        {
            _money += _money_step;
            _update_timer = 0;
        }
    }

    public bool CanBuy(int price)
    {
        return _money >= price;
    }

    public TransactionCode Pay(int price)
    {
        if (_money < price)
        {
            return TransactionCode.Refused;
        }

        _money -= price;
        return TransactionCode.Accepted;
    }
}
