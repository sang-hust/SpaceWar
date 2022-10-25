using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    

    [SerializeField] private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private int amountToPool = 5;
    [SerializeField] private GameObject bulletPrefab;
    
    public static BulletPool instance;

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
            GameObject bullet = Instantiate(bulletPrefab, transform, true);
            bullet.SetActive(false);
            pooledObjects.Add(bullet);
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
