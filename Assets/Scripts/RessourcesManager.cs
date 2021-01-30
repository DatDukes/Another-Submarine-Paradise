using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesManager : MonoBehaviour
{
    [HideInInspector]
    public int oxygen;

    // Start is called before the first frame update
    void Start()
    {
        oxygen = GameManager.Instance.gameSettings.startOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
