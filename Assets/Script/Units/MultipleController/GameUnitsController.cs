using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class GameUnitsController : MonoBehaviour
{
    public enum Side
    {
        None,
        Top,
        Bot
    }
    private SideUnitsController _bot;
    private SideUnitsController _top;
    
    void Awake()
    {
        _top = GameObject.Find("Topside").GetComponent<SideUnitsController>();
        _bot = GameObject.Find("Botside").GetComponent<SideUnitsController>();

        Setup();
    }

    private void Setup()
    {
        _top._game_controller = this;
        _top._side = Side.Top;
        _bot._game_controller = this;
        _bot._side = Side.Bot;
    }

    public SideUnitsController GetOtherSide(Side s)
    {
        if (s is Side.Bot)
        {
            return _top;
        }
        else if (s is Side.Top)
        {
            return _bot;
        }
        return null;
    }

    public List<Unit> GetEnemyUnits(Unit u)
    {
        if (u._side_controller._side == Side.Top)
        {
            return _bot._units;
        }
        else if (u._side_controller._side == Side.Bot)
        {
            return _top._units;
        }

        return new List<Unit>();

    }
}
