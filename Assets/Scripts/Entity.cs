using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public EntityType type;
    public Vector2Int position;
    public abstract void Init();
    public abstract void Step();
    public virtual void Interact(Entity other) { }
}
