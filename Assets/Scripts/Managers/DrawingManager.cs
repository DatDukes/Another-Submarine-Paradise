using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingManager : MonoBehaviour
{
    public bool drawingOn = false;
    public bool lineCreated = false;

    public bool erasingOn = false;

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
                
                MeshCollider meshCollider = currentLine.gameObject.GetComponent<MeshCollider>();

                Mesh mesh = new Mesh();
                currentLine.BakeMesh(mesh, true);
                meshCollider.sharedMesh = mesh;

                lineCreated = false;
                lineCurrentPoint = 0;
            }
            
        }

        if(erasingOn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetButton("Fire1"))
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider.tag == "Line")
                    {
                        Destroy(hit.collider.gameObject);
                    }
                }

            }
        }
    }

    public void DrawingButton()
    {
        drawingOn = !drawingOn;
        ErasingOff();
    }

    public void DrawingOff()
    {
        drawingOn = false;
    }

    public void ErasingButton()
    {
        erasingOn = !erasingOn;
        DrawingOff();
    }

    public void ErasingOff()
    {
        erasingOn = false;
    }
}
