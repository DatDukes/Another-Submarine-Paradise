using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public GameObject noiseLayer;

    public float maxSpeed;
    public float acceleration;

    public float normalZoom;
    public Vector3 normalZoomNoiseScale;
    public float maxZoom;
    public Vector3 maxZoomNoiseScale;

    private Vector3 baseOffset;
    private bool zommedOut = false;

    // Start is called before the first frame update
    void Start()
    {
        baseOffset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if( Vector3.Distance(this.transform.position, player.transform.position+baseOffset) > 0.05f )
        {
            this.transform.position += ((player.transform.position + baseOffset) - this.transform.position).normalized * Time.deltaTime * maxSpeed;
        }

    }

    public void ZoomButton()
    {
        if (zommedOut)
        {
            Zoom();
        }
        else
        {
            Dezoom();
        }
    }

    public void Dezoom ()
    {
        //
        Camera.main.DOOrthoSize(maxZoom, 0.5f);
        noiseLayer.transform.DOScale( maxZoomNoiseScale, 0.5f);
        zommedOut = true;
    }

   public void Zoom()
    {
        Camera.main.DOOrthoSize(normalZoom, 0.5f);
        noiseLayer.transform.DOScale(normalZoomNoiseScale, 0.5f);
        zommedOut = false;
    }
}
