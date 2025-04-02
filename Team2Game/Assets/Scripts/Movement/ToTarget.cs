using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private Animator Player;
    NavMeshAgent agent;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(target.position);
        if (agent.velocity.magnitude > 0)
        {
            Player.ResetTrigger("Stop");
            Player.Play("Walking");
        }else
        {
            Player.SetTrigger("Stop");
        }
    }
}
