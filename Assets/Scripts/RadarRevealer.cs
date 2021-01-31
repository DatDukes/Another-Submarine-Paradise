using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RadarRevealer : MonoBehaviour
{

    public float animationTime;
    public Vector3 endSize;

    public Ease easeType;

    private void Start()
    {
        DoCheck();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Entity")
        {
            Entity otherEntity = other.GetComponent<Entity>();
            if( otherEntity.isVisible)
            {
                otherEntity.meshRender.enabled = true;
            }
        }
    }

    public void DoCheck()
    {
        this.transform.localScale = Vector3.zero;
        this.transform.DOScale(endSize, animationTime).OnComplete(() => { this.transform.localScale = Vector3.zero; GameManager.Instance.stepManager.locked = false; }).SetEase(easeType) ;
    }
}
