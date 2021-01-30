using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTripEntity : Entity
{
    public Vector2Int localMoveTarget;
    public int CellPerStep;
    public int oxygenVoler;

    private bool aller;
    private Vector2Int startPosition;
    private Vector2Int targetPosition;
    private Vector2Int target;
    private EntityManager manager;
    private bool interacted;

    override public void Init()
    {
        manager = GameManager.Instance.entityManager;
        transform.position = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z));

        position.x = (int)(transform.position.x);
        position.y = (int)(transform.position.z);

        startPosition = position;
        targetPosition = startPosition + localMoveTarget;

        target = targetPosition;
    }

    public override void Step()
    {
        Vector2Int dir = target - position;
        interacted = false;

        if (dir.magnitude == 0) 
        {
            target = aller ? targetPosition : startPosition;
            aller = !aller;
        }

        position += Pathfinding.GetStepMovement(manager, this, target, CellPerStep);
        transform.position = new Vector3(position.x, 0, position.y);
    }

    public override void Interact(Entity other)
    {
        if (!interacted  && other.type == EntityType.player)
        {
            GameManager.Instance.resourcesManager.oxygen -= oxygenVoler;
            interacted = true;
        }
    }
}
