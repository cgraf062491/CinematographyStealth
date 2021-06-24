using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
	[SerializeField] private Transform _newCam;

    void OnTriggerEnter(Collider other)
    {
    	if(other.CompareTag("Player"))
    	{
    		//Debug.Log("trigger activated");
    		Camera.main.transform.position = _newCam.position;
    		Camera.main.transform.rotation = _newCam.rotation;
    	}
    }
}
