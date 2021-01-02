using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private WaveController _wave_controller;

    public List<IPlayer> _players;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnValidate()
    {
        if (_wave_controller == null)
        {
            _wave_controller = gameObject.AddComponent<WaveController>();
        }
    }
}
