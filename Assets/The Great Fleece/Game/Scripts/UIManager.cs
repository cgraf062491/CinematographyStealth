﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    private static UIManager Instance
    {
    	get
    	{
    		if(_instance == null)
    		{
    			Debug.LogError("UIManager is null");
    		}

    		return _instance;
    	}
    }

    void Awake()
    {
    	_instance = this;
    }

    public void ResetGame()
    {
    	SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
    	Application.Quit();
    }
}
