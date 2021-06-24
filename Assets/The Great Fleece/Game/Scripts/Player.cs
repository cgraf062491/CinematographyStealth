using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	private NavMeshAgent _agent;
    private Animator _anim;

    private Vector3 _target;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
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
    }
}
