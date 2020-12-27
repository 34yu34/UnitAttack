using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RessourceUI : MonoBehaviour
{
    private PlayerUI _ui;
    private Text _price_text;
    // Start is called before the first frame update
    void Start()
    {
        _price_text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _price_text.text = "Money : " + _ui.PlayerController.MoneyGenerator.Money.ToString();
    }

    private void OnValidate()
    {
        _ui = GetComponentInParent<PlayerUI>();
    }
}
