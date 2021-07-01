using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeycardActivation : MonoBehaviour
{

	[SerializeField] private GameObject _grabCardCutscene;

    void OnTriggerEnter(Collider other)
    {
    	if(other.CompareTag("Player"))
    	{
    		_grabCardCutscene.SetActive(true);
    	}
    }
}
