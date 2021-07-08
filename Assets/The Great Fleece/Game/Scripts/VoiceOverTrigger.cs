using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
	private AudioSource _audio;
    [SerializeField] private AudioClip _triggerDialogue;

    void Start()
    {
    	_audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
    	if(other.CompareTag("Player"))
    	{
    		//_audio.PlayOneShot(_triggerDialogue);
            AudioManager.Instance.PlayVoiceOver(_triggerDialogue);
    	}
    }
}
