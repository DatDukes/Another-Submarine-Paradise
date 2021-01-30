using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    public float maxSpeed;
    public float acceleration;

    private Vector3 baseOffset;

    // Start is called before the first frame update
    void Start()
    {
        baseOffset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if( Vector3.Distance(this.transform.position, player.transform.position+baseOffset) > 0.5f )
        {
            this.transform.position += ((player.transform.position + baseOffset) - this.transform.position).normalized * Time.deltaTime * maxSpeed;
        }
    }
}
