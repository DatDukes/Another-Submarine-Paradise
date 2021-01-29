using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : Entity
{
    public Vector2Int nextPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Init()
    {

    }

    override public void Step()
    {
        this.transform.position = new Vector3(nextPosition.x, this.transform.position.y, nextPosition.y);
    }

    public void Move()
    {
        StartCoroutine(MoveCouroutine());
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
