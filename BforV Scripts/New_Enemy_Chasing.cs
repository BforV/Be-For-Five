
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Enemy_Chasing : MonoBehaviour
{
    public Transform targetTransform;
    public float speed;
    public Animator atr;
    public Avatar idleAvatar;
    public Avatar runAvatar;
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

    }

    // Update is called once per frame
    void Update()
    {

        if (health < 0)
        {
            Die();
        }
        if (Vector3.Distance(this.transform.position, targetTransform.position) < 10f)
        {
            isChasing = true;

        }


        if (!isChasing)
        {

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

    }

}
