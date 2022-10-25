using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    private void Start()
    {
        float _worldHeight = Camera.main.orthographicSize * 2.5f;
        float _worldWidth = _worldHeight * Screen.width / Screen.height;

        transform.localScale = new Vector3(_worldWidth, _worldHeight, 1);
    }
}
