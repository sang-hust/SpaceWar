using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BossController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.5f;

    private float _bulletOffset = 1f;
    public float _hp = 300;

    public static BossController _instance;
    private void Start()
    {
        StartCoroutine(Spawner());
        if (_instance == null)
        {
            _instance = this;
        }
    }
    
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(0.25f);
        BossAction();
        StartCoroutine(Spawner());
    }
    private void Update()
    {
        float x = -_speed * Time.deltaTime;
        float y = 0;
        transform.position += new Vector3(x , y , 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("planebullet"))
        {
            _hp -= PlaneController._instance._dame;
            if (_hp <= 0)
            {
                PlaneController._instance._score += 100;
                PlaneController._instance._isStop = true;
                GamePlayController._instance.ShowScore(PlaneController._instance._score);
                GamePlayController._instance.StopGame();
                SoundController.instance.WinSound();
                
                gameObject.SetActive(false);
            }
        }
    }

    private void BossAction()
    {
        GameObject bullet2 = BossBulletPool.instance.GetPooledObject();
        bullet2.transform.position = transform.position + Vector3.down * _bulletOffset + Vector3.right * 0.2f;
        bullet2.GetComponent<BossBulletController>().SetVectorBullet(Vector2.down);
        
        GameObject bullet3 = BossBulletPool.instance.GetPooledObject();
        bullet3.transform.position = transform.position + Vector3.down * _bulletOffset + Vector3.left * 0.2f;
        bullet3.GetComponent<BossBulletController>().SetVectorBullet(Vector2.down);
       
        
    }

}