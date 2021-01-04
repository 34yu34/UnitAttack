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

    public void SetGameMoney(int starting_money, int money_step_gain, float money_step_time)
    {
        _update_time = money_step_time;
        _starting_money = starting_money;
        _money_step = money_step_gain;
        initialize_money();
    }

    private void initialize_money()
    {
        _money = _starting_money;
        _update_timer = 0;
    }

    void Start()
    {
        initialize_money();
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
