using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GamePlayController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel, _boss, _enemySpawn;
    [SerializeField] private Text _scoreText, _levelText, _endScore;
    [SerializeField] private GameObject _bulletPool;
    
    public int _planeLevel = 0;
    public static GamePlayController _instance;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void ShowScore(int score)
    {
        _scoreText.text = "" + score;
        _endScore.text = "" + score;
    }

    public void ShowLevel()
    {
        _planeLevel++;
        _levelText.text = "" + _planeLevel;
    }
    
    public void StopGame()
    {
        _gameOverPanel.SetActive(true);
        _bulletPool.SetActive(false);
    }
    public void StatusBoss()
    {
        _boss.SetActive(true);
        _enemySpawn.SetActive(false);
    }
    
}
