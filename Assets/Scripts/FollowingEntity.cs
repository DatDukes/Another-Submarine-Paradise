using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEntity : Entity
{
    public Entity player;
    public int cellPerStep;
    public int oxygenVoler;
    public int osefTimerApresVol;
    public int maxFollowingDistance;
    public int detectionDistance;

    private EntityManager manager;
    private Vector2Int startPosition;
    private Vector2Int target;
    private int osefTimer;

    public override void Init()
    {
        base.Init();
        manager = GameManager.Instance.entityManager;
        player = manager.Player;
        transform.position = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z));

        position.x = (int)(transform.position.x);
        position.y = (int)(transform.position.z);

        startPosition = position;
    }

    public override void Step()
    {
        base.Step();
        Vector2Int distPlayerEntity = player.position - position;
        Vector2Int distStartPlayer = player.position - startPosition;

        bool followPlayer = osefTimer <= 0 && distPlayerEntity.magnitude < detectionDistance && distStartPlayer.magnitude < maxFollowingDistance;

        osefTimer = Mathf.Max(0, osefTimer - 1);

        if (followPlayer) 
        {
            position += Pathfinding.GetStepMovement(manager, this, player.position, cellPerStep);
            transform.position = new Vector3(position.x, 0, position.y);
        }
        else
        {
            if(position != startPosition) 
            {
                position += Pathfinding.GetStepMovement(manager, this, startPosition, cellPerStep);
                transform.position = new Vector3(position.x, 0, position.y);
            }
            else 
            {
                manager.AddPathNode(new EntityPathNode(this, position));
            }
        }
    }

    public override void Interact(Entity other)
    {
        if(osefTimer <= 0 && other.type == EntityType.player) 
        {
            GameManager.Instance.resourcesManager.oxygen -= oxygenVoler;
            GameManager.Instance.dialog.AddLog("An Pirate Stole " + oxygenVoler + " oxygen from you");
            osefTimer = osefTimerApresVol;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionDistance);
    }
}
