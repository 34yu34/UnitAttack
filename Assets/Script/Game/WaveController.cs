using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private float _timer;
    private int _wave_number;

    [SerializeField]
    private float _wave_trigger_time;

    public delegate void DelegateWaveLaunch();

    public List<DelegateWaveLaunch> _wave_laucher_delegates;

    void Start()
    {
        _timer = 0;
        _wave_number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _wave_trigger_time)
        {

        }
    }

    public void RegisterWaveLauncher()
    {

    }
}
