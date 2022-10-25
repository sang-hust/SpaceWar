using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool1 : MonoBehaviour
{
    

    [SerializeField] private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private int amountToPool = 10;
    [SerializeField] private GameObject enemyPrefab;
    
    public static EnemyPool1 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        AddBulletToPool(amountToPool);
    }

    private void AddBulletToPool(int amountToPool)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform, true);
            enemy.SetActive(false);
            pooledObjects.Add(enemy);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeSelf)
            {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }

        return null;
    }
}