﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
    	get
    	{
    		if(_instance == null)
    		{
    			Debug.LogError("GameManager is null");
    		}

    		return _instance;
    	}
    }

    public bool HasCard{get;set;}
    public PlayableDirector introCutscene;

    void Awake()
    {
    	_instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            introCutscene.time = 60.0f;
            AudioManager.Instance.PlayMusic();
        }
    }
}
