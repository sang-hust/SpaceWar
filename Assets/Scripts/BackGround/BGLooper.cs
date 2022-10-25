using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    public float _speed = 3f;
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _meshRenderer.material.mainTextureOffset += new Vector2(0, _speed * Time.deltaTime);
    }
}
