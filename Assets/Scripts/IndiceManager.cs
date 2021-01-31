using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndiceManager : MonoBehaviour
{
    public GameObject[] objs;
    
    void Start()
    {
        int rnd = Random.Range(0, objs.Length);

        for (int i = 0; i < objs.Length; i++) 
        {
            objs[i].SetActive(i == rnd);
        }
    }
}
