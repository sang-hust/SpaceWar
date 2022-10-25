using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private int _heal = 10;

    private void Update()
    {
        _rigidbody2D.velocity = Vector2.down * _speed;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("planebullet") || col.gameObject.CompareTag("Wall"))
        {
            _heal -= PlaneController._instance._dame;
            if (_heal <= 0)
            {
                PlaneController._instance._exp += 4;
                PlaneController._instance._score += 1;
                GamePlayController._instance.ShowScore(PlaneController._instance._score);
                SoundController.instance.ScoreSound();
                gameObject.SetActive(false);
                _heal = 10;
                if (PlaneController._instance._exp >= 20)
                {
                    _heal = 15;
                    _speed = 4f;
                }
            }

            if (PlaneController._instance._exp >= 60)
            {
                GamePlayController._instance.StatusBoss();
            }
        }
    }
    
    
}