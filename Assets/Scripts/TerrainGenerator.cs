using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Texture2D noise;
    public GameObject prefab;
    public float spawnThreshold;
    public int step;
    public List<GameObject> terrain;

    public void Generate() 
    {
        foreach(GameObject go in terrain) 
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
                    GameObject go = Instantiate(prefab);
                    go.transform.parent = transform;
                    go.transform.localPosition = new Vector3(x / step, 0, y / step);

                    terrain.Add(go);
                }
            }
        }
    }
}
