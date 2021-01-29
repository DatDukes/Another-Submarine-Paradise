using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2Int GetGripPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) )
        {
            Vector2Int pos = new Vector2Int((int)Mathf.Round(hit.point.x), (int)Mathf.Round(hit.point.z));
            print(pos);
            return pos;
        }
        else
        {
            return Vector2Int.zero;
        }
    }

    
}
