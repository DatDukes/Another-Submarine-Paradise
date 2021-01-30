using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEntity : Entity
{
    public Entity player;
    public int cellPerStep;

    private EntityManager manager;

    public override void Init()
    {
        manager = GameManager.Instance.entityManager;
        player = manager.Player;
        transform.position = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z));

        position.x = (int)(transform.position.x);
        position.y = (int)(transform.position.z);
    }

    public override void Step()
    {
        position += Pathfinding.GetStepMovement(manager, this, player.position, cellPerStep);
        transform.position = new Vector3(position.x, 0, position.y);
    }
}
