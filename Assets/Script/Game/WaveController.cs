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

    private Dictionary<int ,DelegateWaveLaunch> _wave_laucher_delegates;
    private int _hash_int;

    void Start()
    {
        _timer = 0;
        _wave_number = 0;
        _hash_int = 0;
        _wave_laucher_delegates = new Dictionary<int, DelegateWaveLaunch>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _wave_trigger_time)
        {
            TriggerWaves();
            _timer = 0;
            ++_wave_number;
        }
    }

    // will trigger the given function everytime a wave is launch
    public int RegisterWaveLauncher(DelegateWaveLaunch launcher)
    {
        _wave_laucher_delegates[_hash_int] =  launcher;

        return _hash_int++;
    }

    public void UnregisterWaveLauncher(int hash)
    {
        _wave_laucher_delegates.Remove(hash);
    }

    public void TriggerWaves()
    {
        foreach (var launcher in _wave_laucher_delegates)
        {
            launcher.Value.Invoke();
        }
    }

    public string TimeLeftString()
    {
        return "Wave : " + _wave_number.ToString() + "\nTime : " + (_wave_trigger_time - _timer).ToString("F1");
    }


}
