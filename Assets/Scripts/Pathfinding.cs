using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    public static Vector2Int Origin;
    public static bool[,] CollisionMatrice;

    public static void SetCollision(Vector3 origin, bool[,] colMat) 
    {
        Origin = new Vector2Int((int)origin.x, (int)origin.z);
        CollisionMatrice = colMat;
    }

    public static Vector2Int GetStepMovement(EntityManager manager,  Entity entity, Vector2Int targetPos, int maxCell) 
    {
        Vector2Int move = new Vector2Int();
        Vector2Int newMove = new Vector2Int();
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
                newMove.x += j;
                dir.x -= j;
            }
            else
            {
                int j = (int)Mathf.Sign(dir.y);
                newMove.y += j;
                dir.y -= j;
            }

            Vector2Int matPos = entity.position + newMove - Origin;

            if(CollisionMatrice[matPos.x, matPos.y]) 
            {
                return move;
            }

            move = newMove;

            manager.AddPathNode(new EntityPathNode(entity, entity.position + move));
        }

        return move;
    }
}
