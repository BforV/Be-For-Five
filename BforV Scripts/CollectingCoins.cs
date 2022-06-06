using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
    public AudioSource coinSound; 

    void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Scoring.score += 1;
            coinSound.Play();
            Destroy(gameObject);
        }
    }
}