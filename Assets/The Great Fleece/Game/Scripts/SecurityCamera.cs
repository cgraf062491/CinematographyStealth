using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCutscene;

    private Animator _anim;
    private Renderer _renderer;

    void Start()
    {
    	_anim = transform.parent.GetComponent<Animator>();
    	_renderer = GetComponent<Renderer>();
    }


    IEnumerator OnTriggerEnter(Collider other)
    {
    	if(other.CompareTag("Player"))
    	{
    		_anim.enabled = false;
    		_renderer.material.SetColor("_TintColor", new Color(0.43f, 0.1f, 0.12f, 0.04f));
    		yield return new WaitForSeconds(0.5f);
    		//Debug.Log("eyes");
    		_gameOverCutscene.SetActive(true);
    	}
    }
}
