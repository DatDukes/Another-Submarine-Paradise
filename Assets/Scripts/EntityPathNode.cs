using UnityEngine;

public class EntityPathNode
{
    public EntityPathNode(Entity entity, Vector2Int nodePosition) 
    {
        this.entity = entity;
        this.nodePosition = nodePosition;
    }

    public Entity entity;
    public Vector2Int nodePosition;
}
