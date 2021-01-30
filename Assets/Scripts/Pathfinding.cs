using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    public static Vector2Int GetStepMovement(EntityManager manager,  Entity entity, Vector2Int targetPos, int maxCell) 
    {
        Vector2Int move = new Vector2Int();
        Vector2Int dir = targetPos - entity.position;

        for(int i = 0; i < maxCell; i++) 
        { 
            if(dir.x == 0 && dir.y == 0) 
            {
                return move;
            }

            if(Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            {
                int j = (int)Mathf.Sign(dir.x);
                move.x += j;
                dir.x -= j;
            }
            else
            {
                int j = (int)Mathf.Sign(dir.y);
                move.y += j;
                dir.y -= j;
            }

            manager.AddPathNode(new EntityPathNode(entity, entity.position + move));
        }

        return move;
    }
}
