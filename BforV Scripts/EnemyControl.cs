using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour

{
    NavMeshAgent agent;

    CharacterController character;

    Animator warrokanim;

    public Transform victim;

    public float distance;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();

        warrokanim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        warrokanim.SetFloat("speed", agent.velocity.magnitude);

        distance = Vector3.Distance(transform.position,
                                    victim.position);

        agent.destination = victim.position;

            if(distance <= 10)
            {
                agent.enabled = true;
            }

            else
            {
                agent.enabled = false;
            }
    }
}