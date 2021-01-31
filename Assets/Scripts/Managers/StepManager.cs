using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{

    public void PrepareNextStep()
    {
        GameManager.Instance.entityManager.Player.Step();
    }

    public void GoToNextStep()
    {
        for(int i =1; i <  GameManager.Instance.entityManager.entities.Count; i++)
        {
            GameManager.Instance.entityManager.entities[i].Step();
        }

        GameManager.Instance.entityManager.pathsNodes.Clear();

        GameManager.Instance.resourcesManager.LowerResource(RessourceType.Oxygen, GameManager.Instance.gameSettings.stepOxygenConsumed);
    }
}
