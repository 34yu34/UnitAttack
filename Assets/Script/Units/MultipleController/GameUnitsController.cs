using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnitsController : MonoBehaviour
{
    private SideUnitsController _bot;
    private SideUnitsController _top;
    // Start is called before the first frame update
    void Awake()
    {
        _top = GameObject.Find("Topside").GetComponent<SideUnitsController>();
        _bot = GameObject.Find("Botside").GetComponent<SideUnitsController>();

        _top._game_units = this;
        _bot._game_units = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
