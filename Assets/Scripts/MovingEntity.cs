using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : Entity
{
    public Vector2Int movePerStep;

    private EntityManager manager;

    override public void Init()
    {
        manager = GameManager.Instance.entityManager;
        transform.position = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z));

        position.x = (int)(transform.position.x);
        position.y = (int)(transform.position.z);
    }

    public override void Step()
    {
        position += Pathfinding.GetStepMovement(manager, this, position + movePerStep, 999);
        transform.position = new Vector3(position.x, 0,position.y);
    }
}
