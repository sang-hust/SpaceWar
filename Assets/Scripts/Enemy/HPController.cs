using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    public Image _healthBar;
    int _healthMax = 100;
    
    private void Update()
    {
        
        _healthBar.fillAmount = BossController._instance._hp / _healthMax;
    }
    
}
