using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float planeSpeed = 3f;
    [SerializeField] private float bulletOffset = 0.5f;
    
    public Animator _animator;
    private float horizontal, vertical;
    private static readonly int Dead = Animator.StringToHash("dead");
    private int next = 20;

    public bool _isStop = false;
    public int _exp = 0;
    public int _dame = 5;
    public float _speedHit = 0.2f;
    public int _score = 0;
    public static PlaneController _instance;
 
    

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Spawner());
        if (_exp >= 20 && _exp < 40)
        {
            GamePlayController._instance.ShowLevel();
            SoundController.instance.LevelUpSound();
        }
    }
    
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(_speedHit);
        if (!_isStop)
        {
            planeAction();
        }
        StartCoroutine(Spawner());
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        float xDic = horizontal * Time.deltaTime * planeSpeed;
        float yDic = vertical * Time.deltaTime * planeSpeed;
        if (!_isStop)
        {
            transform.position += new Vector3(xDic, yDic, 0);
        }
        
    }

    void planeAction()
    {
        SoundController.instance.HitSound();
        if (_exp < 20)
        {
            GameObject bullet = BulletPool.instance.GetPooledObject();
            bullet.transform.position = transform.position + Vector3.up * bulletOffset;
            bullet.GetComponent<BulletController>().SetVectorBullet(Vector2.up);

        } else if (_exp < 40 && _exp >= 20)
        {
            if (_exp == next)
            {
                GamePlayController._instance.ShowLevel();
                SoundController.instance.LevelUpSound();
                next += 20;
            }
            GameObject bullet1 = BulletPool.instance.GetPooledObject();
            bullet1.transform.position = transform.position + Vector3.up * bulletOffset + Vector3.left * 0.2f;
            bullet1.GetComponent<BulletController>().SetVectorBullet(Vector2.up);

            GameObject bullet2 = BulletPool.instance.GetPooledObject();
            bullet2.transform.position = transform.position + Vector3.up * bulletOffset + Vector3.right * 0.2f;
            bullet2.GetComponent<BulletController>().SetVectorBullet(Vector2.up);
        } else if (_exp >= 40)
        {
            if (_exp == next)
            {
                GamePlayController._instance.ShowLevel();
                SoundController.instance.LevelUpSound();
                next += 20;
            }
            GameObject bullet1 = BulletPool.instance.GetPooledObject();
            bullet1.transform.position = transform.position + Vector3.up * bulletOffset;
            bullet1.GetComponent<BulletController>().SetVectorBullet(new Vector2(1,3).normalized);
            
            GameObject bullet2 = BulletPool.instance.GetPooledObject();
            bullet2.transform.position = transform.position + Vector3.up * bulletOffset;
            bullet2.GetComponent<BulletController>().SetVectorBullet(new Vector2(-1,3).normalized);
            
            GameObject bullet3 = BulletPool.instance.GetPooledObject();
            bullet3.transform.position = transform.position + Vector3.up * bulletOffset;
            bullet3.GetComponent<BulletController>().SetVectorBullet(Vector2.up);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            GamePlayController._instance.StopGame();
            SoundController.instance.DeadSound();
            
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            _animator.SetTrigger(Dead);
            _isStop = true;
        }
    }
}
