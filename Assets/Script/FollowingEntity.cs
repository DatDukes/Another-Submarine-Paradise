using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEntity : Entity
{
    public Entity player;
    public int cellPerStep;

    public override void Init()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z));

        position.x = (int)(transform.position.x);
        position.y = (int)(transform.position.z);
    }

    public override void Step()
    {
        position += Pathfinding.GetStepMovement(this, player.position, cellPerStep);
        transform.position = new Vector3(position.x, 0, position.y);
    }
}
