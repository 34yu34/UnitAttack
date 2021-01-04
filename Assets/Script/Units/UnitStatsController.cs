using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitStatsController
{
    public StatExpandable Health;

    public Stat Attack;
    public Stat AttackSpeed;

    public Stat Range;
    public Stat MovementSpeed;

    public int SpawnCooldown;
    public int Price;

    public UnitStatsController()
    {
        Health = new StatExpandable();
        
        Attack = new Stat();
        AttackSpeed = new Stat();

        Range = new Stat();
        MovementSpeed = new Stat();
    }

    public void Start()
    {
        ResetStats();
    }


    public void Update()
    {
        Health.Update();
        
        Attack.Update();
        AttackSpeed.Update();

        Range.Update();
        MovementSpeed.Update();

    }

    public void ResetStats()
    {
        Health.ResetStat();
        
        Attack.ResetStat();
        AttackSpeed.ResetStat();

        Range.ResetStat();
        MovementSpeed.ResetStat();
    }
}
