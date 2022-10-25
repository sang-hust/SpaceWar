using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Rigidbody2D _rigidbody2D;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("plane"))
        {
            gameObject.SetActive(false);
            GamePlayController._instance.StopGame();
            SoundController.instance.DeadSound();
            PlaneController._instance._animator.SetTrigger("dead");
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
    public void SetVectorBullet(Vector2 direction)
    {
        _rigidbody2D.velocity = direction * _speed;
    }
}
 