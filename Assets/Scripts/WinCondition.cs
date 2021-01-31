using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WinCondition
{
    public WinCondition(Sprite clue, Vector3 position) 
    {
        this.clue = clue;
        this.position = new Vector2Int((int)position.x, (int)position.z);
    }

    public Sprite clue;
    public Vector2Int position;
}
