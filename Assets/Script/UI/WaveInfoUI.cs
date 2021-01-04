using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveInfoUI : MonoBehaviour
{
    private Text _text;
    private PlayerUI _ui;

    public void Start()
    {
        _text = GetComponentInChildren<Text>();
        _ui = GetComponentInParent<PlayerUI>();
    }

    public void Update()
    {
        _text.text = _ui.PlayerController.GameController.WaveController.TimeLeftString();
    }
}
