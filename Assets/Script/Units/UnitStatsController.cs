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
    public Stat SpawnCooldown;
    public Stat MovementSpeed;

    public UnitStatsController()
    {
        Health = new StatExpandable();
        
        Attack = new Stat();
        AttackSpeed = new Stat();

        SpawnCooldown = new Stat();
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

        SpawnCooldown.Update();
        Range.Update();
        MovementSpeed.Update();

    }

    public void ResetStats()
    {
        Health.ResetStat();
        
        Attack.ResetStat();
        AttackSpeed.ResetStat();

        SpawnCooldown.ResetStat();
        Range.ResetStat();
        MovementSpeed.ResetStat();
    }
}
