﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNextStep()
    {
        foreach(Entity i in GameManager.Instance.entityManager.entities)
        {
            i.Step();
        }

        GameManager.Instance.resourcesManager.oxygen -= GameManager.Instance.gameSettings.stepOxygenConsumed;
    }
}
