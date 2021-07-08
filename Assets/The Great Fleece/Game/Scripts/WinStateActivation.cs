using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{

	[SerializeField] private GameObject _winStateCutscene;

    void OnTriggerEnter(Collider other)
    {
    	if(other.CompareTag("Player"))
    	{
    		if(GameManager.Instance.HasCard == true)
    		{
    			_winStateCutscene.SetActive(true);
    		}
    		else
    		{
    			Debug.Log("Must have key");
    		}
    	}
    }
}
