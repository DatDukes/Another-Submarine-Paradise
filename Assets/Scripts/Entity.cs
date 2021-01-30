using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public EntityType type;
    public Vector2Int position;
    public bool isVisible;
    public int visibilityRange;
    public abstract void Init();
    public abstract void Step();
    public virtual void Interact(Entity other) { }
    public virtual void VisibilityCheck(Entity other)
    {
        if(Vector3.Distance( GameManager.Instance.entityManager.Player.transform.position, this.transform.position)< visibilityRange)
        {
            isVisible = true;
        }
        else
        {
            isVisible = false;
        }
    }
}
