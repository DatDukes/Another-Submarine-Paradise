using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{

    public void CallNextStep()
    {

    }


    public void GoToNextStep()
    {
        foreach(Entity i in GameManager.Instance.entityManager.entities)
        {
            i.Step();
        }

        GameManager.Instance.entityManager.pathsNodes.Clear();

        GameManager.Instance.resourcesManager.LowerResource(RessourceType.Oxygen, GameManager.Instance.gameSettings.stepOxygenConsumed);
    }
}
