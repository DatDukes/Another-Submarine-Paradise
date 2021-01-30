using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public Entity Player 
    {
        get 
        {
            return entities[0];
        }
    }

    public List<Entity> entities;
    [HideInInspector] public List<EntityPathNode> pathsNodes;

    public void AddPath(List<EntityPathNode> path)
    {
        foreach (EntityPathNode node in pathsNodes)
        {
            foreach (EntityPathNode newNode in path)
            {
                node.entity.Interact(newNode.entity);
                newNode.entity.Interact(node.entity);
                break;
            }
        }

        pathsNodes.AddRange(path);
    }

    public void AddPathNode(EntityPathNode newNode)
    {
        foreach(EntityPathNode node in pathsNodes) 
        { 
            if(node.nodePosition == newNode.nodePosition) 
            {
                node.entity.Interact(newNode.entity);
                newNode.entity.Interact(node.entity);
            }
        }

        pathsNodes.Add(newNode);
    }

    private void Start()
    {
        pathsNodes = new List<EntityPathNode>();

        foreach (Entity entity in entities) 
        {
            entity.Init();
        }
    }
}
