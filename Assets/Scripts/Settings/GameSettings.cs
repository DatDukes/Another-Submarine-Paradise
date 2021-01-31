using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    public int startOxygen;
    public int startMoveRange;

    public int stepOxygenConsumed;

    public float visibilityEnemies;
    public float visibilityStashes;
    public float visibilityTerrains;
}
