using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
    public GameObject[] tutoriels;

    void Start()
    {
        foreach(GameObject go in tutoriels) 
        {
            go.SetActive(false);
        }
    }

    public void StartTutorial()
    {
        if (!GameManager.Instance.gameOver) StartCoroutine(Tuto());
    }

    private IEnumerator Tuto()
    {
        int i = 0;
        tutoriels[i].SetActive(true);

        GameManager.Instance.gameOver = true;

        while (i < tutoriels.Length)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                tutoriels[i].SetActive(false);
                i++;
                if(i < tutoriels.Length) tutoriels[i].SetActive(true);
            }
            yield return null;
        }

        GameManager.Instance.gameOver = false;
    }
}
