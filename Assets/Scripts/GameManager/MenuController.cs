using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void _PlayButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void _MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}