using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private WaveController _wave_controller;
    public WaveController WaveController { get { return _wave_controller; } }

    // Starting Money Settings
    public int StartingMoney;
    public int MoneyStepGain;
    public float MoneyStepTime;

    // Players
    public List<IPlayer> _players;

    // Boards settings
    public Vector2Int BoardDimension;

    public void Start()
    {
        _players = new List<IPlayer>(GetComponentsInChildren<IPlayer>());
        foreach (IPlayer p in _players)
        {
            p.MoneyGenerator.SetGameMoney(StartingMoney, MoneyStepGain, MoneyStepTime);
        }
    }

    private void OnValidate()
    {
        if (_wave_controller == null)
        {
            _wave_controller = gameObject.AddComponent<WaveController>();
        }
    }
}
