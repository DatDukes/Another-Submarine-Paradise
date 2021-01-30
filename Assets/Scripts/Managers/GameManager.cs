using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GridManager gridManager;
    public StepManager stepManager;
    public EntityManager entityManager;
    public RessourcesManager resourcesManager;
    public DrawingManager drawingManager;

    public GameSettings gameSettings;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
