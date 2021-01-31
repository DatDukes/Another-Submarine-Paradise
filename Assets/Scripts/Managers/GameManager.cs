using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool gameOver;
    public TextMeshProUGUI text;

    public GridManager gridManager;
    public StepManager stepManager;
    public EntityManager entityManager;
    public RessourcesManager resourcesManager;
    public DrawingManager drawingManager;
    public DialogManager dialog;

    public GameSettings gameSettings;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        text.gameObject.SetActive(false);
    }

    public void GameOver(bool win)
    {
        gameOver = true;

        text.text = win ? "You Win" : "Game Over";

        text.gameObject.SetActive(true);
    }
}
