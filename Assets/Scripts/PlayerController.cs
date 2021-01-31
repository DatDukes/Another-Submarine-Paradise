using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : Entity
{
    public GameObject moveFeeback;

    [HideInInspector]
    public int cellPerStep;

    private Vector2Int nextPosition;
    private EntityManager manager;

    override public void Init()
    {
        manager = GameManager.Instance.entityManager;
        cellPerStep = GameManager.Instance.gameSettings.startMoveRange;
    }

    override public void Step()
    {
        if (position != nextPosition)
        {
            position += Pathfinding.GetStepMovement(manager, this, nextPosition, cellPerStep);
            transform.DOMove(new Vector3(position.x, 0, position.y), 0.5f).OnComplete(() => { GameManager.Instance.stepManager.GoToNextStep(); });
            //transform.position = new Vector3(position.x, 0, position.y);
        }
        else 
        {
            manager.AddPathNode(new EntityPathNode(this, position));
            GameManager.Instance.stepManager.locked = false;
        }
        //moveFeeback.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1") && !EventSystem.current.IsPointerOverGameObject() && !GameManager.Instance.drawingManager.drawingOn && !GameManager.Instance.drawingManager.erasingOn)
        {
            nextPosition = GridManager.Instance.GetGripPosition();
            moveFeeback.transform.position = new Vector3(nextPosition.x, this.transform.position.y, nextPosition.y);
            moveFeeback.SetActive(true);
        }
    }

    public void Move()
    {
        if(!GameManager.Instance.gameOver) StartCoroutine(MoveCouroutine());
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

        while (true)
        {
            if(Input.GetButton("Fire1"))
            {
                nextPosition = GridManager.Instance.GetGripPosition();
                moveFeeback.transform.position = new Vector3( nextPosition.x, this.transform.position.y, nextPosition.y);
                moveFeeback.SetActive(true);
                break;
            }
            else
            {
                yield return new WaitForEndOfFrame();
            }
        }

        
    }
}
