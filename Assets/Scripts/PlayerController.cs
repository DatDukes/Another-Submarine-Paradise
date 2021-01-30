using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : Entity
{
    public int cellPerStep;

    private Vector2Int nextPosition;
    private EntityManager manager;

    override public void Init()
    {
        manager = GameManager.Instance.entityManager;
    }

    override public void Step()
    {
        position += Pathfinding.GetStepMovement(manager, this, nextPosition, cellPerStep);
        transform.position = new Vector3(position.x, 0, position.y);
    }

    public void Move()
    {
        StartCoroutine(MoveCouroutine());
    }

    public override void Interact(Entity other)
    {
        Debug.Log("Interact With " + other.type);
    }

    private IEnumerator MoveCouroutine()
    {
        print("Couroutien start");

        while (EventSystem.current.IsPointerOverGameObject())
        {
            yield return new WaitForEndOfFrame();
        }

        while (true)//Input.GetButtonUp("Fire1") == false)
        {
            if(Input.GetButton("Fire1"))
            {
                nextPosition = GridManager.Instance.GetGripPosition();
                break;
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }

        
    }
}
