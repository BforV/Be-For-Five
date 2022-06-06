using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Enemy : MonoBehaviour
{
    public Transform targetTransform;
    public float speed;
    public Animator atr;
    public Avatar idleAvatar;
    public Avatar runAvatar;
    public Vector3 patrolTarget;
    public bool isPatrolTargetSet = false;
    public bool isPatroling = true;
    public bool isChasing = false;
    public float chasetime;
    public float turnSpeed;
    public int health;
    public int takenDamage;
    public int givenDamage;
    public GameObject deadPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SetPatrolTarget();
    }

    // Update is called once per frame
    void Update()
    {

        if(health < 0)
        {
            Die();
        }
        if (Vector3.Distance(this.transform.position, targetTransform.position) < 10f)
        {
            isChasing = true;
            isPatrolTargetSet = false;
            isPatroling = false;
        }
        else if(Vector3.Distance(this.transform.position, targetTransform.position) > 10f && !isPatrolTargetSet)
        {
            isChasing = false;
            SetPatrolTarget();
        }
        else if (Vector3.Distance(this.transform.position, targetTransform.position) > 10f && isPatrolTargetSet)
        {
            isPatroling = true;
        }

        if (!isChasing)
        {
            Patrol();
        }
        else
        {
            Follow(targetTransform);
        }
        
              
    }
    void Die()
    {
            
        Instantiate(deadPrefab, this.transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Destroy(this.gameObject);
    }
    void Follow(Transform target)
    {
            atr.avatar = runAvatar;
            atr.SetBool("isChasing", true);
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);

        // Smoothly rotate towards the target point.
        this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            isPatrolTargetSet = false;   
    }

    void SetPatrolTarget()
    {
        chasetime = Time.time;
        patrolTarget = new Vector3(this.transform.position.x + Random.Range(-5, 5), this.transform.position.y, this.transform.position.z + Random.Range(-5, 5));
        isPatrolTargetSet = true;
    }
    void Patrol()
    {

            if (Vector3.Distance(this.transform.position, patrolTarget) > 1f)
            {
                atr.avatar = runAvatar;
                atr.SetBool("isChasing", true);
             Quaternion targetRotation = Quaternion.LookRotation(patrolTarget - transform.position);

            // Smoothly rotate towards the target point.
            this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
                this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else
            {
                isPatroling = false;
                SetPatrolTarget();
            }
            
        
    }
}
