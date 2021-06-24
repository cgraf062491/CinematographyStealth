using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
	public List<Transform> wayPoints;
	private NavMeshAgent _agent;
	private Animator _anim;
	[SerializeField] private int currentTarget = 0;
	private float dist;
	private bool reverse = false;
	private bool targetReached = false;

    // Start is called before the first frame update
    void Start()
    {
    	_agent = GetComponent<NavMeshAgent>();
    	_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(wayPoints.Count > 0 && wayPoints[currentTarget] != null)
    	{
    		_agent.SetDestination(wayPoints[currentTarget].position);

    		dist = Vector3.Distance(transform.position, wayPoints[currentTarget].position);

    		if(dist < 1.2f && targetReached == false && wayPoints.Count > 1)
    		{
    			targetReached = true;
    			StartCoroutine(WaitBeforeMoving());
    		}
    	}
    }

    IEnumerator WaitBeforeMoving()
    {
    	float time_wait = Random.Range(1.5f, 2.5f);
    	if(currentTarget == 0 || currentTarget == wayPoints.Count-1)
    	{
    		//Debug.Log("Stop point");
    		_anim.SetBool("Walking", false);
    		yield return new WaitForSeconds(time_wait);
    	}
    	
    	if(reverse == true)
    	{
    		currentTarget -= 1;

    		if(currentTarget == 0)
    		{
    			reverse = false;
    			currentTarget = 0;
    		}
    	}
    	else
    	{
    		currentTarget += 1;

	    	if(currentTarget == wayPoints.Count)
	    	{
	    		reverse = true;
	    		currentTarget -= 1;
	    	}
    	}
    	targetReached = false;
    	_anim.SetBool("Walking", true);
    }
}
