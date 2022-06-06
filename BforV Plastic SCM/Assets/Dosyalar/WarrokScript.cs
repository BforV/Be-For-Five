using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WarrokScript : MonoBehaviour

{
    private NavMeshAgent agent;

    private CharacterController character;

    private Animator warrokanim;

    public Transform victim;

    public float distance;


   
    void Start()
    {
        character = GetComponent<CharacterController>();

        warrokanim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

    }

    
    void Update()
    {
        warrokanim.SetFloat("Speed", agent.velocity.magnitude);

        distance = Vector3.Distance(transform.position,victim.position);

        agent.destination = victim.position;

        if (distance <= 10)
        {
            agent.enabled = true;
        }

        else
        {
            agent.enabled = false;
        }
    }
}