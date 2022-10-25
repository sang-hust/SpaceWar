using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spawn : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1);
        GameObject enemy = EnemyPool1.instance.GetPooledObject();
        enemy.transform.position = transform.position + Vector3.left * UnityEngine.Random.Range(-10f, 10f);
        StartCoroutine(Spawner());
    }
}