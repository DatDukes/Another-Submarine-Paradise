using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public EntityType type;
    public Vector2Int position;
    public bool isVisible;
    public int visibilityRange;
    public MeshRenderer meshRender;

    public virtual void Init()
    {
        switch(type)
        {
            case EntityType.player:
                visibilityRange = 1;
                break;
            case EntityType.terrain:
                visibilityRange = (int)GameManager.Instance.gameSettings.visibilityTerrains;
                break;
            case EntityType.ennemy:
                visibilityRange = (int)GameManager.Instance.gameSettings.visibilityEnemies;
                break;
            case EntityType.stash:
                visibilityRange = (int)GameManager.Instance.gameSettings.visibilityStashes;
                break;
        }
    }
    public abstract void Step();
    public virtual void Interact(Entity other) { }

    public void Update()
    {
        ///Archi schlag, a changé si possible
        if(meshRender == null)
        {
            meshRender = this.GetComponentInChildren<MeshRenderer>();
        }

        if(VisibilityCheck())
        {
            meshRender.enabled = true;
        }
        else
        {
            meshRender.enabled = false;
        }
    }

    public virtual bool VisibilityCheck()
    {
        if(Vector3.Distance( GameManager.Instance.entityManager.Player.transform.position, this.transform.position)< visibilityRange)
        {
            isVisible = true;
            
        }
        else
        {
            isVisible = false;
        }

        return isVisible;
    }
}
