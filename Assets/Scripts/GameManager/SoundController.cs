using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _getScoreClip, _deadClip, _hitClip, _leveUpClip, _winClip;

    public static SoundController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void ScoreSound()
    {
        _audioSource.PlayOneShot(_getScoreClip);
    }

    public void DeadSound()
    {
        _audioSource.PlayOneShot(_deadClip);
    }

    public void HitSound()
    {
        _audioSource.PlayOneShot(_hitClip);
    }

    public void LevelUpSound()
    {
        _audioSource.PlayOneShot(_leveUpClip);
    }

    public void WinSound()
    {
        _audioSource.PlayOneShot(_winClip);
    }
}
