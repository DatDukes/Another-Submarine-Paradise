﻿using UnityEngine;

public class StaticEntity : Entity
{
    private EntityManager manager;

    override public void Init()
    {
        manager = GameManager.Instance.entityManager;
        transform.position = new Vector3(Mathf.Round(transform.position.x), 0, Mathf.Round(transform.position.z));
        position.x = (int)(transform.position.x);
        position.y = (int)(transform.position.z);
    }

    override public void Step()
    {
        manager.AddPathNode(new EntityPathNode(this, position));
    }
}