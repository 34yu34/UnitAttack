using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    GameSide.UnitSide Side { get; }

    Hero Hero { get; }

    SpawnerBoard Spawner { get; }

    GameController GameController { get; }

    MoneyGenerator MoneyGenerator { get; }
}
