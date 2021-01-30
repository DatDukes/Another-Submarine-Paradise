using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingManager : MonoBehaviour
{
    public bool drawingOn = false;
    public bool lineCreated = false;

    public GameObject drawingParent;
    public GameObject linePrefab;

    public float distanceBetweenPoints;

    private int lineCurrentPoint = 0;
    private LineRenderer currentLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(drawingOn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if ( Input.GetButtonDown("Fire1") &&  lineCreated == false)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject newDrawing =  Instantiate(linePrefab, drawingParent.transform) as GameObject;
                    currentLine = newDrawing.GetComponent<LineRenderer>();
                    currentLine.SetPosition(0, hit.point);
                    lineCurrentPoint++;
                }

                lineCreated = true;
            }

            if (Input.GetButton("Fire1") && lineCreated)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if(Vector3.Distance( currentLine.GetPosition(lineCurrentPoint-1), hit.point) > 0.2f)
                    {
                        currentLine.positionCount += 1;
                        currentLine.SetPosition(lineCurrentPoint, hit.point);
                        lineCurrentPoint++;
                    }
                        
                }
            }

            if (Input.GetButtonUp("Fire1") && lineCreated )
            {
                lineCreated = false;
                lineCurrentPoint = 0;
            }

           

            
        }
    }

    public void DrawingButton()
    {
        drawingOn = !drawingOn;
    }

    public void DrawingOff()
    {
        drawingOn = false;
    }
}
