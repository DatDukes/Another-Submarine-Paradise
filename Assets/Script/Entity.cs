using UnityEngine;

public abstract class Entity :MonoBehaviour
{
    public Vector2Int position;
    public abstract void Init();
    public abstract void Step();
}
