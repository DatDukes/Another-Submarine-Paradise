using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GetGripPosition();
        }
    }

    public Vector2Int GetGripPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector2Int pos = new Vector2Int((int)Mathf.Round(hit.point.x), (int)Mathf.Round(hit.point.y));
            print(pos);
            return pos;
        }
        else
        {
            return Vector2Int.zero;
        }
    }


}
