using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	private NavMeshAgent _agent;
    private Animator _anim;
    private AudioSource _audio;

    private Vector3 _target;
    private bool _coinTossed = false;
    public GameObject[] _guards;
    [SerializeField] private GameObject _coin;
    [SerializeField] private AudioClip _coinClip;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
        _audio= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
        	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	RaycastHit hit;
        	if(Physics.Raycast(ray, out hit, 100))
        	{
        		_agent.SetDestination(hit.point);
                _anim.SetBool("Walking", true);
                _target = hit.point;
        		
        	}
        }

        float dist = Vector3.Distance(transform.position, _target);

        if(dist < 1.2f)
        {
            _anim.SetBool("Walking", false);
        }

        if(Input.GetMouseButtonDown(1) && _coinTossed == false)
        {
        	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        	RaycastHit hit;
        	if(Physics.Raycast(ray, out hit, 100))
        	{
        		_coinTossed = true;
        		_anim.SetTrigger("Throwing");
        		Instantiate(_coin, hit.point, Quaternion.identity);
        		_audio.PlayOneShot(_coinClip);
        		SendAIToCoinSpot(hit.point);
        	}
        }
    }

    void SendAIToCoinSpot(Vector3 coinPos)
    {
    	_guards = GameObject.FindGameObjectsWithTag("Guard1");
    	foreach(GameObject guard in _guards)
    	{
    		GuardAI currentGuard = guard.GetComponent<GuardAI>();
    		currentGuard.coinTossed = true;
    		currentGuard.coinPos = coinPos;
    		currentGuard._agent.SetDestination(coinPos);
    		currentGuard._anim.SetBool("Walking", true);
    	}
    }
}
