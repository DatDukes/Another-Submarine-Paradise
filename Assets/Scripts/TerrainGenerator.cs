using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TerrainGenerator : MonoBehaviour
{
    public Texture2D noise;
    public GameObject prefab;
    public float spawnThreshold;
    public int step;
    public List<GameObject> terrain;

    public bool[,] ColMatix;

    private void Start()
    {
        ColMatix = new bool[64, 64];

        foreach (GameObject obj in terrain) 
        {
            ColMatix[(int)obj.transform.localPosition.x, (int)obj.transform.localPosition.z] = true;
        }

        Pathfinding.SetCollision(transform.position, ColMatix);
    }

    public void Generate() 
    {
#if UNITY_EDITOR
        foreach (GameObject go in terrain) 
        {
            DestroyImmediate(go);
        }

        terrain.Clear();

        for (int x = 0; x < noise.width; x = x + step) 
        {
            for (int y = 0; y < noise.height; y = y + step)
            {
                Color c = noise.GetPixel(x, y);

                if(c.r < spawnThreshold) 
                {
                    GameObject go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
                    go.transform.parent = transform;
                    go.transform.localPosition = new Vector3(x / step, 0, y / step);

                    terrain.Add(go);
                }
            }
        }
#endif
    }
}
